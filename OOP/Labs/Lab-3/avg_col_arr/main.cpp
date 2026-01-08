#include <iostream>

using namespace std;

const int rowSize = 3, colSize = 4;

int main()
{
    cout<<"Welcome to average of columns data program\n\n";

    int arr[rowSize][colSize];
    float avg_arr [colSize] = {0};


    printf("PLease Enter Data of Array with size %dx%d:\n",rowSize,colSize);
    for(int i = 0 ; i < rowSize ; i++){
        for(int j = 0 ; j < colSize ; j++){
            printf("array[%d,%d]: ",i,j);
            cin>>arr[i][j];
        }
    }

    for(int i = 0 ; i < colSize ; i++){
        for(int j = 0 ; j < rowSize ; j++){
            avg_arr[i] += arr[j][i];
        }
        avg_arr[i] /= rowSize;
    }

    cout<<"Array data: "<<endl;
    for(int i = 0 ; i < rowSize ; i++){
        for(int j = 0 ; j < colSize ; j++)
            cout<<arr[i][j]<<"\t";
        cout<<endl;
    }

    cout<<endl<<"avg of each column:"<<endl;
    for(auto num : avg_arr)
        cout<<num<<"\t";

    return 0;
}
