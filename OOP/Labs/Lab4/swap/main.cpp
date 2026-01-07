#include <iostream>

using namespace std;

void swapByValue(int left, int right);
void swapByPtr(int *left, int *right);

int main()
{
    int x,y;

    cout<<"WELCOME TO A SWAP PROGRAM\n\n";

    cout<<"Please enter two number 'X' and 'Y':\n";
    cout<<"X = ";
    cin>>x;
    cout<<"Y = ";
    cin>>y;

    swapByValue(x,y);
    cout<<"\nSwapping numbers by value:\t";
    cout<<"X = "<<x<<"\tY = "<<y<<endl<<endl;

    swapByPtr(&x,&y);
    cout<<"Swapping numbers by pointer:\t";
    cout<<"X = "<<x<<"\tY = "<<y<<endl;

    return 0;
}

void swapByValue(int left, int right){
    int temp = left;
    left = right;
    right = temp;
}
void swapByPtr(int *left, int *right){
    int temp = *left;
    *left = *right;
    *right = temp;
}
