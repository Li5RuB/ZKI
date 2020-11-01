#include <iostream>
#include <string>
#include <stdlib.h>
#include <time.h>
#include <stdio.h>
#include <ctime>
#include <conio.h>

using namespace std;

int main()
{
	char ident[30];
	cout << "Vvedite login:";
	cin >> ident; //ввод логина
	int idLen = strlen(ident);

	char num[] = "0123456789"; //массив цифр
	char sym[] = "!\"#$%&()*'"; //массив значков
	char alf[] = "qwertyuiopasdfghjklzxcvbnm"; //английский алфавит

	srand(time(0));

	int passLen = 6; // длина пароля
	char* password = new char[6];
	password[0] = num[rand() % 10]; //первый символ пароля
	password[1] = alf[rand() % 26]; //второй символ пароля
	password[2] = ident[rand() % strlen(ident)]; //третий символ пароля
	for (int i = 3; i < 6; i++) //(4-6)-ой символ пароля
	{
		password[i] = sym[rand() % 10];
	}
	password[passLen] = '\0';
	cout << "\npass = " << password << endl; //вывод логина пароля
	_getch();
}
