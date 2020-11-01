

#include <iostream>
int n;
char* str = new char[n];
int k = 0;
int rows=0;
int cols=0;

void vvod()
{
    std::cout << "Введите сообщение: ";
    std::cin >> str;
    n = strlen(str);
    
    std::cout << "Введите количество колонок табицы ";
    std::cin >> cols;
    std::cout << "\n";
    if (n % 2 == 0) {
        rows = n / cols;
    }
    else rows = (n / cols) + 1;
}
void shif()
{   
    char** mx = new char* [rows];
    for (int i = 0; i < rows; i++)
    {
        mx[i] = new char[cols];
    }

    
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (k < n){
            mx[i][j] = str[k];
            k += 1;
            }else if (k = n)
            {
                mx[i][j] = ' ';
            }

            else mx[i][j] = ' ';
            
        }
    }
    std::cout << "Заполненая таблица";
    std::cout << "\n";
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            
            std::cout << mx[i][j]<< " ";
            
        }
        std::cout << "\n";
    }

    std::cout << "Зашифрованное сообщение";
    std::cout << "\n";
    for (int i = 0; i < cols; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            if (mx[j][i] != ' ')
            std::cout << mx[j][i];

        }
       
    }
    std::cout << "\n";
}

int main()
{   
    setlocale(LC_ALL, "Russian");
    vvod();
    shif();
    system("pause");
}

