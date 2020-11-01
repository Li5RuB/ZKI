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

char* minikey = new char[a];
char* mess = new char[q];
char* cmess = new char[q];
int main()
{
	cout << "SHIFR Visaner" << endl;
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

	m = 0;
Prikol:
	for (int i = 0; i < 26; i++)
	{
		if (mess[m] == alh[i])
		{
			k = i;
			for (int i = 0; i < 26; i++)
			{
				if (key[m]==alh[i])
				{
					k += i;
					if (k > 25)
						k = k - 26;
					cmess[m] = alh[k];
				}
			}

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
