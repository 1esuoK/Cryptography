// Sample.cpp


#include "cryptopp/hex.h"
using CryptoPP::HexEncoder;
using CryptoPP::HexDecoder;

#include "cryptopp/base64.h"
using CryptoPP::Base64Encoder;
using CryptoPP::Base64Decoder;

#include "cryptopp/rsa.h"
using CryptoPP::RSA;
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;
using CryptoPP::SHA256;

#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::PK_EncryptorFilter;
using CryptoPP::PK_DecryptorFilter;

#include "cryptopp/files.h"
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/secblock.h"
using CryptoPP::SecByteBlock;

#include <cryptopp/queue.h>
using CryptoPP::ByteQueue;

#include <cryptopp/cryptlib.h>
using CryptoPP::Exception;
using CryptoPP::DecodingResult;
using CryptoPP::PrivateKey;
using CryptoPP::PublicKey;
using CryptoPP::BufferedTransformation;

#include <stdexcept>
using std::runtime_error;

#include <string>
using std::string;

#include <exception>
using std::exception;

#include <iostream>
#include <assert.h>

//Vietnamese on Windows
#include <chrono>
#ifdef _WIN32
#include <windows.h>
#endif
#include <locale>
#include <cstdlib>
#include <cctype>

//Binary Encode Private Key
void EncodePrivateKey(const string& filename, const RSA::PrivateKey& key);
//Binary Decode Private Key
void DecodePrivateKey(const string& filename, RSA::PrivateKey& key);
//Binary Encode Public Key
void EncodePublicKey(const string& filename, const RSA::PublicKey& key);
//Binary Decode Public Key
void DecodePublicKey(const string& filename, RSA::PublicKey& key);

void Save(const string& filename, const BufferedTransformation& bt);
void Load(const string& filename, BufferedTransformation& bt);

