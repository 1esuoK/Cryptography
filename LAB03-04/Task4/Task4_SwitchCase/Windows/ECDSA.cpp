// ECDSA.KeyGen.cpp : Defines the entry point for the console application.
//

#include <assert.h>

//Vietnamese on Windows
#include <chrono>
#ifdef _WIN32
#include <windows.h>
#endif
#include <locale>
#include <cstdlib>
#include <cctype>

#include <iostream>
using std::cout;
using std::endl;

#include <string>
using std::string;

#include "cryptopp/osrng.h"
// using CryptoPP::AutoSeededX917RNG;
using CryptoPP::AutoSeededRandomPool;

#include "cryptopp/aes.h"
using CryptoPP::AES;

#include "cryptopp/integer.h"
using CryptoPP::Integer;

#include "cryptopp/sha.h"
using CryptoPP::SHA1;

#include "cryptopp/filters.h"
using CryptoPP::StringSource;
using CryptoPP::StringSink;
using CryptoPP::ArraySink;
using CryptoPP::SignerFilter;
using CryptoPP::SignatureVerificationFilter;

#include "cryptopp/files.h"
using CryptoPP::FileSource;
using CryptoPP::FileSink;

#include "cryptopp/eccrypto.h"
using CryptoPP::ECDSA;
using CryptoPP::ECP;
using CryptoPP::DL_GroupParameters_EC;

// #if _MSC_VER <= 1200 // VS 6.0
// using CryptoPP::ECDSA<ECP, SHA1>;
// using CryptoPP::DL_GroupParameters_EC<ECP>;
// #endif

#include "cryptopp/oids.h"
using CryptoPP::OID;

bool GeneratePrivateKey( const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key );
bool GeneratePublicKey( const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey );

void SavePrivateKey( const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key );
void SavePublicKey( const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key );
void LoadPrivateKey( const string& filename, ECDSA<ECP, SHA1>::PrivateKey& key );
void LoadPublicKey( const string& filename, ECDSA<ECP, SHA1>::PublicKey& key );

void PrintDomainParameters( const ECDSA<ECP, SHA1>::PrivateKey& key );
void PrintDomainParameters( const ECDSA<ECP, SHA1>::PublicKey& key );
void PrintDomainParameters( const DL_GroupParameters_EC<ECP>& params );
void PrintPrivateKey( const ECDSA<ECP, SHA1>::PrivateKey& key );
void PrintPublicKey( const ECDSA<ECP, SHA1>::PublicKey& key );

bool SignMessage( const ECDSA<ECP, SHA1>::PrivateKey& key, const string& message, string& signature );
bool VerifyMessage( const ECDSA<ECP, SHA1>::PublicKey& key, const string& message, const string& signature );

//////////////////////////////////////////
// In 2010, use SHA-256 and P-256 curve
//////////////////////////////////////////

int main(int argc, char* argv[])
{   
    #ifdef __linux__
        std::locale::global(std::locale("C.utf8"));
    #endif
        
     #ifdef _WIN32
        // Set console code page to UTF-8 on Windows
        SetConsoleOutputCP(CP_UTF8);
        SetConsoleCP(CP_UTF8);
    #endif
    
    bool result = false;   
    int action_option;
    string signature, file_message, message;
    
    // Private and Public keys
    ECDSA<ECP, SHA1>::PrivateKey privateKey;
    ECDSA<ECP, SHA1>::PublicKey publicKey;
    
    std::cout << "Which action would you like to perform ?\n";
    std::cout <<"1. Key Generation\n2. Sign\n3. Verify\n";
    std::cout <<"Choose (1/2/3): ";
    std::cin >> action_option;

    switch (action_option)
    {
        // Generate Keys
        case 1:
             // Private and Public keys
            result = GeneratePrivateKey( CryptoPP::ASN1::secp160r1(), privateKey );
            assert( true == result );
            if( !result ) { return -1; }

            result = GeneratePublicKey( privateKey, publicKey );
            assert( true == result );
            if( !result ) { return -2; }
            
            // Print Domain Parameters and Keys 
            PrintDomainParameters( publicKey );
            PrintPrivateKey( privateKey );
            PrintPublicKey( publicKey );

            // Save key in PKCS#9 and X.509 format    
            SavePrivateKey( "ec.private.der", privateKey );
            SavePublicKey( "ec.public.der", publicKey );
            break;
        case 2:
        {
            std::cout<< "Enter message filename: ";
            std::cin>>file_message;
			FileSource(file_message.data(),true,new StringSink(message));
            // Load key in PKCS#9 and X.509 format     
            LoadPrivateKey( "ec.private.der", privateKey );
            LoadPublicKey( "ec.public.der", publicKey );
            
            //sign
            result = SignMessage( privateKey, message, signature );
            if(result){
                std::cout<< "Signed Succesfully!" << std::endl;
            }else{
                std::cout<< "Failed to Sign" << std::endl;
            }

            //save signature to file
            StringSource s(signature, true, new FileSink("signature.txt"));
            break;
        }
        case 3:
        {
            std::cout<< "Enter message filename: ";
            std::cin>>file_message;
			FileSource(file_message.data(),true,new StringSink(message));
            // Load key in PKCS#9 and X.509 format     
            LoadPrivateKey( "ec.private.der", privateKey );
            LoadPublicKey( "ec.public.der", publicKey );

            //Load signature from file
            #ifdef _WIN32
                FileSource fsign("signature.txt", true, new StringSink(signature));
            #elif __linux__
                FileSource fsign("./signature.txt", true, new StringSink(signature));
            #endif

            //verify
            result = VerifyMessage( publicKey, message, signature );
            if(result){
                std::cout<< "Verified Succesfully!" << std::endl;
            }else{
                std::cout<< "Failed to Verify" << std::endl;
            }
            break;
        }
        default:
            std::cout << "Invalid Option !";
            std::exit(0);
            break;
    }
    /////////////////////////////////////////////
    // Generate Keys

    
    /////////////////////////////////////////////
    // Print Domain Parameters and Keys   

    /////////////////////////////////////////////
    // Save key in PKCS#9 and X.509 format    
    //SavePrivateKey( "ec.private.key", privateKey );
    //SavePublicKey( "ec.public.key", publicKey );
    
    /////////////////////////////////////////////
    // Load key in PKCS#9 and X.509 format     
    //LoadPrivateKey( "ec.private.key", privateKey );
    //LoadPublicKey( "ec.public.key", publicKey );

    /////////////////////////////////////////////
    // Print Domain Parameters and Keys    
    // PrintDomainParameters( publicKey );
    // PrintPrivateKey( privateKey );
    // PrintPublicKey( publicKey );
        
    /////////////////////////////////////////////
    // Sign and Verify a message      

    return 0;
}

