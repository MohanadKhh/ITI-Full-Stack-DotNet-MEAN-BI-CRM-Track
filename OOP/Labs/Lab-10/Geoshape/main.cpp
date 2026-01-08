#include <iostream>

using namespace std;

class Geoshape
{
protected:
    double dim1;
    double dim2;

public:
    Geoshape(){
        dim1=dim2=0;
    }

    Geoshape(double _dim){
        dim1 = dim2 = _dim;
    }

    Geoshape(double _dim1, double _dim2){
        dim1 = _dim1;
        dim2 = _dim2;
    }

    void SetDim1(double _dim1){
        dim1=_dim1;
    }

    double GetDim1(){
        return dim1;
    }

    void SetDim2(double _dim2){
        dim2=_dim2;
    }

    double GetDim2(){
        return dim2;
    }

    virtual double Area()=0;

    ~Geoshape(){
    }
};

class MyRec : public Geoshape
{
public:
    MyRec(){}

    MyRec(double _dim1, double _dim2) : Geoshape(_dim1,_dim2){}

    double Area(){
        return dim1*dim2;
    }
};

class MyCircle : public Geoshape
{
public:
    MyCircle(){}

    MyCircle(double _rad) : Geoshape(_rad){}

    double Area(){
        return dim1*dim2*3.14;
    }
};


class MySquare : public Geoshape
{
public:
    MySquare(){}

    MySquare(double _side) : Geoshape(_side){}

    double Area(){
        return dim1*dim1;
    }
};


class MyTri : public Geoshape
{
public:
    MyTri(){}

    MyTri(double _height, double _base) : Geoshape(_base,_height){}

    double Area(){
        return dim1*dim2*0.5;
    }
};

double sumOfAreasV1(MyRec *recArr, int recSize, MyCircle *cirArr, int cirSize, MySquare *sqrArr, int sqrSize, MyTri *triArr, int triSize){
    double sum = 0;

    for (int i = 0 ; i<recSize ; i++){
        sum += recArr[i].Area();
    }

    for (int i = 0 ; i<cirSize ; i++){
        sum += cirArr[i].Area();
    }

    for (int i = 0 ; i<sqrSize ; i++){
        sum += sqrArr[i].Area();
    }

    for (int i = 0 ; i<triSize ; i++){
        sum += triArr[i].Area();
    }

    return sum;
}

double sumOfAreasV2(Geoshape **geoPtrArr , int shapesSize){
    double sum = 0;

    for (int i = 0 ; i<shapesSize ; i++){
        sum += geoPtrArr[i] -> Area();
    }
    return sum;
}

const int REC_SIZE = 3;
const int SQR_SIZE = 2;
const int TRI_SIZE = 2;
const int CIR_SIZE = 1;

int main()
{
    MyRec recArr[REC_SIZE] = {MyRec(3,5), MyRec(4,6), MyRec(1,2)};
    MySquare sqrArr[SQR_SIZE] = {MySquare(3), MySquare(4)};
    MyCircle cirArr[CIR_SIZE] = {MyCircle(10)};
    MyTri triArr[TRI_SIZE] = {MyTri(1,3), MyTri(5,2)};

    Geoshape *geoptr[REC_SIZE + CIR_SIZE + TRI_SIZE + SQR_SIZE] = {
        recArr, &recArr[1], &recArr[2], sqrArr, &sqrArr[1], cirArr, triArr, &triArr[1]};

    cout<<"Sum Of Areas Version(1) = " << sumOfAreasV1(recArr,REC_SIZE,cirArr,CIR_SIZE,sqrArr,SQR_SIZE, triArr,TRI_SIZE)<<endl;

    cout<<"Sum of Areas Version(2) = "<<sumOfAreasV2(geoptr,REC_SIZE + CIR_SIZE + TRI_SIZE + SQR_SIZE)<<endl;

    return 0;
}
