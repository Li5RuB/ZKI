#include <iostream>
#include <ctime>
#include <cctype>
#include <iterator>
#include <cstdlib>
#include <algorithm>
#include <clocale>
#include <vector>
using namespace std;
const int Max = 10000;
unsigned myRand(int a, int c, int m, int next)
{
	return (a * next + c) % m;
}
bool GCD(int m, int c)
{
	if ((m % c) != 0)
	{
		return true;
	}
	else return false;
}
bool High(int m, int aorc)
{
	if (m > aorc)
	{
		return true;
	}
	else return false;
}
int main()
{
	int x0;
	int a;
	int c;
	setlocale(LC_ALL, "Russian");
	cout << "Линейный конэгурэнтный гененратор";
	cout << endl;

	int m = 0;
	cout << "Введите количество чисел в случайной последовательности :"; cin >> m;

Metka3:
	cout << "Введите начальное значение для генерируемой последовательности :"; cin >> x0;

	bool high2 = High(m, x0);
	if (high2 == false)
	{
		cout << "Вы ввели число не удовлетворяющие условие, повторите свою попытку!";
		cout << endl;
		goto Metka3;
	}
Metka:
	cout << "Введите  число-множитель, которое a<m и с наибольшим общим делителем = 1 :"; cin >> a;
	bool gcd;
	gcd = GCD(m, a);
	bool high = High(m, a);
	if ((gcd == false) || (high == false))
	{
		cout << "Вы ввели число не удовлетворяющие условие , повторите свою попытку!";
		cout << endl;
		goto Metka;
	}
Metka1:
	cout << "Введите  число-приращение, которое c<m и наибольшим общим делителем = 1 :"; cin >> c;
	cout << endl;
	bool gcd1;
	gcd1 = GCD(m, c);
	bool high1 = High(m, c);
	if ((gcd1 == false) || (high1 == false))
	{
		cout << "Вы ввели число не удовлетворяющие условие , повторите свою попытку!";
		cout << endl;
		goto Metka1;
	}
	int* mas = new int[Max];
	mas[0] = x0;
	mas[1] = myRand(a, c, m, mas[0]);
	for (int i = 2; i < m + 1; i++)
	{
		mas[i] = myRand(a, c, m, mas[i - 1]);
	}
	for (int i = 0; i < m + 1; i++)
	{
		cout << "Число № " << i << " --- " << "Псевдо случайное значение = " << mas[i];
		cout << endl;
	}
}
