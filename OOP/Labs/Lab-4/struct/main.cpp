#include <iostream>
#include <cstring>

using namespace std;

struct employee{
    int id;
    int age;
    char name[15];
};


int main()
{
    employee e;
    employee *ptr =&e;

    cout<<"WELCOME TO STRUCT PROGRAM\n\n";

    cout<<"PLease Enter employee data:";
    cout<<"\nId: ";
    cin>>ptr ->id;

    cin.ignore();
    cout<<"\nName: ";
    cin.getline(ptr->name, 50);


    cout<<"\nAge: ";
    cin>>ptr ->age;


    cout<<"\nEmployee data:\n";
    cout<<"ID: "<<ptr->id<<"\tName: "<<ptr->name<<"\tAge: "<<ptr->age<<endl;
    return 0;
}
