#include <iostream>
#include <limits.h>

using namespace std;

const int arrSize = 5;

int main()
{
    cout<<"Welcome to array sorted program\n\n";

    int arr[arrSize];

    printf("PLease Enter Data of the array with size %d:\n",arrSize);
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d]: ",i);
        cin>>arr[i];
    }

    for(int i = 0 ; i < arrSize - 1 ; i++){
        int minNum = arr[i];
        int lowIndex = i;
        int temp;

        for(int j = i + 1 ; j < arrSize ; j++){
            if (arr[j]<minNum){
                minNum = arr[j];
                lowIndex = j;
            }
        }

        temp = arr[i];
        arr[i] = arr[lowIndex];
        arr[lowIndex] = temp;
    }

    cout<<endl<<"Array after sorted:"<<endl;
    for(auto num : arr)
        cout<<num<<"\t";

    return 0;
}
