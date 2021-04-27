using CourseProgect.Algoritms.RSA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace CourseProgect.Algoritms
{
    public class RSAClass
    {
        //    private int[] _cipheredText;
        //    private int _p, _q, _n, _phi, _d, _e;
        //    private PrimeNumber _primeNumber;

        //    public RSAClass() { }
        //    public RSAClass(PrimeNumber primeNumber)
        //    {
        //        _primeNumber = primeNumber;
        //    }

        //    // Initializes parameters required for encryption/decryption.
        //    private void InitializeParameters()
        //    {
        //        // First prime number.
        //        _p = _primeNumber.RandomPrime();
        //        // Second prime number.
        //        _q = _primeNumber.RandomPrime();

        //        // p and q should be in ascending order.
        //        if (_p > _q)
        //        {
        //            var t = _q;
        //            _q = _p;
        //            _p = t;
        //        }

        //        // Product of selected prime numbers.
        //        _n = _p * _q;
        //        _phi = (_p - 1) * (_q - 1);
        //    }

        //    // Determines if two numbers are co-prime.
        //    // Numbers are  co-prime when their GCD/HCF is 1.
        //    private bool IsCoPrime(int number1, int number2)
        //    {
        //        return (GCD(number1, number2) == 1);
        //    }

        //    // Determines Greatest Common Divisor a.k.a. Highest Common Factor.
        //    private int GCD(int number1, int number2)
        //    {
        //        if (number1 == 0)
        //        {
        //            return number2;
        //        }

        //        return GCD(number2 % number1, number1);
        //    }

        //    // Returns a coprime of phi.
        //    private void CalculateE()
        //    {
        //        _e = -1;

        //        for (int i = 2; i < _phi; ++i)
        //        {
        //            if (IsCoPrime(i, _phi))
        //            {
        //                _e = i;
        //                break;
        //            }
        //        }
        //    }

        //    // Calculates D.
        //    private void CalculateD()
        //    {
        //        int result = 1;

        //        while ((_e * result - 1) % _phi != 0)
        //        {
        //            result++;
        //        }

        //        _d = result;
        //    }

        //    // Converts a string into a byte array.
        //    private byte[] StringToByteArray(string data)
        //    {
        //        var length = data.Length;
        //        var results = new byte[length];
        //        char temp;
        //        byte t;

        //        for (int i = 0; i < length; ++i)
        //        {
        //            temp = data[i];
        //            t = (byte)temp;

        //            // If current character is numeric digit.
        //            if (Char.IsDigit(temp)) { t = (byte)(t - 48); }

        //            // If current character is blank space.
        //            else if (temp == ' ') { t = (byte)199; }

        //            // If current character is new line.
        //            else if (temp == '\n') { t = (byte)200; }

        //            // If current character is carriage return.
        //            else if (t == 13) { t = (byte)201; }

        //            else { t = (byte)(t - 55); }

        //            results[i] = t;
        //        }

        //        return results;
        //    }

        //    // Convert a byte array into a string.
        //    private string ByteArrayToString(byte[] data)
        //    {
        //        int length = data.Length;
        //        var stringBuilder = new StringBuilder();
        //        byte temp;

        //        for (int i = 0; i < length; ++i)
        //        {
        //            temp = data[i];

        //            // If current byte represents numeric digit.
        //            if (temp >= 0 && temp <= 9) { temp = (byte)(temp + 48); }

        //            // If current byte represents white space.
        //            else if (temp == 199) { temp = (byte)32; }

        //            // If current byte represents new line.
        //            else if (temp == 200) { temp = (byte)10; }

        //            // If current byte represents carriage return.
        //            else if (temp == 201) { temp = (byte)13; }

        //            else { temp = (byte)(temp + 55); }

        //            stringBuilder.Append((char)temp);
        //        }

        //        return stringBuilder.ToString();
        //    }

        //    // Converts an int array into a string.
        //    private string IntArrayToString(int[] data)
        //    {
        //        var length = data.Length;
        //        var results = new byte[length];

        //        for (int i = 0; i < length; ++i)
        //        {
        //            results[i] = (byte)data[i];
        //        }

        //        return Encoding.UTF8.GetString(results);
        //    }

        //    // Converts plain text into ciphered text.
        //    private int[] CipheredText(byte[] data, int e, int n)
        //    {
        //        int length = data.Length, temp;
        //        var results = new int[length];

        //        for (int i = 0; i < length; ++i)
        //        {
        //            temp = data[i];

        //            // If whitespace, newline or carriage return.
        //            if (temp >= 199 && temp <= 201)
        //            {
        //                results[i] = temp;
        //                continue;
        //            }

        //            temp = (int)Math.Pow(temp, e);
        //            temp %= n;
        //            results[i] = temp;
        //        }

        //        return results;
        //    }

        //    // Convert ciphered text into plain text.
        //    private byte[] DecipheredText(int[] data, int d, int n)
        //    {
        //        int length = data.Length, temp = 0;
        //        var results = new byte[length];
        //        BigInteger bigInt;
        //        string stringRepresentation;

        //        for (int i = 0; i < data.Length; ++i)
        //        {
        //            temp = data[i];

        //            // If whitespace, newline or carriage return.
        //            if (temp >= 199 && temp <= 201)
        //            {
        //                results[i] = (byte)temp;
        //                continue;
        //            }

        //            bigInt = temp;
        //            bigInt = BigInteger.ModPow(bigInt, d, n);
        //            stringRepresentation = bigInt.ToString();
        //            temp = Int32.Parse(stringRepresentation);
        //            results[i] = (byte)temp;
        //        }

        //        return results;
        //    }

        //    // Encrypts message.
        //    public string Encrypt(string message)
        //    {
        //        // InitializeParameters();
        //        var arr = StringToByteArray(message);
        //        CalculateE();
        //        CalculateD();
        //        _cipheredText = CipheredText(arr, _e, _n);
        //        var stringBuilder = new StringBuilder();
        //        int length = _cipheredText.Length;

        //        for (int j = 0; j < length; ++j)
        //        {
        //            stringBuilder.Append(_cipheredText[j]);
        //        }

        //        return stringBuilder.ToString();
        //    }

        //    // Decrypts message.
        //    public string Decrypt(string message)
        //    {
        //        var temp = message.ToCharArray();
        //        byte[] plainText = DecipheredText(_cipheredText, _d, _n);
        //        return ByteArrayToString(plainText);
        //    }

        //    public int N
        //    {
        //        get { return _n; }
        //        set { _n = value; }
        //    }

        //    public int D
        //    {
        //        get { return _d; }
        //        set { _d = value; }
        //    }

        //    public int E
        //    {
        //        get { return _e; }
        //        set { _e = value; }
        //    }
        //}

        public static byte[] crypted;
        public static string EncryptMessage(string inputValue)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            byte[] text = Encoding.UTF8.GetBytes(inputValue);
            crypted = Encryption(text, RSA.ExportParameters(false), false);
            string cryptedText = Convert.ToBase64String(crypted);

            return cryptedText;
        }

        public static string DecryptMessage()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            string deCryptedText = Decryption(crypted, RSA.ExportParameters(true), false);
            RSA.ExportRSAPublicKey().ToString();
            return deCryptedText;
        }

        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public string Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {

            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

    }
}
