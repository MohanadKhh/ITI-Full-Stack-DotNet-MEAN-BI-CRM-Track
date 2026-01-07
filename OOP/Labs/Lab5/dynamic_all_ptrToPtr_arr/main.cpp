#include <iostream>

using namespace std;

const int rowSize = 3;
const int colSize = 4;

int main()
{
    int **ptrArr = new int *[rowSize];

    for(int i = 0 ; i < rowSize ; i++){
        ptrArr[i] = new int [colSize];
    }

    printf("Please enter array numbers of size %dx%d:\n", rowSize,colSize);
    for(int i = 0 ; i < rowSize ; i++){
        for(int j = 0 ; j < colSize ; j++){
            printf("Array[%d][%d]: ", i,j);
            cin>>ptrArr[i][j];
        }
    }

    cout<<"\nData of array that you entered is:\n";
    for(int i = 0 ; i < rowSize ; i++){
        printf("Array[%d]:\t", i);
        for(int j = 0 ; j < colSize ; j++){
            cout<<ptrArr[i][j]<<"\t";
        }
        cout<<endl;
    }
    cout<<endl;

    for(int i = 0 ; i < rowSize ; i++){
        delete ptrArr[i];
    }
    delete ptrArr;

    return 0;
}
