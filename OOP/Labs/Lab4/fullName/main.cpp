#include <iostream>
#include <cstring>

using namespace std;

int main()
{
    cout<<"WELCOME TO FULLNAME PROGRAM\n\n";

    char fName[15];
    char lName[15];
    char fullName[30];

    cout<<"Please Enter you first name: ";
    cin>>fName;

    cout<<"Please Enter you last name: ";
    cin>>lName;

    strcpy(fullName,fName);
    strcat(fullName," ");
    strcat(fullName,lName);
    cout<<"Your FullName is "<<fullName<<endl;

    return 0;
}
