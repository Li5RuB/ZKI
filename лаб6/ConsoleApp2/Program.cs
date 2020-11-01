using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Numerics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        char[] alh = new char [26] {'A', 'B', 'C', 'D',
'E', 'F', 'G', 'H',
'I', 'J', 'K', 'L',
'M', 'N', 'O', 'P',
'Q', 'R', 'S', 'T',
'U', 'V', 'W', 'X',
'Y', 'Z' };
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
            } else if (buf == "2")
            {
                //EnсryptNum();
                return;
            }
            else if (buf == "3")
            {
                //EncryptMess();
                return;
            }
            else if (buf == "4")
            {
                //DecryptNum();
                return;
            }
            else if (buf == "5")
            {
                //DecryptMess();
                return;
            }
            else if (buf == "6")
            {
                Process.GetCurrentProcess().Kill();
            }else 
            {
                Console.WriteLine("Введены неверные данные");
                goto Menu1;
            }
        }
        static void GenKey()
        {
            Metka1:
            int n,p, q, d, e, nn;
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
            Console.WriteLine("Выберите число d.");
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
            e = Eee(n,nn);
            Console.WriteLine("Ключи сгенерированы");
            Console.WriteLine("Открытый ключ:");
            Console.WriteLine("e = " + e.ToString()+ " и n = "+ n.ToString());
            Console.WriteLine("Закрытый ключ:");
            Console.WriteLine("d = " + d.ToString() + " и n = " + n.ToString());
            Error4:
            Console.WriteLine("Вы хотите выйти? Y/N");
            buf = Console.ReadLine();
            if (buf == "Y")
            {
                return;
            } else if (buf == "N") 
            {
                goto Metka1;
            }else
            {
                Console.WriteLine("Неизвестная команда ");
                goto Error4;
            }
        }
        public static int Eee(int n, int nn)
        {
            int e;
            for (int i = 2; i < (n); i++)
            {
               
                int k = (n * i) % nn;
                if (k == 1)
                {
                    e = i;
                    return e;

                }
                
            }
            return 0;
        }
        static void Main(string[] args)
        {
            Menu:
            mainmenu();
            goto Menu;
        }
    }
}
