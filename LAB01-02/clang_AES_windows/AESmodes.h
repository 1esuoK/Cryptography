#include <cstdlib>
#include <string>
#include <string>

#include <cryptopp/osrng.h>
using CryptoPP::AutoSeededRandomPool;

#include <cryptopp/cryptlib.h>
using CryptoPP::Exception;

#include <cryptopp/hex.h>
using CryptoPP::HexDecoder;
using CryptoPP::HexEncoder;

#include <cryptopp/filters.h>
using CryptoPP::ArraySink;
using CryptoPP::ArraySource;
using CryptoPP::StreamTransformationFilter;
using CryptoPP::StringSink;
using CryptoPP::StringSource;
using CryptoPP::AuthenticatedEncryptionFilter;
using CryptoPP::AuthenticatedDecryptionFilter;
using CryptoPP::Redirector;

#include <cryptopp/files.h>
using CryptoPP::FileSource;
using CryptoPP::FileSink;

#include <cryptopp/aes.h>
using CryptoPP::AES;

#include <cryptopp/ccm.h>
using CryptoPP::ECB_Mode;
using CryptoPP::CBC_Mode;
using CryptoPP::CFB_Mode;
using CryptoPP::OFB_Mode;
using CryptoPP::CTR_Mode;
using CryptoPP::CCM;

#include <cryptopp/xts.h>
#include <cryptopp/gcm.h>
using CryptoPP::GCM;


#include <cryptopp/config_int.h>
using CryptoPP::byte;

std::string cipher, recovered;

std::string ECB_Encrypt(std::string plain, CryptoPP::byte *key) {
    try {
        ECB_Mode< AES >::Encryption e;
        e.SetKey(key, AES::DEFAULT_KEYLENGTH);
        StringSource(plain, true, new StreamTransformationFilter(
            e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }
    return cipher;
}

std::string ECB_Decrypt(std::string cipher, CryptoPP::byte *key) {
    try {
        
        ECB_Mode<AES>::Decryption d;
        d.SetKey(key, AES::DEFAULT_KEYLENGTH);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered)
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }
    return recovered;
}

    /*********************************\
    \*********************************/

std::string CBC_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        CBC_Mode<AES>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource(plain, true, new StreamTransformationFilter(
                e, new StringSink(cipher) 
            )
        );

#if 0
		StreamTransformationFilter filter(e);
		filter.Put((const byte*)plain.data(), plain.size());
		filter.MessageEnd();

		const size_t ret = filter.MaxRetrievable();
		cipher.resize(ret);
		filter.Get((byte*)cipher.data(), cipher.size());
#endif

    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string CBC_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        
        CBC_Mode<AES>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered)
            )
        );

#if 0
		StreamTransformationFilter filter(d);
		filter.Put((const byte*)cipher.data(), cipher.size());
		filter.MessageEnd();

		const size_t ret = filter.MaxRetrievable();
		recovered.resize(ret);
		filter.Get((byte*)recovered.data(), recovered.size());
#endif

    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return recovered;
}

	/*********************************\
	\*********************************/


std::string CFB_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        CFB_Mode<AES>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource(plain, true, new StreamTransformationFilter(
                e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string CFB_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        
        CFB_Mode<AES>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered)
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return recovered;
}

	/*********************************\
	\*********************************/

std::string OFB_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        OFB_Mode<AES>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource(plain, true, new StreamTransformationFilter(
                e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string OFB_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        
        OFB_Mode<AES>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered)
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return recovered;
}

	/*********************************\
	\*********************************/

std::string CTR_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        CTR_Mode<AES>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource(plain, true, new StreamTransformationFilter(
                e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string CTR_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte IV[16]) {
    try {
        
        CTR_Mode<AES>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered)
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return recovered;
}

	/*********************************\
	\*********************************/

std::string XTS_Encrypt(std::string plain, CryptoPP::byte key[32], CryptoPP::byte IV[16]) {
    try {
        CryptoPP::XTS_Mode<AES>::Encryption e;
        e.SetKeyWithIV(key, 32, IV);

#if 0
        std::cout << "key length: " << enc.DefaultKeyLength() << std::endl;
        std::cout << "key length (min): " << enc.MinKeyLength() << std::endl;
        std::cout << "key length (max): " << enc.MaxKeyLength() << std::endl;
        std::cout << "block size: " << enc.BlockSize() << std::endl;
#endif
        
        StringSource(plain, true, new StreamTransformationFilter(
                e, new StringSink(cipher), StreamTransformationFilter::NO_PADDING 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string XTS_Decrypt(std::string cipher, CryptoPP::byte key[32], CryptoPP::byte IV[16]) {
    try {
        
        CryptoPP::XTS_Mode<AES>::Decryption d;
        d.SetKeyWithIV(key, 32, IV);
        StringSource (cipher, true, new StreamTransformationFilter(
            d, new StringSink(recovered), StreamTransformationFilter::NO_PADDING
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return recovered;
}

	/*********************************\
	\*********************************/

const int TAG_SIZE = 8;

std::string CCM_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte *IV) {
    try {
        CCM<AES, TAG_SIZE>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV, 12);
        e.SpecifyDataLengths(0, plain.size(), 0);
        StringSource(plain, true, new AuthenticatedEncryptionFilter(
                e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string CCM_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte *IV) {
    try {
        CCM<AES, TAG_SIZE>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV, 12);
        d.SpecifyDataLengths(0, cipher.size() - TAG_SIZE, 0);
        StringSource (cipher, true, new AuthenticatedDecryptionFilter(
            d, new StringSink(recovered)
            )
        );

    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }
    return recovered;
}

	/*********************************\
	\*********************************/

std::string GCM_Encrypt(std::string plain, CryptoPP::byte *key, CryptoPP::byte *IV) {
    try {
        GCM<AES>::Encryption e;
        e.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV, AES::BLOCKSIZE);
        StringSource(plain, true, new AuthenticatedEncryptionFilter(
                e, new StringSink(cipher) 
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }

    return cipher;
}

std::string GCM_Decrypt(std::string cipher, CryptoPP::byte *key, CryptoPP::byte *IV) {
    try {
        GCM<AES>::Decryption d;
        d.SetKeyWithIV(key, AES::DEFAULT_KEYLENGTH, IV, AES::BLOCKSIZE);
        StringSource (cipher, true, new AuthenticatedDecryptionFilter(
            d, new StringSink(recovered)
            )
        );
    }
    catch (const CryptoPP::Exception& exc) {
        std::cerr << exc.what() << std::endl;
        std::exit(1);
    }
    return recovered;
}
