#include <iostream>

using namespace std;

int main()
{
    cout<<"WELCOME TO POINTER TO POINTER PROGRAM\n\n";

    int x;
    int *ptr = &x;
    int **ptrToPtr = &ptr;

    cout<<"Please Enter Number: ";
    cin>>x;

    cout<<"\nReading your input through pointer to pointer: "<<**ptrToPtr<<endl;

    return 0;
}
