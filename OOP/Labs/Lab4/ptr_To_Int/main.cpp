#include <iostream>

using namespace std;

int main()
{
    cout<<"WELCOME TO POINTER TO INTEGER PROGRAM\n\n";

    int x;
    int *ptr = &x;

    cout<<"Please Enter Number:\n";
    cin>> *ptr;

    cout<<"\nReading your input through pointer:\n";
    cout<< *ptr<<endl;
    return 0;
}
