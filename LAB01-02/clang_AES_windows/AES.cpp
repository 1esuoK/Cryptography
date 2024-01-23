#include <iostream>
using std::cout;
using std::cerr;
using std::endl;

#include <chrono>
#ifdef _WIN32
#include <windows.h>
#endif

#include <string>
using std::string;

#include <cstdlib>
using std::exit;

#include "assert.h"

#include "cryptopp/osrng.h"
using CryptoPP::AutoSeededRandomPool;

//Header for working with string and array
#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::StreamTransformationFilter;

//Header for working with files
#include "cryptopp/files.h"
using CryptoPP::FileSource;
using CryptoPP::FileSink;

#include "cryptopp/cryptlib.h"
using CryptoPP::Exception;

#include "cryptopp/hex.h"
using CryptoPP::HexEncoder;
using CryptoPP::HexDecoder;

#include "cryptopp/filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::StreamTransformationFilter;

#include "cryptopp/aes.h"
using CryptoPP::AES;

#include "AESmodes.h"
void enter_iv(byte* iv , int iv_option);
int main(int argc, char* argv[])
{
	 // Set locale to support UTF-8
    #ifdef __linux__
    std::locale::global(std::locale("C.utf8"));
    #endif
    
    #ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    #endif
	AutoSeededRandomPool prng;
	
	int action_option, mode_option, plain_option, key_option, iv_option, key_size , iv_size, cipher_option;
	std::string plain, file_key, string_key, key_encoded, file_plain, string_iv, file_iv, iv_encoded, cipher_encoded, ciphertext, file_cipher, hex_cipher, recovered;
	std::string encrypted;
	char recover_option;
	//std::cin.ignore();

	//Mode of operation
	std::cout<< "Select Mode of Opereation: " << std::endl;
	std::cout << "1. ECB\n2. CBC\n3. CFB\n4. OFB\n5. CTR\n6. XTS\n7. CCM\n8. GCM" << std::endl;
    std::cout << "Choose (1/2/3/4/5/6/7/8): ";
    std::cin >> mode_option;

	if (mode_option == 6) {
    	key_size = 32;
	} else {
    	key_size = AES::DEFAULT_KEYLENGTH;
	}

	if (mode_option == 7) {
    	iv_size = 12;
	} else {
    	iv_size = AES::BLOCKSIZE;
	}

    CryptoPP::byte key[key_size];
    CryptoPP::byte iv[iv_size];

	//Encrypt or Decrypt
	std::cout << "Would you like to encrypt or decrypt?" << std::endl;
    std::cout << "1. Encrypt\n2. Decrypt\n";
    std::cout << "Choose (1/2): ";
    std::cin >> action_option;

	switch (action_option)
	{
	//Encrypting
	case 1:
		//Enter plaintext
		std::cout<<"Would you like to input plaintext from screen or from file?" << std::endl;
		std::cout<<"1. Input from screen\n2. Input from file"<< std::endl;
		std::cout<<"Choose (1/2): ";
		std::cin>>plain_option;
		switch (plain_option)
		{
			case 1:
				std::cout << "Input plaintext: ";
				std::cin.ignore();
				std::getline(std::cin, plain);
				break;
			case 2:
				std::cout << "Input filename: ";
				std::cin>>file_plain;
				FileSource(file_plain.data(),true,new StringSink(plain));
				break;
			default:
				std::cout<<"Invalid input";
				std::exit(0);
				break;
		}
		//Enter key
		std::cout <<"Would you like input key from screen or from file?" << std::endl;
		std::cout <<"1. Random Generator\n2. From Screen\n3. From File" << std::endl;
		std::cout <<"Choose 1/2/3: ";
		std::cin >> key_option;
		std::cin.ignore();
		switch(key_option){
			case 1:
				prng.GenerateBlock(key, sizeof(key));
				CryptoPP::StringSource(key, sizeof(key), true, new CryptoPP::FileSink("aes_key.key", sizeof(key)));
				break;
			case 2:
				std::cout<<"Input key: ";
				getline(std::cin, string_key);
				StringSource(string_key, true, new HexDecoder(new CryptoPP::ArraySink(key, sizeof(key))));
				break;
			case 3:
				std::cout<<"Input key filename: ";
				getline(std::cin, file_key);
				CryptoPP::FileSource(file_key.data(), true, new CryptoPP::ArraySink(key,sizeof(key)));
				break;
			default:
				std::cout<<"Invalid input";
				std::exit(0);
				break;
		}
		//if ECB mode
		if(mode_option==1){
			encrypted = ECB_Encrypt(plain, key);
		}
		else {
			//Enter IV
			std::cout <<"Would you like input IV from screen or from file?" << std::endl;
			std::cout <<"1. Random Generator\n2. From Screen\n3. From File" << std::endl;
			std::cout <<"Choose 1/2/3: ";
			std::cin >> iv_option;
			std::cin.ignore();
			switch(key_option){
				case 1:
					prng.GenerateBlock(iv, sizeof(iv));
					CryptoPP::StringSource(iv, sizeof(iv), true, new CryptoPP::FileSink("aes_iv.key", sizeof(iv)));
					break;
				case 2:
					std::cout<<"Input iv: ";
					getline(std::cin, string_iv);
					StringSource(string_iv, true, new HexDecoder(new CryptoPP::ArraySink(iv, sizeof(iv))));
					break;
				case 3:
					std::cout<<"Input iv file name: ";
					getline(std::cin, file_iv);
					CryptoPP::FileSource(file_iv.data(), true, new CryptoPP::ArraySink(iv,sizeof(iv)));
					break;
				default:
					std::cout<<"Invalid input";
					std::exit(0);
					break;
			}

			switch (mode_option){
				case 2:
                    encrypted = CBC_Encrypt(plain, key, iv);
                    break;
                case 3:
                    encrypted = CFB_Encrypt(plain, key, iv);
                    break;
                case 4:
                    encrypted = OFB_Encrypt(plain, key, iv);
                    break;
                case 5:
                    encrypted = CTR_Encrypt(plain, key, iv);
                    break;
                case 6:
                    encrypted = XTS_Encrypt(plain, key, iv);
                    break;
                case 7:
                    encrypted = CCM_Encrypt(plain, key, iv);
                    break;
                case 8:
                    encrypted = GCM_Encrypt(plain, key, iv);
                    break;
			}
		}
			//Encode cipher, key and iv to HEX
            key_encoded.clear();
            StringSource(key, sizeof(key), true, new HexEncoder(
                new StringSink(key_encoded)
                )
            );
            iv_encoded.clear();
            StringSource(iv, sizeof(iv), true, new HexEncoder(
                new StringSink(iv_encoded)
                )
            );
			cipher_encoded.clear();
			StringSource(encrypted, true, new HexEncoder(
                new StringSink(cipher_encoded)
                )
            );
			//Save cipher to file
			StringSource(cipher_encoded, true, new FileSink("cipher.txt"));

            std::cout << "Plaintext: " << plain << std::endl; 
            std::cout << "Key: " << key_encoded << std::endl;
            if (mode_option != 1) {std::cout << "IV: " << iv_encoded << std::endl;}
            std::cout << "Ciphertext: " << cipher_encoded << std::endl;

            //Recover
            std::cout << std::endl << "Would you like to recover this message? (Y/N): ";
            recover_option = getchar();
            if (recover_option == 'Y' || recover_option == 'y') {
				switch (mode_option){
				case 1:
					recovered = ECB_Decrypt(cipher, key);
					break;
				case 2:
                    recovered = CBC_Decrypt(cipher, key, iv);
                    break;
                case 3:
                    recovered = CFB_Decrypt(cipher, key, iv);
                    break;
                case 4:
                    recovered = OFB_Decrypt(cipher, key, iv);
                    break;
                case 5:
                    recovered = CTR_Decrypt(cipher, key, iv);
                    break;
                case 6:
                    recovered = XTS_Decrypt(cipher, key, iv);
                    break;
                case 7:
                    recovered = CCM_Decrypt(cipher, key, iv);
                    break;
                case 8:
                    recovered = GCM_Decrypt(cipher, key, iv);
                    break;
				}
                std::cout << "Recovered Text: " << recovered << std::endl;
            }
            else if (recover_option == 'N' || recover_option == 'n') {

            }
			else {
                std::cout << "Invalid option" << std::endl;
            }
		break;
	//Decrypting	
	case 2:
		std::cout << "Would you like to enter ciphertext from screen or from file" << std::endl;
		std::cout << "1. From Screen\n2. From file: " << std::endl;
		std::cout << "Choose 1/2: ";
		std::cin >> cipher_option;
		if(cipher_option == 1)  {
            std::cout << "Input ciphertext: ";
			std::cin.ignore();
            std::getline(std::cin, ciphertext);
        } else if (cipher_option == 2)
		{
			std::cout << "Input ciphertext filename: ";
			std::cin.ignore();
			std::getline(std::cin, file_cipher);
			CryptoPP::FileSource(file_cipher.data(), true, new StringSink(ciphertext));
		} else { 
			std::cout << "Invalid option" << endl; 
			std::exit(0);
		}

		StringSource(ciphertext, true, new HexDecoder(new StringSink(hex_cipher)));

		std::cout <<"Would you like input key from screen or from file?" << std::endl;
		std::cout <<"1. From Screen\n2. From File" << std::endl;
		std::cout <<"Choose 1/2: ";
		std::cin >> key_option;
		std::cin.ignore();
		switch(key_option){
			case 1:
				std::cout<<"Input key: ";
				getline(std::cin, string_key);
				StringSource(string_key, true, new HexDecoder(new CryptoPP::ArraySink(key, sizeof(key))));
				break;
			case 2:
				std::cout<<"Input key filename: ";
				getline(std::cin, file_key);
				CryptoPP::FileSource(file_key.data(), true, new CryptoPP::ArraySink(key,sizeof(key)));
				break;
			default:
				std::cout<<"Invalid input";
				std::exit(0);
				break;
		}
		//if ECB mode
		if (mode_option == 1) {
            plain = ECB_Decrypt(hex_cipher, key);
        }else {
			std::cout <<"Would you like input IV from screen or from file?" << std::endl;
			std::cout <<"1. From Screen\n2. From File" << std::endl;
			std::cout <<"Choose 1/2: ";
			std::cin >> iv_option;
			std::cin.ignore();
			switch(key_option){
				case 1:
					std::cout<<"Input iv: ";
					getline(std::cin, string_iv);
					StringSource(string_iv, true, new HexDecoder(new CryptoPP::ArraySink(iv, sizeof(iv))));
					break;
				case 2:
					std::cout<<"Input iv file name: ";
					getline(std::cin, file_iv);
					CryptoPP::FileSource(file_iv.data(), true, new CryptoPP::ArraySink(iv,sizeof(iv)));
					break;
				default:
					std::cout<<"Invalid input";
					std::exit(0);
					break;
			}
		}
		switch (mode_option){
				case 2:
                    plain = CBC_Decrypt(hex_cipher, key, iv);
                    break;
                case 3:
                    plain = CFB_Decrypt(hex_cipher, key, iv);
                    break;
                case 4:
                    plain = OFB_Decrypt(hex_cipher, key, iv);
                    break;
                case 5:
                    plain = CTR_Decrypt(hex_cipher, key, iv);
                    break;
                case 6:
                    plain = XTS_Decrypt(hex_cipher, key, iv);
                    break;
                case 7:
                    plain = CCM_Decrypt(hex_cipher, key, iv);
                    break;
                case 8:
                    plain = GCM_Decrypt(hex_cipher, key, iv);
                    break;
		}
		std::cout << "Plaintext: " << plain << std::endl;	
		break;
	default:
		std::cout << "Invalid option";
		std::exit(0);
		break;
	}
	//Running time
	std::cout << "Please wait for compute running time !" << std::endl;
    if(action_option == 1){
		auto start = std::chrono::high_resolution_clock::now();
        for (int i = 0; i < 10000; ++i) {
			switch (mode_option){
			case 1:
				ECB_Encrypt(plain, key);
				break;
			case 2:
                CBC_Encrypt(plain, key, iv);
                break;
            case 3:
                CFB_Encrypt(plain, key, iv);
                break;
            case 4:
                OFB_Encrypt(plain, key, iv);
                break;
            case 5:
                CTR_Encrypt(plain, key, iv);
                break;
            case 6:
                XTS_Encrypt(plain, key, iv);
                break;
            case 7:
                CCM_Encrypt(plain, key, iv);
                break;
            case 8:
                GCM_Encrypt(plain, key, iv);
                break;
			}
			std::cout << "loop " << i << std::endl;
		}
	auto end = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
	double averageTime = static_cast<double>(duration) / 10000.0;
    std::cout << "Average time for encryption over 10000 rounds: " << averageTime << " ms" << std::endl;
	} else if(action_option == 2){
		auto start = std::chrono::high_resolution_clock::now();
		for (int i = 0; i < 10000; ++i) {
			switch (mode_option){
			case 1:
				ECB_Decrypt(hex_cipher, key);
				break;
			case 2:
                CBC_Decrypt(hex_cipher, key, iv);
                break;
            case 3:
                CFB_Decrypt(hex_cipher, key, iv);
                break;
            case 4:
                OFB_Decrypt(hex_cipher, key, iv);
                break;
            case 5:
                CTR_Decrypt(hex_cipher, key, iv);
                break;
            case 6:
                XTS_Decrypt(hex_cipher, key, iv);
                break;
            case 7:
                CCM_Decrypt(hex_cipher, key, iv);
                break;
            case 8:
                GCM_Decrypt(hex_cipher, key, iv);
                break;
			}
			std::cout << "loop " << i << std::endl;
		}	
	auto end = std::chrono::high_resolution_clock::now();
    auto duration = std::chrono::duration_cast<std::chrono::milliseconds>(end - start).count();
	double averageTime = static_cast<double>(duration) / 10000.0;
    std::cout << "Average time for decryption over 10000 rounds: " << averageTime << " ms" << std::endl;
    }
	return 0;
}
