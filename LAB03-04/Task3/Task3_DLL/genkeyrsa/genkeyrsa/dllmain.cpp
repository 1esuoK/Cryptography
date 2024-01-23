// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

// Sample.cpp


#include "hex.h"
using CryptoPP::HexEncoder;
using CryptoPP::HexDecoder;

#include "base64.h"
using CryptoPP::Base64Encoder;
using CryptoPP::Base64Decoder;

#include "rsa.h"
using CryptoPP::RSA;
using CryptoPP::InvertibleRSAFunction;
using CryptoPP::RSAES_OAEP_SHA_Encryptor;
using CryptoPP::RSAES_OAEP_SHA_Decryptor;

#include "sha.h"
using CryptoPP::SHA1;
using CryptoPP::SHA256;

#include "filters.h"
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::PK_EncryptorFilter;
using CryptoPP::PK_DecryptorFilter;

#include "files.h"
using CryptoPP::FileSink;
using CryptoPP::FileSource;

#include "osrng.h"
using CryptoPP::AutoSeededRandomPool;

#include "secblock.h"
using CryptoPP::SecByteBlock;

#include <queue.h>
using CryptoPP::ByteQueue;

#include <cryptlib.h>
using CryptoPP::Exception;
using CryptoPP::DecodingResult;
using CryptoPP::PrivateKey;
using CryptoPP::PublicKey;
using CryptoPP::BufferedTransformation;

#include "pem.h"
using CryptoPP::PEM_Save;

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



extern "C" {
    __declspec(dllexport) bool genKey(const char* privateKeyPath, const char* publicKeyPath, const char*& n, const char*& p, const char*& q, const char*& d, const char*& e);
    __declspec(dllexport) const char* encryptRSA(const char* publicKeyPath, const char* plainPath, const char* cipherPath);
    __declspec(dllexport) const char* decryptRSA(const char* privateKeyPath, const char* cipherPath, const char* plainPath);
    __declspec(dllexport) void freeCipherData(char* p);
}


//Save to file from buffer
void Save(const string& filename, const BufferedTransformation& bt)
{
    FileSink file(filename.c_str());

    bt.CopyTo(file);    
    file.MessageEnd();
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

//Load from file to buffer
void Load(const string& filename, BufferedTransformation& bt)
{
    FileSource file(filename.c_str(), true /*pumpAll*/);

    file.TransferTo(bt);
    bt.MessageEnd();
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
char* NumberToHexStr(CryptoPP::Integer number) {
    std::stringstream stream;
    stream << std::hex << number;
    std::string hexString = stream.str();

    char* result = new char[hexString.length() + 1];
    memcpy(result, hexString.c_str(),hexString.length()+1);
    return result;
}

bool genKey(const char* privateKeyPath, const char* publicKeyPath, const char*& n, const char*& p, const char*& q, const char*& d, const char*& e)
{
    AutoSeededRandomPool rng;
    //Private key
    RSA::PrivateKey rsaPrivate;
    rsaPrivate.GenerateRandomWithKeySize(rng, 3072);
    //Public key
    RSA::PublicKey rsaPublic(rsaPrivate);

    /*std::cout << "Module n: " << std::hex << rsaPrivate.GetModulus() << std::endl;
    std::cout << "Prime number p: " << std::hex << rsaPrivate.GetPrime1() << std::endl;
    std::cout << "Prime number q: " << std::hex << rsaPrivate.GetPrime2() << std::endl;
    std::cout << "Private key d: " << std::hex << rsaPrivate.GetPrivateExponent() << std::endl;
    std::cout << "Public exponent e = " << std::hex << rsaPrivate.GetPublicExponent() << std::endl;*/

    n = NumberToHexStr(rsaPrivate.GetModulus());
    p = NumberToHexStr(rsaPrivate.GetPrime1()); 
    q = NumberToHexStr(rsaPrivate.GetPrime2());
    d = NumberToHexStr(rsaPrivate.GetPrivateExponent());
    e = NumberToHexStr(rsaPrivate.GetPublicExponent());

    /* Save keys to files */
    /* DER Format */
    std::string pubDer = std::string(publicKeyPath) + ".der";
    std::string prvDer = std::string(privateKeyPath) + ".der";
    EncodePublicKey(pubDer.c_str(), rsaPublic);
    EncodePrivateKey(prvDer.c_str(), rsaPrivate);

    /* PEM Format */
    std::string pubPem = std::string(publicKeyPath) + ".pem";
    std::string prvPem = std::string(privateKeyPath) + ".pem";
    FileSink pemPubFile(pubPem.c_str(), true);
    FileSink pemPrvFile(prvPem.c_str(), true);
    PEM_Save(pemPubFile, rsaPublic);
    PEM_Save(pemPrvFile, rsaPrivate);

    std::cout << "Successfully generated and saved RSA keys" << std::endl;
    return true;
}

const char* encryptRSA(const char* publicKeyPath, const char* plainPath, const char* cipherPath)
{
    AutoSeededRandomPool rng;
    // Load PublicKey
    RSA::PublicKey publicKey;
    DecodePublicKey(publicKeyPath, publicKey);
    RSAES_OAEP_SHA_Encryptor e(publicKey);
    string plain, cipher, encoded;
    
    std::string plainFile = std::string(plainPath);
    std::string cipherFile = std::string(cipherPath);

    FileSource(plainFile.data(), true, new StringSink(plain));

    // Encryption
    StringSource(plain, true,
        new PK_EncryptorFilter(rng, e,
            new StringSink(cipher)) // PK_EncryptorFilter
    );                                                          // StringSource
    
    StringSource(cipher, true, new HexEncoder(new StringSink(encoded)));
    //Save cipher to file
    StringSource(encoded, true, new FileSink(cipherFile.c_str()));

    int len = strlen(encoded.c_str());
    char* getCipher = new char[len + 1];
    memcpy(getCipher, encoded.c_str(), len + 1);
    return getCipher;
}
const char* decryptRSA(const char* privateKeyPath, const char* cipherPath, const char* plainPath)
{
    AutoSeededRandomPool rng;
    string hex_cipher, recovered, cipher;
    // Load PrivateKey
    RSA::PrivateKey privateKey;
    DecodePrivateKey(privateKeyPath, privateKey);
    RSAES_OAEP_SHA_Decryptor d(privateKey);

    std::string plainFile = std::string(plainPath);
    std::string cipherFile = std::string(cipherPath);

    FileSource(cipherFile.data(), true, new StringSink(hex_cipher));
    //Decode hex cipher to binary string
    StringSource(hex_cipher, true, new HexDecoder(new StringSink(cipher)));

    //Decryption
    StringSource(cipher, true,
        new PK_DecryptorFilter(rng, d,
            new StringSink(recovered)
        ) // PK_EncryptorFilter
    ); // StringSource
    StringSource(recovered, true, new FileSink(plainFile.c_str()));

    int len = strlen(recovered.c_str());
    char* getPlain = new char[len + 1];
    memcpy(getPlain, recovered.c_str(), len + 1);
    return getPlain;
}
void freeCipherData(char* p)
{
    delete[] p;
}

int main(int argc, char* argv[])
{
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    /*if (argc != 3) {
        std::cerr << "Usage: " << argv[0] << " <private key file> <public key file>" << std::endl;
        return 1;
    }
    const char* privateKeyPath = argv[1];
    const char* publicKeyPath = argv[2];
    if (genKey(privateKeyPath, publicKeyPath)) {
        std::cout << "Key pair generated successfully." << std::endl;
    }
    else {
        std::cout << "Failed to generate key pair." << std::endl;
    }*/
    return 0;
}





