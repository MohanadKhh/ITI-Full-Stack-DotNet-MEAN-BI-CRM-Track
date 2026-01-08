#include <iostream>

using namespace std;

const int arrSize = 5;

void arrPassByValue(int arr[], int Size);
void arrPassByPtr(int *ptr, int Size);

int main()
{
    int arr[arrSize];

    cout<<"WELCOME TO Array PARAMETER PROGRAM\n\n";

    cout<<"please Enter array of size "<<arrSize<<" :\n";
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d] : " ,i);
        cin>>arr[i];
    }

    arrPassByValue(arr, arrSize);

    arrPassByPtr(arr, arrSize);

    return 0;
}


void arrPassByValue(int arr[], int Size){
    cout<<"\n\nPrinting array passed by value:\n";
    for(int i = 0 ; i < Size ; i++){
        cout<<arr[i]<<"\t";
    }
}

void arrPassByPtr(int *ptr, int Size){
    cout<<"\n\nPrinting array passed by pointer:\n";
    for(int i = 0 ; i < Size ; i++){
        cout<<ptr[i]<<"\t";
    }
}