bool GeneratePrivateKey( const OID& oid, ECDSA<ECP, SHA1>::PrivateKey& key )
{
    AutoSeededRandomPool prng;

    key.Initialize( prng, oid );
    assert( key.Validate( prng, 3 ) );
     
    return key.Validate( prng, 3 );
}

bool GeneratePublicKey( const ECDSA<ECP, SHA1>::PrivateKey& privateKey, ECDSA<ECP, SHA1>::PublicKey& publicKey )
{
    AutoSeededRandomPool prng;

    // Sanity check
    assert( privateKey.Validate( prng, 3 ) );

    privateKey.MakePublicKey(publicKey);
    assert( publicKey.Validate( prng, 3 ) );

    return publicKey.Validate( prng, 3 );
}

void PrintDomainParameters( const ECDSA<ECP, SHA1>::PrivateKey& key )
{
    PrintDomainParameters( key.GetGroupParameters() );
}

void PrintDomainParameters( const ECDSA<ECP, SHA1>::PublicKey& key )
{
    PrintDomainParameters( key.GetGroupParameters() );
}

void PrintDomainParameters( const DL_GroupParameters_EC<ECP>& params )
{
    cout << endl;
 
    cout << "Modulus:" << endl;
    cout << " " << params.GetCurve().GetField().GetModulus() << endl;
    
    cout << "Coefficient A:" << endl;
    cout << " " << params.GetCurve().GetA() << endl;
    
    cout << "Coefficient B:" << endl;
    cout << " " << params.GetCurve().GetB() << endl;
    
    cout << "Base Point:" << endl;
    cout << " X: " << params.GetSubgroupGenerator().x << endl; 
    cout << " Y: " << params.GetSubgroupGenerator().y << endl;
    
    cout << "Subgroup Order:" << endl;
    cout << " " << params.GetSubgroupOrder() << endl;
    
    cout << "Cofactor:" << endl;
    cout << " " << params.GetCofactor() << endl;    
}

void PrintPrivateKey( const ECDSA<ECP, SHA1>::PrivateKey& key )
{   
    cout << endl;
    cout << "Private Exponent:" << endl;
    cout << " " << key.GetPrivateExponent() << endl; 
}

void PrintPublicKey( const ECDSA<ECP, SHA1>::PublicKey& key )
{   
    cout << endl;
    cout << "Public Element:" << endl;
    cout << " X: " << key.GetPublicElement().x << endl; 
    cout << " Y: " << key.GetPublicElement().y << endl;
}

void SavePrivateKey( const string& filename, const ECDSA<ECP, SHA1>::PrivateKey& key )
{
    key.Save( FileSink( filename.c_str(), true /*binary*/ ).Ref() );
}

void SavePublicKey( const string& filename, const ECDSA<ECP, SHA1>::PublicKey& key )
{   
    key.Save( FileSink( filename.c_str(), true /*binary*/ ).Ref() );
}

void LoadPrivateKey( const string& filename, ECDSA<ECP, SHA1>::PrivateKey& key )
{   
    key.Load( FileSource( filename.c_str(), true /*pump all*/ ).Ref() );
}

void LoadPublicKey( const string& filename, ECDSA<ECP, SHA1>::PublicKey& key )
{
    key.Load( FileSource( filename.c_str(), true /*pump all*/ ).Ref() );
}

bool SignMessage( const ECDSA<ECP, SHA1>::PrivateKey& key, const string& message, string& signature )
{
    AutoSeededRandomPool prng;
    
    signature.erase();    

    StringSource( message, true,
        new SignerFilter( prng,
            ECDSA<ECP,SHA1>::Signer(key),
            new StringSink( signature )
        ) // SignerFilter
    ); // StringSource
    
    return !signature.empty();
}

bool VerifyMessage( const ECDSA<ECP, SHA1>::PublicKey& key, const string& message, const string& signature )
{
    bool result = false;

    StringSource( signature+message, true,
        new SignatureVerificationFilter(
            ECDSA<ECP,SHA1>::Verifier(key),
            new ArraySink( (CryptoPP::byte*)&result, sizeof(result) )
        ) // SignatureVerificationFilter
    );

    return result;
}
