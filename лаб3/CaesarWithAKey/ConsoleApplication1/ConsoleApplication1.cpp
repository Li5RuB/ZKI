#include <iostream>
#include <map>
#include <vector>
#include <string>
#include <algorithm>
using namespace std;
vector<char> vectorABC0 =
{ 'A', 'B', 'C', 'D',
 'E', 'F', 'G', 'H',
 'I', 'J', 'K', 'L',
 'M', 'N', 'O', 'P',
 'Q', 'R', 'S', 'T',
 'U', 'V', 'W', 'X',
 'Y', 'Z' };
vector<char> vectorABC2 = vectorABC0;

map<char, unsigned> mapABC;
map<char, char> crypto_mapABC;

int main()
{
    string messge, crypto_message;
    unsigned itABC = 0, shift = 0;

    cout << "SHIFR CEZAR FOR KEY" << endl;
    cout << "Enter you message : "; cin >> messge;
  
    cout << "Enter shift : "; cin >> shift; itABC = shift;

    for (unsigned i = 0; i < vectorABC0.size(); i++) mapABC.insert({ vectorABC0[i],i });


    for (unsigned i = 0; i < messge.size(); i++, itABC++)
    {
        crypto_mapABC.insert({ vectorABC0[itABC],messge[i] });
        vectorABC2.erase(remove(vectorABC2.begin(), vectorABC2.end(), messge[i]), vectorABC2.end());
    }

    for (auto c : vectorABC2)
    {
        cout << vectorABC0[itABC] << " : " << c << endl;
        crypto_mapABC.insert({ vectorABC0[itABC], c });
        itABC = ((itABC + 1) % vectorABC0.size());
    }

    for (auto c : messge)
        crypto_message.push_back(crypto_mapABC[c]);

    cout << "You crypto message : " << crypto_message << endl;
    return 0;
}
