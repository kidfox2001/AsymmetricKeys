using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.CodeDom;

namespace ConsoleAppSHA
{
    public   class RSAUtil
    {

        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        public string KeyPublish;
        public string KeyPrivate;

        public RSAUtil(string KeyName)
        {
            // Create the CspParameters object and set the key container
            // name used to store the RSA key pair.
            var parameters = new CspParameters
            {
                KeyContainerName = KeyName
            };

            KeyPublish = rsa.ToXmlString(false); // false to get the public key   
            KeyPrivate = rsa.ToXmlString(true); // true to get the private key   
        }

        public RSAUtil(string publicKey,string privateKey)
        {
            KeyPublish = publicKey;
            KeyPrivate = privateKey;
        }


        public byte[] EncryptData( string text)
        {
            if ( String.IsNullOrEmpty( KeyPublish))
            {
                throw new Exception("No Publish Key");
            }

            // Convert the text to an array of bytes   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes(text);

            // Create a byte array to store the encrypted data in it   
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the rsa pulic key   
                rsa.FromXmlString(KeyPublish);

                // Encrypt the data and store it in the encyptedData Array   
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            return encryptedData;
        }


        public string DecryptData(byte[] dataToDecrypt)
        {
            if (String.IsNullOrEmpty(KeyPublish))
            {
                throw new Exception("No Private Key");

            }
            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Set the private key of the algorithm   
                rsa.FromXmlString(KeyPrivate);
                decryptedData = rsa.Decrypt(dataToDecrypt, false);
            }

            // Get the string value from the decryptedData byte array   
            UnicodeEncoding byteConverter = new UnicodeEncoding();
            return byteConverter.GetString(decryptedData);
        }

    }
}
