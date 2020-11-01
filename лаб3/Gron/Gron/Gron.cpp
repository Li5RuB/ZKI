#include <iostream>
using namespace std;

char alh[26] = { 'A', 'B', 'C', 'D',
'E', 'F', 'G', 'H',
'I', 'J', 'K', 'L',
'M', 'N', 'O', 'P',
'Q', 'R', 'S', 'T',
'U', 'V', 'W', 'X',
'Y', 'Z' };
int q;
int n;
int m;
int b;
int a;
char* key = new char[q];
char* key1 = new char[q];
char* minikey = new char[a];
char* mess = new char[q];
char* cmess = new char[q];
int main()
{
	cout << "SHIFR GronA" << endl;
	cout << "Enter your key ";
	cin >> minikey;
	a = strlen(minikey);
	cout << "Enter your mess : ";
	cin >> mess;
	q = strlen(mess);

	int k = 0;
	for (int i = 0; i < q; i++)
	{
		key[i] = minikey[k];
		k++;
		if (k == a)
		{
			k = 0;
		}

	}
	for (int i = 0; i < q; i++)
	{
		if (key[i] == '1')
		{
			key1[i] = 1;
		}
		else
		{
			if (key[i] == '2')
			{
				key1[i] = 2;
			}
			else
			{
				if (key[i] == '3')
				{
					key1[i] = 3;
				}
				else
				{
					if (key[i] == '4')
					{
						key1[i] = 4;
					}
					else
					{
						if (key[i] == '5')
						{
							key1[i] = 5;
						}
						else
						{
							if (key[i] == '6')
							{
								key1[i] = 6;
							}
							else
							{
								if (key[i] == '7')
								{
									key1[i] = 7;
								}
								else
								{
									if (key[i] == '8')
									{
										key1[i] = 8;
									}
									else
									{
										if (key[i] == '9')
										{
											key1[i] = 9;
										}
										else
										{
											if (key[i] == '0')
											{
												key1[i] = 0;
											}
											else
											{
												if (key[i] == '1')
												{
													key1[i] = 1;
												}

											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	
	m = 0;
Prikol:
	for (int i = 0; i < 26; i++)
	{
		if (mess[m] == alh[i])
		{
			k = i + key1[m];

			if (k > 25) k = k % 26;
			cmess[m] = alh[k];
			m++;
			goto Prikol;
		}
	}

	for (int i = 0; i < q; i++)
	{
		cout << cmess[i];
	}
	cout << "\n";
	system("pause");
}
