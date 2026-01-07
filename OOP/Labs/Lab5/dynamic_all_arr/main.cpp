#include <iostream>

using namespace std;

const int arrSize = 3;

int main()
{
    int *ptr = new int [arrSize];

    cout<<"WELCOME TO DYNAMIC ALLOCATION TO ARRAY\n\n";

    printf("Please enter array numbers of size %d:\n", arrSize);
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d]: ", i);
        cin>>*(ptr + i);
    }


    cout<<"Data of array that you entered is:\t";
    for(int i = 0 ; i < arrSize ; i++){
        cout<<*(ptr + i)<<"\t";
    }
    cout<<endl;

    delete ptr;

    return 0;
}
