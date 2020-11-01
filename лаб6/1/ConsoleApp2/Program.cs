using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
       
        public static bool GCD(int a)
        {
            var result = true;
            if (a > 1)
            {
                for (var i = 2u; i < a; i++)
                {
                    if (a % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool IsCoprime(int a, int b)
        {
            return a == b
                   ? a == 1
                   : a > b
                        ? IsCoprime(a - b, b)
                        : IsCoprime(b - a, a);
        }
        static void mainmenu()
        {
            Console.Clear();
            Console.WriteLine("Шифратор RSA");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Сгенирировать закрытый и открытый ключ");
            Console.WriteLine("2. Зашифровать число");
            Console.WriteLine("3. Зашифровать текст");
            Console.WriteLine("4. Расшифровать число");
            Console.WriteLine("5. Расшифровать текст");
            Console.WriteLine("6. Выйти из программы");
        Menu1:
            string buf = Console.ReadLine();
            if (buf == "1")
            {
                GenKey();
                return;
            }
            else if (buf == "2")
            {
                EnсryptNum();
                return;
            }
            else if (buf == "3")
            {
                EncryptMess();
                return;
            }
            else if (buf == "4")
            {
                DecryptNum();
                return;
            }
            else if (buf == "5")
            {
                DecryptMess();
                return;
            }
            else if (buf == "6")
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                Console.WriteLine("Неизвестная команда");
                goto Menu1;
            }
        }
        static void GenKey()
        {
        Metka1:
            int n, p, q, d, e, nn;
            bool GCD1;
            string buf;
            Console.Clear();
            Console.WriteLine("Генерация ключа для RSA");
            Console.WriteLine("Введите p, оно должно быть простым");
        Error1:
            buf = Console.ReadLine();
            p = Convert.ToInt32(buf);
            GCD1 = GCD(p);
            if (GCD1 == false)
            {
                Console.WriteLine("Вы ввели число не удовлетворяющие условие, повторите свою попытку!");
                goto Error1;
            }
            Console.WriteLine("Введите q, оно должно быть простым");
        Error2:
            buf = Console.ReadLine();
            q = Convert.ToInt32(buf);
            GCD1 = GCD(q);
            if (GCD1 == false)
            {
                Console.WriteLine("Вы ввели число не удовлетворяющие условие, повторите свою попытку!");
                goto Error2;
            }
            n = p * q;
            Console.WriteLine("Выберите число e.");
            Console.WriteLine("Это число должно быть взаимно простым с вырожением (p-1)*(q-1)");
            nn = (p - 1) * (q - 1);
        Error3:
            buf = Console.ReadLine();
            d = Convert.ToInt32(buf);
            GCD1 = IsCoprime(d, nn);
            if (GCD1 == false)
            {
                Console.WriteLine("Вы ввели число не удовлетворяющие условие, повторите свою попытку!");
                goto Error3;
            }
            nn = (p - 1) * (q - 1);
            e = Eee(d, nn);
            Console.WriteLine("Ключи сгенерированы");
            Console.WriteLine("Закрытый ключ:");
            Console.WriteLine("d = " + e.ToString() + " и n = " + n.ToString());
            Console.WriteLine("Открытый ключ:");
            Console.WriteLine("e = " + d.ToString() + " и n = " + n.ToString());
        Error4:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y" || buf == "y")
            {
                return;
            }
            else if (buf == "N" || buf == "n")
            {
                goto Metka1;
            }
            else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error4;
            }
        }
        public static int Eee(int d, int nn)
        {
            int e;
            for (int i = 2; i < (nn); i++)
            {

                int k = (d * i) % nn;
                if (k == 1)
                {
                    e = i;
                    return e;

                }

            }
            return 0;
        }
        static void EnсryptNum()
        {
            Metka2:
            string buf;
            int e, n, a;
            Console.Clear();
            Console.WriteLine("Шифрование числа");
            Console.WriteLine("Введите число e которое получили при генерации ключа");
            buf = Console.ReadLine();
            e = Convert.ToInt32(buf);
            Console.WriteLine("Введите число n которое получили при генерации ключа");
            buf = Console.ReadLine();
            n = Convert.ToInt32(buf);
            Console.WriteLine("Введите число, которое хотите зашифровать < n");
            Error10:
            buf = Console.ReadLine();
            a = Convert.ToInt32(buf);
            if (!(high(a,n)))
            {
                Console.WriteLine("Вы ввели число не удовлетворяющие условие, повторите свою попытку!");
                goto Error10;
            }
            BigInteger c = BigInteger.Parse(buf);
            c = BigInteger.Pow(c, e) % n;
            Console.WriteLine("Результат шифрования");
            Console.WriteLine("{0} --> {1}", a, c);
            Error5:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y" || buf == "y")
            {
                return;
            }
            else if (buf == "N" || buf == "n")
            {
                goto Metka2;
            }
            else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error5;
            }
        }
        static bool high(int a,int n)
        {
            if (a < n)
            {
                return true;
            }
            else return false;
        }
        static void DecryptNum()
        {
            Metka3:
            string buf;
            int a, d, n;
            Console.Clear();
            Console.WriteLine("Расшифровка числа");
            Console.WriteLine("Введите число d которое получили при генерации ключа");
            buf = Console.ReadLine();
            d = Convert.ToInt32(buf);
            Console.WriteLine("Введите число n которое получили при генерации ключа");
            buf = Console.ReadLine();
            n = Convert.ToInt32(buf);
            Console.WriteLine("Введите число, которое хотите расшифровать");
            buf = Console.ReadLine();
            a = Convert.ToInt32(buf);
            BigInteger m = BigInteger.Parse(buf);
            m = BigInteger.Pow(m, d) % n;
            Console.WriteLine("Результат расшифровки");
            Console.WriteLine("{0} --> {1}", a, m);
        Error6:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y" || buf == "y")
            {
                return;
            }
            else if (buf == "N" || buf == "n")
            {
                goto Metka3;
            }
            else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error6;
            }
        }
        static void EncryptMess()
        {
        Metka4:
            string alh = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            
            string buf;
            int e, n, a;
            Console.Clear();
            Console.WriteLine("Шифрование текста");
            Console.WriteLine("Введите число e которое получили при генерации ключа");
            buf = Console.ReadLine();
            e = Convert.ToInt32(buf);
            Console.WriteLine("Введите число n которое получили при генерации ключа");
            buf = Console.ReadLine();
            n = Convert.ToInt32(buf);
            Console.WriteLine("Введите тест, который хотите зашифровать (английский, заглавные буквы)");
            StringReader m = new StringReader(Console.ReadLine());
            string mess =  m.ReadToEnd();
            int[] cm = new int [mess.Length];
            Console.WriteLine("Зашифрованное сообщение: ");
            for (int i = 0; i < mess.Length; i++)
            {
                a=alh.IndexOf(mess[i]);

                Console.Write(CrTextsDecr(e, n, a)+" ");
            }
            Console.WriteLine();
           
        
            Error7:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y" || buf == "y")
            {
                return;
            }
            else if (buf == "N" || buf == "n")
            {
                goto Metka4;
            }
            else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error7;
            }
        }
        static void DecryptMess()
        {
        Metka4:
            string alh = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] cm = new int[100];
            string buf;
            int d, n, a;
            Console.Clear();
            Console.WriteLine("Расшифровка текста");
            Console.WriteLine("Введите число d которое получили при генерации ключа");
            buf = Console.ReadLine();
            d = Convert.ToInt32(buf);
            Console.WriteLine("Введите число n которое получили при генерации ключа");
            buf = Console.ReadLine();
            n = Convert.ToInt32(buf);
            Console.WriteLine("Введите тест, который хотите Расшифровка (английский, заглавные буквы)");
            Console.WriteLine("Вводите по одной зашифрованной букве, когда введёте все символы введите фразу end");
            int i = 0;
            bool end = true;
            do
            {   
                
                buf = Console.ReadLine();
                if (buf == "end")
                {
                    end = false;
                    break;
                }
                cm[i] = Convert.ToInt32(buf);
                i++;

            } while (end);
               
            Console.WriteLine("Расшифрованное сообщение: ");
            for (int j = 0; j < i; j++)
            {
                BigInteger c = TextsDecr(d, n, cm[j]);
                a = Int32.Parse(c.ToString());
                Console.Write(alh[a]);
            }
            Console.WriteLine();


        Error7:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y" || buf == "y")
            {
                return;
            }
            else if (buf == "N" || buf == "n")
            {
                goto Metka4;
            }
            else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error7;
            }
        }
        static BigInteger CrTextsDecr(int e,int n, int a)
        {
            BigInteger c = a;
            c = BigInteger.Pow(c, e) % n;            
            
            return c;
        }
        static BigInteger TextsDecr(int d, int n, int a)
        {
            BigInteger c = a;
            c = BigInteger.Pow(c, d) % n;
            return c;
        }

        static void Main(string[] args)
        {
        Menu:
            mainmenu();
            goto Menu;
        }
    }
}
