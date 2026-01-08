#include <iostream>

using namespace std;

const int SIZE = 5;

class Stack
{
private:
    int *arr;
    int stackSize;
    int sp;
    //static int counter;

public:
    Stack(){
        stackSize = SIZE;
        arr = new int[stackSize];
        sp = 0;
        //counter++;
        //cout<<"\nConstructor without param was called\n";
    }

    Stack(int stackSize){
        this -> stackSize = stackSize;
        arr = new int[stackSize];
        sp = 0;
        //counter++;
        //cout<<"\nConstructor with size param was called\n";
    }

    Stack(const Stack &other) {
        stackSize = other.stackSize;
        sp = other.sp;
        arr = new int[stackSize];
        for (int i = 0; i < sp; i++) {
            arr[i] = other.arr[i];
        }
        //counter++;
        //cout << "\nCopy constructor was called\n";
    }


    void push(int value){
        if(!isStackFull()){
            arr[sp] = value;
            sp++;
        }
        else
            cout<<"The stack is full!!\n";
    }

    int pop(){
        if(!isStackEmpty()){
            sp--;
            return arr[sp];
        }
        else
            cout<<"The stack is empty!!\n";
    }

//    static int getCounter(){
//        return counter;
//    }

    int isStackFull(){
        return sp>=stackSize;
    }

    int isStackEmpty(){
        return sp<=0;
    }

    Stack& operator=(Stack right){
        stackSize = right.stackSize;
        sp = right.sp;
        delete arr;
        arr = new int [right.stackSize];
        for(int i = 0 ; i < right.sp ; i++){
            arr[i] = right.arr[i];
        }
        return *this;
    }

    Stack reverseStack (){
        Stack res;
        res.sp = sp;
        res.stackSize = stackSize;

        delete res.arr;
        res.arr = new int [stackSize];

        int j = 0;
        for (int i = sp - 1 ; i >= 0 ; i--){
            res.arr[j] = arr[i];
            j++;
        }
        return res;
    }

    ~Stack(){
        //counter--;
        for(int i = 0 ; i < sp ; i++){
            arr[i] = -1;
        }
        delete arr;
        //cout<<"\nDestructor of stack was called\n";
    }

    friend void viewStack(Stack s);
};

void viewStack(Stack s){
    cout<<"Stack values:\t";
    for(int i = 0 ; i < s.sp ; i++){
        cout<<s.arr[i]<<"\t";
    }
}

int main()
{
    Stack s1(10);
    Stack s2;

    for(int i = 3 ; i<9 ; i++)
        s1.push(i);

    viewStack(s1);

    s1.pop();

    cout<<"\n\nAfter pop:\n";
    viewStack(s1);

    cout<<"\n\nResult of S1 = S2: \n";
    s2 = s1;
    cout<<"\[S2] ";
    viewStack(s2);


    cout<<"\n\nResult of reverse S1: \n";
    s2 = s1.reverseStack();
    viewStack(s2);

    cout<<endl<<endl;
    return 0;
}
