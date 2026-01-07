#include <iostream>

using namespace std;

const int rowSize1 = 3, colSize1 = 3;
const int rowSize2 = 3, colSize2 = 2;

int main()
{
    cout<<"Welcome to Matrix Multiplication program\n\n";

    if(colSize1 != rowSize2){
        cout<<"Multiplication between these two matrices not valid"<<endl;
        return 0;
    }

    int arr1[rowSize1][colSize1];
    int arr2[rowSize2][colSize2];

    int res_arr [rowSize1][colSize2] = {0};

    printf("PLease Enter Data of Matrix(1) with size %dx%d:\n",rowSize1,colSize1);
    for(int i = 0 ; i < rowSize1 ; i++){
        for(int j = 0 ; j < colSize1; j++){
            printf("Matrix(1)[%d,%d]: ",i,j);
            cin>>arr1[i][j];
        }
    }

    printf("PLease Enter Data of Matrix(1) with size %dx%d:\n",rowSize2,colSize2);
    for(int i = 0 ; i < rowSize2 ; i++){
        for(int j = 0 ; j < colSize2 ; j++){
            printf("Matrix(2)[%d,%d]: ",i,j);
            cin>>arr2[i][j];
        }
    }

    for(int k = 0 ; k < colSize2 ; k++){
        for(int i = 0 ; i < rowSize1 ; i++){
            for(int j = 0 ; j<colSize1 ; j++){
                res_arr[i][k]+= arr1[i][j] * arr2[j][k];
            }
        }
    }

    cout<<endl<<"Matrix(1):"<<endl;
    for(int i = 0 ; i < rowSize1 ; i++){
        for(int j = 0 ; j < colSize1 ; j++){
            cout<<arr1[i][j]<<"\t";
        }
        cout<<endl;
    }

    cout<<endl<<"Matrix(2):"<<endl;
    for(int i = 0 ; i < rowSize2 ; i++){
        for(int j = 0 ; j < colSize2 ; j++){
            cout<<arr2[i][j]<<"\t";
        }
        cout<<endl;
    }

    cout<<endl<<"Result of two matrices multiplication:"<<endl;
    for(int i = 0 ; i < rowSize1 ; i++){
        for(int j = 0 ; j < colSize2 ; j++){
            cout<<res_arr[i][j]<<"\t";
        }
        cout<<endl;
    }

    return 0;
}
