using System.Security.Cryptography;
using System.Text;

namespace CsharpAdvancePractice
{
    /// <summary>
    /// Containing cryptographic methods
    /// </summary>
    public class Cryptography
    {
        /// <summary>
        /// Containing cryptographic methods demo
        /// </summary>
        public static void CryptographyDemo()
        {
            Console.Write("Enter Text: ");
            string message = Console.ReadLine();


            // Symmetric Encryption (AES)
            Console.WriteLine("\nAES Symmetric Encryption:");
            byte[] aesKey = AesEncryption.GenerateKey();

            var (aesCipherText, aesIV) = AesEncryption.Encrypt(message, aesKey); 
            Console.WriteLine("Encrypted Message (AES): " + Convert.ToBase64String(aesCipherText));

            string aesDecryptedMessage = AesEncryption.Decrypt(aesCipherText, aesKey, aesIV); 
            Console.WriteLine("Decrypted Message (AES): " + aesDecryptedMessage);


            // Symmetric Encryption (DES)
            Console.WriteLine("\nDES Symmetric Encryption:");
            byte[] desKey = DesEncryption.GenerateKey();

            var (desCipherText, desIV) = DesEncryption.Encrypt(message, desKey);
            Console.WriteLine("Encrypted Message (DES): " + Convert.ToBase64String(desCipherText));

            string desDecryptedMessage = DesEncryption.Decrypt(desCipherText, desKey, desIV);
            Console.WriteLine("Decrypted Message (DES): " + desDecryptedMessage);


            // Asymmetric Encryption (RSA)
            Console.WriteLine("\nAsymmetric Encryption:");
            RSAParameters privateKey;
            RSAParameters publicKey = AsymmetricEncryption.GenerateKeyPair(out privateKey); // Generate RSA key pair

            byte[] encryptedMessage = AsymmetricEncryption.Encrypt(message, publicKey);
            Console.WriteLine("Encrypted Message: " + Convert.ToBase64String(encryptedMessage));

            string decryptedMessage = AsymmetricEncryption.Decrypt(encryptedMessage, privateKey);
            Console.WriteLine("Decrypted Message: " + decryptedMessage);
        }
    }

    public class AesEncryption
    {
        public static byte[] GenerateKey()
        {
            using (Aes objAes = Aes.Create())
            {
                objAes.GenerateKey();
                return objAes.Key;
            }
        }

        public static (byte[] CipherText, byte[] IV) Encrypt(string plainText, byte[] key)
        {
            using (Aes objAes = Aes.Create())
            {
                objAes.Key = key;
                objAes.GenerateIV(); // Generate a new IV for each encryption
                using (ICryptoTransform objICryptoTransform = objAes.CreateEncryptor(objAes.Key, objAes.IV))
                {
                    byte[] arrPlainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] arrCipherBytes = objICryptoTransform.TransformFinalBlock(arrPlainBytes, 0, arrPlainBytes.Length);
                    return (arrCipherBytes, objAes.IV);
                }
            }
        }

        public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Aes objAes = Aes.Create())
            {
                objAes.Key = key;
                objAes.IV = iv;
                using (ICryptoTransform objICryptoTransform = objAes.CreateDecryptor(objAes.Key, objAes.IV))
                {
                    byte[] arrPlainBytes = objICryptoTransform.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    return Encoding.UTF8.GetString(arrPlainBytes);
                }
            }
        }
    }

    public class DesEncryption
    {
        public static byte[] GenerateKey()
        {
            using (DES des = DES.Create())
            {
                des.GenerateKey();
                return des.Key;
            }
        }

        public static (byte[] CipherText, byte[] IV) Encrypt(string plainText, byte[] key)
        {
            using (DES des = DES.Create())
            {
                des.Key = key;
                des.GenerateIV(); // Generate a new IV for each encryption
                using (ICryptoTransform encryptor = des.CreateEncryptor(des.Key, des.IV))
                {
                    byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                    byte[] cipherBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
                    return (cipherBytes, des.IV);
                }
            }
        }

        public static string Decrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (DES des = DES.Create())
            {
                des.Key = key;
                des.IV = iv;
                using (ICryptoTransform decryptor = des.CreateDecryptor(des.Key, des.IV))
                {
                    byte[] plainBytes = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
                    return Encoding.UTF8.GetString(plainBytes);
                }
            }
        }
    }

    public class AsymmetricEncryption
    {
        public static RSAParameters GenerateKeyPair(out RSAParameters privateKey)
        {
            using (RSA objRSA = RSA.Create())
            {
                objRSA.KeySize = 2048;
                privateKey = objRSA.ExportParameters(true); // Private key
                return objRSA.ExportParameters(false);      // Public key
            }
        }

        public static byte[] Encrypt(string plainText, RSAParameters publicKey)
        {
            using (RSA objRSA = RSA.Create())
            {
                objRSA.ImportParameters(publicKey);
                byte[] arrPlainBytes = Encoding.UTF8.GetBytes(plainText);
                return objRSA.Encrypt(arrPlainBytes, RSAEncryptionPadding.Pkcs1);
            }
        }

        public static string Decrypt(byte[] cipherText, RSAParameters privateKey)
        {
            using (RSA objRSA = RSA.Create())
            {
                objRSA.ImportParameters(privateKey);
                byte[] arrPlainBytes = objRSA.Decrypt(cipherText, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(arrPlainBytes);
            }
        }
    }
}