using System;
using System.Collections.Generic;
using System.Text;

namespace CourseProgect.Algoritms.RSA
{
    public class PrimeNumber
    {
        private int[] _numbers;
        private int _countNumber;
        private Random _random;

        public PrimeNumber(string[] data)
        {
            // Size of data.
            _countNumber = data.Length;
            _numbers = new int[_countNumber];
            _random = new Random();

            // Initialize numbers array with data.
            for (int i = 0; i < _countNumber; ++i)
            {
                _numbers[i] = int.Parse(data[i]);
            }
        }

        // Checks for primality given an integer.
        private bool IsPrime(int a)
        {
            var r = true;

            // If number is already in list.
            if (a >= _numbers[0] && a <= _numbers[_countNumber - 1])
            {
                for (int i = 0; i < _countNumber; i++)
                {
                    if (_numbers[i] == a)
                    {
                        break;
                    }
                }
            }

            // Number is not in the list, determine mathematically.
            else
            {
                var limit = (int)Math.Sqrt(a);

                for (int i = 2; r && i <= limit; i++)
                {
                    if (a % i == 0)
                    {
                        r = false;
                    }
                }
            }

            return r;
        }

        // Returns a random prime from list.
        public int RandomPrime()
        {
            var index = _random.Next(0, _countNumber);
            return _numbers[index];
        }
    }
}
