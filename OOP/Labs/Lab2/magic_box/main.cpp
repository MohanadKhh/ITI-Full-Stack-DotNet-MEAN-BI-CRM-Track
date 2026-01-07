#include <stdlib.h>
#include <windows.h>
#include<iostream>
using namespace std;
void gotoxy( int column, int row )
{
    COORD coord;
    coord.X = column;
    coord.Y = row;
    SetConsoleCursorPosition(GetStdHandle( STD_OUTPUT_HANDLE ),coord);
}
int main()
{
    int size = 3;
    int row;
    int col;
    row=1;
    col=size/2 +1;

    for(int i=1;i<=size*size;i++)
    {
        gotoxy(col*3,row*3);
        cout<<i;
        //process before i became 2
        if(i%size!=0) //reminder
        {
            row--;
            col--;
            if(col<1){col=size;}
            if(row<1){row=size;}
        }
        else  //no reminder
        {
            row++;
        }
    }
    return 0;
}
