// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"

//digital-sign-1.cpp
#include <openssl/evp.h>
#include <openssl/pem.h>
#include <openssl/err.h>
#include <openssl/sha.h> // Include for SHA256
#include <iostream>
#include <fstream>
#include <vector> // Include for std::vector
#include <iterator> // Include for std::istreambuf_iterator
extern "C" {
    __declspec(dllexport) bool genKey(const char* privateKeyPath, const char* publicKeyPath);
    __declspec(dllexport) bool signPdf(const char* privateKeyPath, const char* pdfPath, const char* signaturePath);
    __declspec(dllexport) bool verifySignature(const char* publicKeyPath, const char* pdfPath, const char* signaturePath);
}

bool genKey(const char* privateKeyPath, const char* publicKeyPath) {
    std::string privateKeyCommand = "openssl ecparam -name prime256v1 -genkey -noout -out ";
    privateKeyCommand += privateKeyPath;

    std::string publicKeyCommand = "openssl ec -in ";
    publicKeyCommand += privateKeyPath;
    publicKeyCommand += " -pubout -out ";
    publicKeyCommand += publicKeyPath;

    int privateKeyResult = system(privateKeyCommand.c_str());
    int publicKeyResult = system(publicKeyCommand.c_str());

    return (privateKeyResult == 0 && publicKeyResult == 0);
}
bool signPdf(const char* privateKeyPath, const char* pdfPath, const char* signaturePath) {
    OpenSSL_add_all_algorithms();
    ERR_load_crypto_strings();
    // Read the private key
    BIO* bio = BIO_new(BIO_s_file());
    BIO_read_filename(bio, privateKeyPath);
    EVP_PKEY* privateKey = PEM_read_bio_PrivateKey(bio, NULL, NULL, NULL);
    BIO_free(bio);
    if (!privateKey) {
        std::cerr << "Error reading private key." << std::endl;
        ERR_print_errors_fp(stderr);
        return false;
    }

    // Create a buffer to hold the document hash
    unsigned char hash[SHA256_DIGEST_LENGTH];
    std::ifstream pdfFile(pdfPath, std::ios::binary);
    if (!pdfFile.is_open()) {
        std::cerr << "Error opening PDF file." << std::endl;
        return false;
    }
    std::vector<unsigned char> pdfContents((std::istreambuf_iterator<char>(pdfFile)), std::istreambuf_iterator<char>());
    pdfFile.close();

    // Hash the PDF
    std::cout << "Hashing the PDF" << std::endl;
    SHA256(&pdfContents[0], pdfContents.size(), hash);

    // Sign the hash
    std::cout << "Signing the hash" << std::endl;
    EVP_MD_CTX* mdCtx = EVP_MD_CTX_new();
    EVP_SignInit(mdCtx, EVP_sha256());
    EVP_SignUpdate(mdCtx, hash, SHA256_DIGEST_LENGTH);

    unsigned int signatureLen = EVP_PKEY_size(privateKey);
    std::vector<unsigned char> signature(signatureLen);
    if (!EVP_SignFinal(mdCtx, &signature[0], &signatureLen, privateKey)) {
        std::cerr << "Error signing PDF." << std::endl;
        EVP_MD_CTX_free(mdCtx);
        EVP_PKEY_free(privateKey);
        return false;
    }
    // Write the signature to a file
    std::cout << "Writing the signature to file: " << signaturePath << std::endl;
    std::ofstream signatureFile(signaturePath, std::ios::binary);
    if (!signatureFile.is_open()) {
        std::cerr << "Error opening signature file." << std::endl;
        return false;
    }
    signatureFile.write(reinterpret_cast<const char*>(&signature[0]), signatureLen);
    signatureFile.close();
    // Clean up
    EVP_MD_CTX_free(mdCtx);
    EVP_PKEY_free(privateKey);
    EVP_cleanup();
    ERR_free_strings();
    return true;
}
bool verifySignature(const char* publicKeyPath, const char* pdfPath, const char* signaturePath) {
    // Load the public key using BIO
    BIO* bio = BIO_new(BIO_s_file());
    if (BIO_read_filename(bio, publicKeyPath) <= 0) {
        std::cerr << "Error opening public key file." << std::endl;
        BIO_free(bio);
        return false;
    }
    EVP_PKEY* publicKey = PEM_read_bio_PUBKEY(bio, NULL, NULL, NULL);
    BIO_free(bio);

    if (!publicKey) {
        std::cerr << "Error loading public key." << std::endl;
        return false;
    }

    // Load the PDF
    std::ifstream pdfFile(pdfPath, std::ios::binary);
    std::vector<unsigned char> pdfContents((std::istreambuf_iterator<char>(pdfFile)), std::istreambuf_iterator<char>());
    pdfFile.close();

    // Create a buffer to hold the document hash
    unsigned char hash[SHA256_DIGEST_LENGTH];
    SHA256(&pdfContents[0], pdfContents.size(), hash);

    // Load the signature
    std::ifstream signatureFile(signaturePath, std::ios::binary);
    std::vector<unsigned char> signature(std::istreambuf_iterator<char>(signatureFile), {});
    signatureFile.close();

    // Verify the signature
    EVP_MD_CTX* mdCtx = EVP_MD_CTX_new();
    EVP_DigestVerifyInit(mdCtx, NULL, EVP_sha256(), NULL, publicKey);
    EVP_DigestVerifyUpdate(mdCtx, hash, SHA256_DIGEST_LENGTH);
    int result = EVP_DigestVerifyFinal(mdCtx, &signature[0], signature.size());

    // Clean up
    EVP_MD_CTX_free(mdCtx);
    EVP_PKEY_free(publicKey);

    return result == 1;
}

int main(int argc, char* argv[]) {
    /*if (argc != 4) {
        std::cerr << "Usage: " << argv[0] << " <private key file> <PDF file> <signature output file>" << std::endl;
        return 1;
    }
    const char* privateKeyPath = argv[1];
    const char* pdfPath = argv[2];
    const char* signaturePath = argv[3];
    if (signPdf(privateKeyPath, pdfPath, signaturePath)) {
        std::cout << "PDF signed successfully." << std::endl;
    }
    else {
        std::cout << "Failed to sign PDF." << std::endl;
    }*/
    return 0;
}