int main(int argc, char* argv[])
{
    try
    {   
        #ifdef __linux__
        std::locale::global(std::locale("C.utf8"));
        #endif
        
        #ifdef _WIN32
        // Set console code page to UTF-8 on Windows
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);
        #endif
        //Initiate variables
        AutoSeededRandomPool rng;
        int action_option, plain_option, cipher_option, save_option;
        std::string plain, file_plain, cipher, hex_cipher, file_cipher, encoded, recovered;

        std::cout << "Which action would you like to perform ?\n";
        std::cout <<"1. Key Generation\n2. Encrypt\n3. Decrypt\n";
        std::cout <<"Choose (1/2/3): ";
        std::cin >> action_option;
        
        switch(action_option){
            //Key Generation
            case 1:
            {
                //Private key
                RSA::PrivateKey rsaPrivate;
                rsaPrivate.GenerateRandomWithKeySize(rng, 3072);
                //Public key
                RSA::PublicKey rsaPublic(rsaPrivate);
                std::cout << "Module n: " << std::hex << rsaPrivate.GetModulus() << std::endl;
                std::cout << "Prime number p: " << std::hex <<rsaPrivate.GetPrime1() << std::endl;
                std::cout << "Prime number q: " << std::hex << rsaPrivate.GetPrime2() << std::endl;
                std::cout << "Private key d: " << std::hex << rsaPrivate.GetPrivateExponent() << std::endl;
                std::cout << "e: " << rsaPrivate.GetPublicExponent() << std::endl;
                //Save key to files
                EncodePrivateKey("rsa-private.der", rsaPrivate);
                EncodePublicKey("rsa-public.der", rsaPublic);				

                std::cout << "Successfully generated and saved RSA keys" << std::endl;
                break;
            }
            //Encrypt - Cipher = Encrypt(PublicKey, Plain)
            case 2:
            {   
                //Load PublicKey
                RSA::PublicKey publicKey;
                DecodePublicKey("rsa-public.der", publicKey);
                RSAES_OAEP_SHA_Encryptor e( publicKey );

                std::cout << "Would you like to enter plaintext from file or from screen ?\n";
                std::cout << "1. From Screen\n2. From File\n";
                std::cout << "Choose (1/2): ";
                std::cin >> plain_option;
                if(plain_option == 1){
                    std::cout<< "Enter plaintext: ";
                    std::cin.ignore();
                    getline(std::cin, plain);
                }else if(plain_option == 2){
                    std::cout<< "Enter filename: ";
                    std::cin>>file_plain;
				    FileSource(file_plain.data(),true,new StringSink(plain));
                }else {
                    std::cout << "\nInvalid Option!\n";
                    std::exit(0);
                }
                
                // Encryption
                StringSource(plain, true,
                    new PK_EncryptorFilter(rng, e,
                        new StringSink(cipher)) // PK_EncryptorFilter
                );
                
                //Pretty print ciphertext
                StringSource(cipher, true, new HexEncoder(new StringSink(encoded)));
                std::cout << "Plaintext: " << plain << std::endl;
                std::cout << "Ciphertext: " << encoded << std::endl;

                std::cout << std::endl << "Would you like to save this ciphertext? (Y/N): ";
                std::cin.ignore();
                save_option = getchar();
                if (tolower(save_option) == 'y') {
                    //Save cipher to file
                    StringSource(encoded, true, new FileSink("cipher.txt"));
                    std::cout << "Successfully saved cipher to 'cipher.txt'";
                }
                break;
            }
            //Decrypt - Plain = Decrypt(PrivateKey, Cipher)
            case 3:
            {   
                //Load PrivateKey
                RSA::PrivateKey privateKey;
                DecodePrivateKey("rsa-private.der",privateKey);
                RSAES_OAEP_SHA_Decryptor d( privateKey );

                std::cout << "Would you like to enter ciphertext from file or from screen ?\n";
                std::cout << "1. From Screen\n2. From File\n";
                std::cout << "Choose (1/2): ";
                std::cin >> cipher_option;
                if(cipher_option == 1){
                    std::cout<< "Enter ciphertext: ";
                    std::cin.ignore();
                    getline(std::cin, hex_cipher);
                }else if(cipher_option == 2){
                    std::cout<< "Enter filename: ";
                    std::cin>>file_cipher;
				    FileSource(file_cipher.data(),true,new StringSink(hex_cipher));
                }else {
                    std::cout << "\nInvalid Option!\n";
                    std::exit(0);
                }
                //Decode hex cipher to binary string
                StringSource(hex_cipher, true, new HexDecoder(new StringSink(cipher)));
                auto start = std::chrono::high_resolution_clock::now();

                for (int i = 0; i < 10000; ++i) {
                //Decryption
                StringSource(cipher, true,
                    new PK_DecryptorFilter( rng, d,
                        new StringSink( recovered )
                    ) // PK_EncryptorFilter
                ); // StringSource
                std::cout << "loop " << i+1 << std::endl;
                }
                auto end = std::chrono::high_resolution_clock::now();
                auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
                double averageTime = static_cast<double>(duration) / 10000.0;

                std::cout << "Decrypted message: " << recovered <<std::endl;
                // Output the average time taken for a single encryption/decryption round
                std::cout << "Average time for encryption/decryption over 10000 rounds: " << averageTime << " ms" << std::endl;
                break;
            }
            default:
                std::cout << "\nInvalid Option\n";
                std::exit(0);
                break;
        }

        ////////////////////////////////////////////////
        // Decryption
        // assert( plain == recovered );
    }
    catch( CryptoPP::Exception& e )
    {
        std::cerr << "Caught Exception..." << std::endl;
        std::cerr << e.what() << std::endl;
    }

	return 0;
}
//Binary Encode Private Key
void EncodePrivateKey(const string& filename, const RSA::PrivateKey& key)
{
	ByteQueue queue;
	key.DEREncodePrivateKey(queue);
	Save(filename, queue);
}
//Binary Encode Public Key
void EncodePublicKey(const string& filename, const RSA::PublicKey& key)
{
	ByteQueue queue;
	key.DEREncodePublicKey(queue);
	Save(filename, queue);
}
//Save to file from buffer
void Save(const string& filename, const BufferedTransformation& bt)
{
	FileSink file(filename.c_str());

	bt.CopyTo(file);
	file.MessageEnd();
}
//Binary Decode Private Key
void DecodePrivateKey(const string& filename, RSA::PrivateKey& key)
{
	ByteQueue queue;
	Load(filename, queue);
	key.BERDecodePrivateKey(queue, false /*optParams*/, queue.MaxRetrievable());
}
//Binary Decode Public Key
void DecodePublicKey(const string& filename, RSA::PublicKey& key)
{
	ByteQueue queue;
	Load(filename, queue);
	key.BERDecodePublicKey(queue, false /*optParams*/, queue.MaxRetrievable());
}
//Load from file to buffer
void Load(const string& filename, BufferedTransformation& bt)
{
	FileSource file(filename.c_str(), true /*pumpAll*/);

	file.TransferTo(bt);
	bt.MessageEnd();
}
