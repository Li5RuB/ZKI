using System;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("__________________________MD5__________________________");

            string path = "text.txt";
            string md5 = ComputeMD5Checksum(path);
            Console.WriteLine("Значение хэш-функции = {0}",md5);
            recoding(path,md5);
            Console.WriteLine("_________________Текст записан в файл__________________");
            Console.ReadKey();

        }
        private static string ComputeMD5Checksum(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                Console.WriteLine("Исходный текст: {0}",System.Text.Encoding.Default.GetString(fileData));
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }
        private static void recoding(string path,string text)
        {
            using (FileStream fstream = new FileStream("md5.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                
            }
        }
    }
}
