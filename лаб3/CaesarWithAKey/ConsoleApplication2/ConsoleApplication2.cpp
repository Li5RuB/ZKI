#include <iostream>
using namespace std;

char alh[26] = { 'A', 'B', 'C', 'D',
 'E', 'F', 'G', 'H',
 'I', 'J', 'K', 'L',
 'M', 'N', 'O', 'P',
 'Q', 'R', 'S', 'T',
 'U', 'V', 'W', 'X',
 'Y', 'Z' };
int k = 0;
int n;
int m;
int q;
int key;
char alh1[26];
char* cmess = new char[q];
char* keyw = new char[n];
char* mess = new char[m];
int main()
{
    cout << "SHIFR CEZAR WITH KEY" << endl;
    cout << "Enter your key word : ";
    cin >> keyw;
    n = strlen(keyw);
    cout << "Enter your key : ";
    cin >> key;
    cout << "Enter your mess: ";
    cin >> mess;
    m = strlen(mess);
    for (int i = key; i < 26; i++)
    {
        alh1[i] = keyw[k];
        k++;

    }
    int flag = 0;
    k = key+n;
    if (k > 25)
    {
        k -= 26;
    }
    for (int i = 0; i < 26; i++)
    {   

        for (int J = 0; J < n; J++)
        {   
            if (alh[i] != keyw[J])
            {
                flag = 1;
            }
            else
            {
                flag = 0;
                break;
            }
            
        }
        if (flag == 1)
        {
            if (k > 25) k -= 26;
            alh1[k] = alh[i];
            k++;
            flag = 0;
        }
    }
    k = 0;
    flag = 0;

    q = m;
    Prikol:
    for (int i = 0; i < 26; i++)
    {
        if (mess[flag] == alh[i])
        {
            k = i;
            cmess[flag] = alh1[k];
            flag ++;
            goto Prikol;
        }
    }
    
    for (int i = 0; i < 26; i++)
    {
        cout << alh[i];
    }
    cout << "\n";
    for (int i = 0; i < 26; i++)
    {
        cout << alh1[i];
    }
    cout << "\n";
    for (int i = 0; i < q; i++)
    {
        cout << cmess[i];
    }
    cout << "\n";
    system("pause");
}

