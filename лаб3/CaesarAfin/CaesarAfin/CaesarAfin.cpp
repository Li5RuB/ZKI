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
int k;
char* mess = new char[q];
char* cmess = new char[q];
int main()
{
    cout << "SHIFR CEZAR AFIN" << endl;
    cout << "Enter your key A : ";
    cin >> a;
    cout << "Enter your key B : ";
    cin >> b;
    cout << "Enter your mess : ";
    cin >> mess;
    q = strlen(mess);
    m = 0;
    Prikol:
    for (int i = 0; i < 26; i++)
    {
        if (mess[m] == alh[i])
        {   
            k = a*i+b;
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

