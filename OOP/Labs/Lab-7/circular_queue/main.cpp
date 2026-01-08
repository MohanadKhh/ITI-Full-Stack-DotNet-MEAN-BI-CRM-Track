#include <iostream>

using namespace std;

const int SIZE = 5;

class Queue
{
private:
    int frontqp;
    int backqp;
    int* arr;
    int queueSize;
    int flag = 0;

public:
    Queue(){
        frontqp = -1;
        backqp = -1;
        queueSize = SIZE;
        arr = new int[queueSize];
    }

    void enqueue(int value){
        if(isQueueFull()){
            cout<<"Queue is full\n";
        }
        else if (frontqp == -1){
            frontqp = 0;
            backqp = 0;
            arr[backqp] = value;
        }
        else{
            backqp = (backqp + 1) % queueSize;
            arr[backqp] = value;
        }
    }

    int dequeue(){
        if(isQueueEmpty()){
            cout<<"Queue is Empty!!\n";
        }
        else if (frontqp == backqp){
            int res = arr[frontqp];
            frontqp = -1;
            backqp = -1;
            return res;
        }
        else{
            int res = arr[frontqp];
            frontqp = (frontqp + 1) % queueSize;
            return res;
        }
    }

    int isQueueFull(){
        return (backqp + 1) % queueSize == frontqp;
    }

    int isQueueEmpty(){
        return frontqp == -1;
    }

    void viewQueue(){
        cout<<"Queue values:\t";
        if(backqp >= frontqp){
            for(int i = backqp ; i >= frontqp ; i--)
                cout<<arr[i]<<"\t";
            cout<<endl;
        }
        else{
            for(int i = backqp ; i >= 0 ; i--)
                cout<<arr[i]<<"\t";
            for(int i = queueSize - 1 ; i >= frontqp ; i--)
                cout<<arr[i]<<"\t";
            cout<<endl;
        }
    }

    ~Queue(){
        for(int i = 0 ; i < queueSize ; i++){
            arr[i] = -1;
        }
        delete arr;
    }
};

int main()
{
    Queue q1;

    for(int i = 3 ; i<9 ; i++)
        q1.enqueue(i);

    q1.viewQueue();

    cout<<"\n\nLast number in queue: "<<q1.dequeue()<<endl<<endl;

    q1.viewQueue();

    return 0;
}
