using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CourseProgect.Algoritms.Blum
{
    public class BlumGoldwasser
    {
        private int PrimeP;
        private int PrimeQ;
        private int IntegerA;
        private int IntegerB;
        private int XNaut;

        public BlumGoldwasser(int primeP, int primeQ, int integerA, int integerB, int xNaut)
        {
            PrimeP = primeP;
            PrimeQ = primeQ;
            IntegerA = integerA;
            IntegerB = integerB;
            XNaut = xNaut;
        }

        public Tuple<List<string>, int> Encrypt(string inputMessege)
        {
            byte[] inputMessegeByte = Encoding.Unicode.GetBytes(inputMessege);
            StringBuilder stringBuilder = new StringBuilder();


            foreach (var item in inputMessegeByte)
            {
                stringBuilder.Append(Convert.ToString(item, 2));
            }
            string inputString = stringBuilder.ToString();

            Tuple<List<string>, int> cyphertext = encrypt(inputString);

            return cyphertext;
        }

        public Tuple<List<string>, int> encrypt(string message)
        {

            List<string> answer = new List<string>();

            int N = PrimeP * PrimeQ;
            int k = (int)(Math.Log(N) / Math.Log(2));
            int h = (int)(Math.Log(k) / Math.Log(2));
            int t = message.Length / h;
            if (message.Length % h != 0) { t++; }

            List<string> choppedMessage = new List<string>();
            for (int i = 0; i + h <= message.Length; i += h)
            {
                choppedMessage.Add(message.Substring(i, h));
            }
            if (message.Length % h != 0)
            {
                choppedMessage.Add(message.Substring((message.Length / h) * h));
            }

            long XsubI = XNaut;
            for (int i = 0; i < t; i++)
            {

                string XsubIstring = Convert.ToString(XsubI, 2);
                string leastSigBits = XsubIstring.Substring(XsubIstring.Length - h);

                int PsubIasInt = int.Parse(leastSigBits);
                int MsubIasInt = int.Parse(choppedMessage[i]);

                int CsubIasInt = PsubIasInt ^ MsubIasInt;
                string CsubI = CsubIasInt.ToString();

                while (CsubI.Length < 4)
                {
                    CsubI = "0" + CsubI;
                }
                answer.Add(CsubI);

                XsubI = (XsubI * XsubI) % N;
            }
            XsubI = (XsubI * XsubI) % N;
            return new Tuple<List<string>, int>(answer, (int)XsubI);
        }

        public string decrypt(Tuple<List<string>, int> cyphertext)
        {

            string answer = "";
            int N = PrimeP * PrimeQ;

            int t = cyphertext.Item1.Count;
            int valueD1 = powerWithModulus((PrimeP + 1) / 4, t + 1, PrimeP - 1);
            int valueD2 = powerWithModulus((PrimeQ + 1) / 4, t + 1, PrimeQ - 1);

            int valueU = powerWithModulus(cyphertext.Item2, valueD1, PrimeP);
            int valueV = powerWithModulus(cyphertext.Item2, valueD2, PrimeQ);

            long Vap = (long)valueV * (long)IntegerA * (long)PrimeP;
            long ubq = (long)valueU * (long)IntegerB * (long)PrimeQ;
            long Xnaut = (Vap + ubq) % N;
            if (Xnaut < 0) { Xnaut = N - Xnaut; }
            long XsubI = Xnaut;

            int k = (int)(Math.Log(N) / Math.Log(2));
            int h = (int)(Math.Log(k) / Math.Log(2));

            for (int i = 0; i < t; i++)
            {

                string XsubIstring = Convert.ToString(XsubI, 2);
                string leastSigBits = XsubIstring.Substring(XsubIstring.Length - h);

                int PsubIasInt = int.Parse(leastSigBits);
                int CsubIasInt = int.Parse(cyphertext.Item1[i]);

                int MsubIasInt = PsubIasInt ^ CsubIasInt;
                string MsubI = MsubIasInt.ToString();

                while (MsubI.Length < 4)
                {
                    MsubI = "0" + MsubI;
                }
                answer = answer + MsubI;

                XsubI = (XsubI * XsubI) % N;
            }

            return answer;

        }

        public int powerWithModulus(int bases, int exponent, int modulus)
        {

            if (exponent < 0)
            {

            }
            long answer = 1;
            for (int i = 0; i < exponent; i++)
            {

                answer = answer * bases % modulus;

            }
            return (int)answer;
        }

        public string decrypt(string temp)
        {
            return temp;
        }
    }
}