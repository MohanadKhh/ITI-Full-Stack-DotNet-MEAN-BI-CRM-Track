#include <iostream>
#include <limits.h>

using namespace std;

const int arrSize = 5;

int main()
{
    cout<<"Welcome to array's min and max program\n\n";

    int arr[arrSize];
    int maxNum = INT_MIN, minNum = INT_MAX;

    printf("PLease Enter Data of the array with size %d:\n",arrSize);
    for(int i = 0 ; i < arrSize ; i++){
        printf("Array[%d]: ",i);
        cin>>arr[i];
    }

    for(auto num : arr){
        if (num>maxNum)
            maxNum = num;
        if (num<minNum)
            minNum = num;
    }

    cout<<"Maximum number in array is "<<maxNum<<endl;
    cout<<"Minimum number in array is "<<minNum<<endl;

    return 0;
}
