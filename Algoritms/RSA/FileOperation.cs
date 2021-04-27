using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CourseProgect.Algoritms.RSA
{
    class FileOperation
    {
        // Given a file name, returns its content.
        public string Read(string fileName)
        {
            var stringBuilder = new StringBuilder();

            try
            {
                var lines = File.ReadLines(fileName);

                // For each line read from file.
                foreach (var line in lines)
                {
                    stringBuilder.Append(line + " ");
                }

                // Remove newline character from the end.
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }

            return stringBuilder.ToString();
        }
    }
}
