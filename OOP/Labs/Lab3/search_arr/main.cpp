#include <iostream>

using namespace std;

const int arrSize = 5;

int main()
{
    int arr[arrSize];
    int searchedValue;

    printf("PLease Enter Data of the array with size %d:\n",arrSize);
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d]: ",i);
        cin>>arr[i];
    }

    cout<<"which number you want to search on:"<<endl;
    cin>>searchedValue;

    for(int i = 0 ; i < arrSize ; i++){
        if(arr[i] == searchedValue){
            cout<<"\nDone at index "<<i<<endl;
            return 0;
        }
    }

    cout<<"\n1This value not found in array"<<endl;

    return 0;
}
