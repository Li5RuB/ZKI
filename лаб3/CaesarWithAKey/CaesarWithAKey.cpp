#include <stdio.h>
typedef unsigned char uchar;
// Формируем таблицу перевода. keyAlpha будет содержать таблицу ключей
bool convertAlphaBet(uchar* Alphabet, uchar* key, int k, uchar keyAlpha[256])
{
    bool res = false;
    int lenght = 0;
    if (Alphabet != NULL)
    {
        while (Alphabet[lenght] != 0) lenght++;
        if (lenght >= 256) lenght = 0;
    }
    if ((lenght > 0) && (keyAlpha != NULL) && (key != NULL)
        && (k < lenght) && (k >= 0))
    {
        uchar let[256] = { 0 };
        int i = 0;
        while (i < 256) keyAlpha[i++] = 0;
        i = 0;
        while ((i < lenght) && (key[i] != 0))                 // Цикл для ключа
        {

            if (let[key[i]] == 0)
            {
                keyAlpha[Alphabet[k++]] = key[i];
                if (k == lenght) k = 0;
                let[key[i]] = 1;
            }
            i++;
        }
        int z = 0;
        while (i < lenght)                                  // Цикл для отсавшихся букв алфавита
        {
            if (let[Alphabet[z]] == 0)
            {
                keyAlpha[Alphabet[k++]] = Alphabet[z];
                if (k == lenght) k = 0;
                let[Alphabet[z]] = 1;
                i++;
            }
            z++;

        }
        res = true;
    }
    return res;
}
// Шифрование
bool Crypt(uchar keyAlpha[256], uchar* src, uchar* crp)
{
    bool res = false;
    if ((src != NULL) && (crp != NULL))
    {
        int i = 0;
        while (src[i] != 0)
        {
            if (keyAlpha[src[i]] != 0) crp[i] = keyAlpha[src[i]];
            else crp[i] = src[i];
            i++;
        }
        crp[i] = 0;
        res = true;
    }
    return res;
}
// расшифровка
bool Encrypt(uchar keyAlpha[256], uchar* src, uchar* crp)
{
    bool res = false;
    if ((src != NULL) && (crp != NULL))
    {
        int i = 0;
        int z = 0;
        while (src[i] != 0)
        {
            z = 0;
            while ((z < 256) && (keyAlpha[z] != src[i])) z++;
            if (z == 256) crp[i] = src[i];
            else crp[i] = (uchar)z;
            i++;
        }
        crp[i] = 0;
        res = true;
    }
    return res;
}
int main(int argv, char** argc)
{
    if (argv == 2)
    {
        uchar AlphaBet[] = "abcdefghijklmnopqrstuvwxyz";  // Алфавит 
        uchar key[] = "klin";                             // Ключевое слово 
        int k = 7;                                        // Смешение
        uchar keyAlpha[256];
        uchar* Phr = NULL;
        uchar* EnPhr = NULL;
        if (convertAlphaBet(AlphaBet, key, k, keyAlpha))
        {
            int len = 0;
            while (argc[1][len] != 0) len++;
            len++;
            Phr = new uchar[len];
            EnPhr = new uchar[len];
            if (Phr != NULL)
            {
                if (Crypt(keyAlpha, (uchar*)argc[1], Phr))
                {
                    printf("%s\n", Phr);
                    Encrypt(keyAlpha, Phr, EnPhr);
                    printf("%s\n", EnPhr);
                }

            }

        }
        if (Phr != NULL) delete[] Phr;
        if (EnPhr != NULL) delete[] EnPhr;
    }
    return 0;
}