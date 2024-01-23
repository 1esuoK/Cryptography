// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

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
#include "sha3.h"
#include "shake.h"
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

#include "queue.h"
using CryptoPP::ByteQueue;

#include "cryptlib.h"
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
#include <fstream>
#include <sstream>

//Vietnamese on Windows
#include <chrono>
#ifdef _WIN32
#include <windows.h>
#endif
#include <locale>
#include <cstdlib>
#include <cctype>


extern "C" {
    __declspec(dllexport) char** hashFunc(const char* hashAlgo, const char* hashFile);
    __declspec(dllexport) void clearArray(char** p, int size);
}

string ToHex(CryptoPP::Integer value) {
    std::stringstream ss;
    ss << std::hex << value;
    return ss.str();
}
string ToString(CryptoPP::Integer val) {
    std::stringstream ss;
    ss << val;
    string str = ss.str();
    return str;
}

char** hashFunc(const char* hashAlgo, const char* hashFile)
{
    // Determine hash algorithm
    std::unique_ptr<CryptoPP::HashTransformation> hash;
    if (string(hashAlgo) == "SHA3_224") {
        hash.reset(new CryptoPP::SHA3_224);
    }
    else if (string(hashAlgo) == "SHA3_256") {
        hash.reset(new CryptoPP::SHA3_256);
    }
    else if (string(hashAlgo) == "SHA3_384") {
        hash.reset(new CryptoPP::SHA3_384);
    }
    else if (string(hashAlgo) == "SHA3_512") {
        hash.reset(new CryptoPP::SHA3_512);
    }
    else if (string(hashAlgo) == "SHA224") {
        hash.reset(new CryptoPP::SHA224);
    }
    else if (string(hashAlgo) == "SHA256") {
        hash.reset(new CryptoPP::SHA256);
    }
    else if (string(hashAlgo) == "SHA384") {
        hash.reset(new CryptoPP::SHA384);
    }
    else if (string(hashAlgo) == "SHA512") {
        hash.reset(new CryptoPP::SHA512);
    }
    else if (string(hashAlgo) == "SHAKE128") {
        hash.reset(new CryptoPP::SHAKE128);
    }
    else if (string(hashAlgo) == "SHAKE256") {
        hash.reset(new CryptoPP::SHAKE256);
    }
       
    char** result = new char* [4];
    
    //Get Algo Name
    result[0] = new char[hash->AlgorithmName().size() + 1];
    memcpy(result[0], hash->AlgorithmName().c_str(), hash->AlgorithmName().size() + 1);

    //Get DigestSize
    result[1] = new char[hash->DigestSize()];
    memcpy(result[1], ToString(hash->DigestSize()).c_str(), hash->DigestSize());

    
    //Get BlockSize
    result[2] = new char[hash->BlockSize()];
    memcpy(result[2], ToString(hash->BlockSize()).c_str(), hash->BlockSize());


       
    std::string digest;
    FileSource(hashFile, true, new CryptoPP::HashFilter(*hash, new StringSink(digest)));;

    //Get Message
    //result[3] = new char[message.size() + 1];
    //memcpy(result[3], message.c_str(), message.size() + 1);
    
    //Get Digest
    std::string encode;
    encode.clear();
    StringSource ss(digest, true, new HexEncoder(new StringSink(encode)));
    //Get digest value
    result[3] = new char[encode.size() + 1];
    memcpy(result[3], encode.c_str(), encode.size() + 1);
    

    return result;
}

void clearArray(char** p, int size) {
    for (int i = 0; i < size; i++) {
        delete[] p[i];
    }

    delete[] p;
}

int main(int argc, char* argv[])
{
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);

    if (argc != 3) {
        std::cerr << "Usage: " << argv[0] << " <hash_type> <filename>" << std::endl;
        std::cerr << "Hash types: SHA224, SHA256, SHA384, SHA512, SHA3_224, SHA3_256, SHA3_384, SHA3_512, SHAKE128, SHAKE256" << std::endl;
        return 1;
    }

    return 0;
}