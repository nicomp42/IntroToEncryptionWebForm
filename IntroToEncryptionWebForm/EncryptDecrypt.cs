using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace IntroToEncryptionWebForm
{
    public class EncryptDecrypt
    {
        private byte[] key;
        private byte[] iv;
        private ArrayList _englishWords;
        private ArrayList _encryptedWords;
        private ArrayList _hashedWords;

        public ArrayList hashedWords
        {
            get { return _hashedWords; }
        }
        public ArrayList englishWords {
            get { return _englishWords; }
        }
        public ArrayList encryptedWords {
            get { return _encryptedWords; }
        }
        public EncryptDecrypt() {
            _englishWords = new ArrayList();
            _encryptedWords = new ArrayList();
            _hashedWords = new ArrayList();
            loadEnglishWords(_englishWords);
            key = GenerateRandomBytes(32); // 256-bit key
            iv = GenerateRandomBytes(16); // 128-bit IV
            encryptWords(_englishWords, _encryptedWords);
            hashWords(_englishWords, _hashedWords);
        }
        private byte[] GenerateRandomBytes(int length)
        {
            byte[] randomBytes = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(randomBytes);
            }
            return randomBytes;
        }
        private void hashWords(ArrayList words, ArrayList hashedWords)
        {
            foreach (String word in words)
            {
                hashedWords.Add(CalculateSHA256Hash(word));
            }
        }
        private void encryptWords(ArrayList words, ArrayList encryptedWords) {
            foreach (String word in words) {
                encryptedWords.Add(encryptWord(word));
            }
        }
        /// <summary>
        /// Decrpyt a byte array in AES encryption
        /// </summary>
        /// <param name="bytes">The bytes array to decrypt</param>
        /// <returns>A UTF-8 string</returns>
        public string decryptWord(byte[] bytes) {
            using (Aes aes = Aes.Create()) {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (MemoryStream msDecrypt = new MemoryStream(bytes)) {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Encrypt a UTF-8 string using AES
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Base 64 String</returns>
        public string encryptWord(string word)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(word);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
                        csEncrypt.FlushFinalBlock();

                    }

                    byte[] cipherTextBytes = msEncrypt.ToArray();

                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }
        private void loadEnglishWords(ArrayList englishWords) {
            try {
                string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "EnglishALL.txt"); // Get project root
                using (StreamReader reader = new StreamReader(basePath)) {
                    string line;
                    while ((line = reader.ReadLine()) != null) {
                        englishWords.Add(line);
                    }
                }
            } catch (IOException e) {
                // There is no console!
                Console.WriteLine("Error reading file: " + e.Message);
            }
        }
        public static string CalculateSHA256Hash(string inputString)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array
                byte[] bytes = Encoding.UTF8.GetBytes(inputString);

                // ComputeHash - this also performs hashing on the input bytes and returns the result
                byte[] hashBytes = sha256Hash.ComputeHash(bytes);

                // Convert the byte array to a string representation in hexadecimal format
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public String lookupHashedString(String hashedString) {
            String result = "******* STRING NOT FOUND *********";
            int idx = 0;
            foreach (String hashedWord in _hashedWords) {
                if (hashedString == hashedWord) {
                    result = (String)_englishWords[idx];
                    break;
                }
                idx++;
            }
            return result;
        }

    }
}