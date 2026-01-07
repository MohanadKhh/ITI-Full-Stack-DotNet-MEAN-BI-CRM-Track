#include <iostream>

using namespace std;

const int arrSize = 5;

int main()
{
    cout<<"WELCOME TO POINTER TO ARRAY PROGRAM\n\n";

    int arr [arrSize];
    int *ptr = arr;

    cout<<"__________first way_________\n\n";
    cout<<"please Enter array of size "<<arrSize<<" :\n";
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d] : " ,i);
        cin>>*ptr;
        ptr++;
    }
    ptr = arr;

    cout<<"\nReading your input array through pointer:\n";
    cout<<"Your array:\t";
    for(int i = 0 ; i < arrSize ; i++){
        cout<<*ptr<<"\t";
        ptr++;
    }
    ptr = arr;

    cout<<"\n\n__________Second way_________\n\n";
    cout<<"please Enter array of size "<<arrSize<<" :\n";
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d] : " ,i);
        cin>>*(ptr + i);
    }

    cout<<"\nReading your input array through pointer:\n";
    cout<<"Your array:\t";
    for(int i = 0 ; i < arrSize ; i++){
        cout<<*(ptr + i)<<"\t";
    }

    cout<<"\n\n__________Third way_________\n\n";
    cout<<"please Enter array of size "<<arrSize<<" :\n";
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d] : " ,i);
        cin>>ptr[i];
    }

    cout<<"\nReading your input array through pointer:\n";
    cout<<"Your array:\t";
    for(int i = 0 ; i < arrSize ; i++){
        cout<<ptr[i]<<"\t";
    }

    return 0;
}
