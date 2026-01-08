#include <iostream>
#include <string>

using namespace std;

int main()
{
    cout<<"Welcome to String reversing program\n\n";

    string str;

    cout<<"Please Enter String: ";
    cin>>str;

    for (int i = 0; i < str.length()/2 ; i++){
        char temp = str[i];
        str[i] = str[str.length() - 1 - i];
        str[str.length() - 1 - i] = temp;
    }

    cout<<"String after reversed: "<<str<<endl;
    return 0;
}
