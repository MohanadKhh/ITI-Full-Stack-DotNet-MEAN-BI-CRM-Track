#include <iostream>

using namespace std;

int add(int x, int y);
int sub(int x, int y);
int mult(int x, int y);
float division(int x, int y);

int main()
{
    int num1,num2;
    char op;
    char flag;

    do{
        cout<<"Enter Num 1:"<<endl;
        cin>>num1;
        cout<<"Enter Num 2:"<<endl;
        cin>>num2;
        cout<<"Enter operation (+,-,*,/):"<<endl;
        cin>>op;

        switch(op){
            case '+':
                cout<<add(num1,num2)<<endl;
                break;
            case '-':
                cout<<sub(num1,num2)<<endl;
                break;
            case '*':
                cout<<mult(num1,num2)<<endl;
                break;
            case '/':
                cout<<division(num1,num2)<<endl;
                break;
        }
        cout<<"for continue press 'Y' for exit press 'n'"<<endl;
        cin>>flag;
    }
    while (flag == 'y');

    return 0;
}

int add(int x, int y){
    return x + y;
}
int sub(int x, int y){
    return x - y;
}
int mult(int x, int y){
    return x * y;
}
float division(int x, int y){
    if(y == 0){
        cout<<"invalid number Num2 can't be 0"<<endl;
        return -1;
    }
    return (float)x / (float)y;
}
