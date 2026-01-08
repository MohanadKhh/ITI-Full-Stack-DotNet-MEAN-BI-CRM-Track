#include <iostream>

using namespace std;

int main()
{
    int *ptr = new int;

    cout<<"WELCOME TO DYNAMIC ALLOCATION TO INTEGER\n\n";

    cout<<"Please enter number: ";
    cin>>*ptr;

    cout<<"\n\nYour number is: "<<*ptr<<endl;
    delete ptr;

    return 0;
}
