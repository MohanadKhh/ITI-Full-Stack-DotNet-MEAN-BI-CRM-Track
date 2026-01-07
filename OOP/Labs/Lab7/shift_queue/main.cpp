#include <iostream>

using namespace std;

const int SIZE = 5;

class Queue
{
private:
    int qp;
    int* arr;
    int queueSize;

public:
    Queue(){
        qp = 0;
        queueSize = SIZE;
        arr = new int[queueSize];
    }

    Queue(const Queue &other) {
        queueSize = other.queueSize;
        qp = other.qp;
        arr = new int[queueSize];
        for (int i = 0; i < qp; i++) {
            arr[i] = other.arr[i];
        }
    }

    void enqueue(int value){
        if(!isQueueFull()){
            for(int i = qp ; i > 0 ; i--){
            arr[i] = arr [i-1];
            }
            arr[0] = value;
            qp++;
        }
        else
            cout<<"Queue is Full!!\n";
    }

    int dequeue(){
        if(!isQueueEmpty()){
            qp--;
            return arr[qp];
        }
        else
            cout<<"Queue is Empty!!\n";
    }

    int isQueueFull(){
        return qp>=queueSize;
    }

    int isQueueEmpty(){
        return qp<=0;
    }

    void viewQueue(){
        cout<<"Queue values:\t";
        for(int i = 0 ; i < qp ; i++)
            cout<<arr[i]<<"\t";
        cout<<endl;
    }

    ~Queue(){
        for(int i = 0 ; i < qp ; i++){
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

    cout<<"\nLast number in queue: "<<q1.dequeue()<<endl<<endl;

    cout<<"Last number in queue: "<<q1.dequeue()<<endl<<endl;

    q1.viewQueue();

    q1.enqueue(100);

    q1.viewQueue();

    return 0;
}
