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
#include "cryptopp/sha3.h"
#include "cryptopp/shake.h"
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

#include "cryptopp/queue.h"
using CryptoPP::ByteQueue;

#include "cryptopp/cryptlib.h"
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

//Vietnamese on Windows
#include <chrono>
#ifdef _WIN32
#include <windows.h>
#endif
#include <locale>
#include <cstdlib>
#include <cctype>

int main (int argc, char* argv[])
{
    #ifdef __linux__
    std::locale::global(std::locale("C.utf8"));
    #endif
        
    #ifdef _WIN32
    // Set console code page to UTF-8 on Windows
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
    #endif

    if (argc != 3) {
        std::cerr << "Usage: " << argv[0] << " <hash_type> <filename>" << std::endl; 
        std::cerr << "Hash types: SHA224, SHA256, SHA384, SHA512, SHA3_224, SHA3_256, SHA3_384, SHA3_512, SHAKE128, SHAKE256" << std::endl;
        return 1;
    }

    // Determine hash algorithm
    std::unique_ptr<CryptoPP::HashTransformation> hash;
    if (string(argv[1]) == "SHA3_224") {
        hash.reset(new CryptoPP::SHA3_224);
    } else if (string(argv[1]) == "SHA3_256") {
        hash.reset(new CryptoPP::SHA3_256);
    } else if (string(argv[1]) == "SHA3_384") {
        hash.reset(new CryptoPP::SHA3_384);
    } else if (string(argv[1]) == "SHA3_512") {
        hash.reset(new CryptoPP::SHA3_512);
    } else if (string(argv[1]) == "SHA224") {
        hash.reset(new CryptoPP::SHA224);
    } else if (string(argv[1]) == "SHA256") {
        hash.reset(new CryptoPP::SHA256);
    } else if (string(argv[1]) == "SHA384") {
        hash.reset(new CryptoPP::SHA384);
    } else if (string(argv[1]) == "SHA512") {
        hash.reset(new CryptoPP::SHA512);
    } else if (string(argv[1]) == "SHAKE128") {
        hash.reset(new CryptoPP::SHAKE128);
    } else if (string(argv[1]) == "SHAKE256") {
        hash.reset(new CryptoPP::SHAKE256);
    } else {
        std::cerr << "Invalid hash type: " << argv[1] << std::endl;
        return 1;
    }

    std::cout << "Name: " << hash->AlgorithmName() << std::endl;
    std::cout << "Digest size: " << hash->DigestSize() << std::endl;
    std::cout << "Block size: " << hash->BlockSize() << std::endl;
    
    // Open file
    std::ifstream file(argv[2],std::ios::binary);
    if (!file) {
        std::cerr << "Error opening file: " << argv[2] << std::endl;
        return 1;
    }
 
    // Read content from file
    std::string message((std::istreambuf_iterator<char>(file)), std::istreambuf_iterator<char>());
    
    //Input message
    //std::cout << "Input message: ";
    //std::getline(std::cin, message);
    
    //Compute Digest
    std::string digest;
    hash->Restart();
    hash->Update((const CryptoPP::byte*)message.data(), message.size());
    digest.resize(hash->DigestSize());
    hash->TruncatedFinal((CryptoPP::byte*)&digest[0], digest.size());
    //Pretty print digest
    std::cout << "Message: " << message << std::endl;
    std::cout << "Digest: ";
    std::string encode;
    encode.clear();
    StringSource ss(digest, true, new HexEncoder(new StringSink(encode)));
    std::cout << encode << std::endl;
    //Hash to Z_p
    string wdigest=encode+"H";
    CryptoPP::Integer idigest((const byte*)wdigest.data(), wdigest.size());
    CryptoPP::Integer p("0051953EB9618E1C9A1F929A21A0B68540EEA2DA725B99B315F3B8B489918EF109E156193951EC7E937B1652C0BD3BB1BF073573DF883D2C34F1EF451FD46B503F00h");
    std::cout << "Prime number p for Z_p: " << p << std::endl;
    std::cout << "Hash digest in Z_p: " << idigest % p << std::endl;
    return 0; 
}