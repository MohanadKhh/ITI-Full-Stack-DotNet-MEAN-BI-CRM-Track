#include <iostream>
#include "graphics.h"

using namespace std;

class Shape
{
protected:
    int myColor;

public:
    Shape(){
        myColor=0;
    }

    Shape(int _color){
        myColor=_color;
    }

    int getColor(){
        return myColor;
    }

    void setColor(int _color){
        myColor = _color;
    }

    ~Shape(){}
};

class MyPoint
{
private:
    float x;
    float y;

public:
    MyPoint(){
        x=y=0;
    }

    MyPoint(float x, float y){
        this->x = x;
        this->y = y;
    }

    MyPoint(const MyPoint &old){
        x = old.x;
        y = old.y;
    }

    float getX(){
        return x;
    }

    float getY(){
        return y;
    }

    void setX(float x){
        this->x = x;
    }

    void setY(float y){
        this->y = y;
    }

    ~MyPoint(){}
};

class MyCircle : public Shape
{
private:
    MyPoint center;
    int radius;

public:
    MyCircle(){}

    MyCircle(float cX, float cY, int rad, int color)
    :center(cX,cY),Shape(color)
    {
        radius = rad;
    }

    MyCircle(const MyCircle &old){
        center = old.center;
        radius = old.radius;
        myColor = old.myColor;
    }

    MyPoint getCenter(){
        return center;
    }

    int getRadius(){
        return radius;
    }

    void setCenter(MyPoint cent){
        center = cent;
    }

    void setRadius(int rad){
        radius = rad;
    }

    void drawCircle(){
        setcolorRGB(myColor,myColor,myColor);
        circle(center.getX(),center.getY(), radius);
    }

    ~MyCircle(){}
};


class MyLine : public Shape
{
private:
    MyPoint start;
    MyPoint endd;

public:
    MyLine(){}

    MyLine(float stX, float stY, float endX, float endY, int _color)
    :start(stX,stY), endd(endX,endY),Shape(_color){}

    MyLine (const MyLine &old){
        start = old.start;
        endd = old.endd;
        myColor = old.myColor;
    }

    MyPoint getStartPoint(){
        return start;
    }

    MyPoint getEndPoint(){
        return endd;
    }

    void setStartPoint(MyPoint _start){
        start = _start;
    }

    void setEndPoint(MyPoint _end){
        endd = _end;
    }

    void drawLine(){
        setcolor(myColor);
        line(start.getX(), start.getY(), endd.getX(), endd.getY());
    }

    ~MyLine(){}
};

class MyTriangle : public Shape
{
private:
    MyPoint A;
    MyPoint B;
    MyPoint C;

public:
    MyTriangle(){}

    MyTriangle(float AX, float AY, float BX, float BY, float CX, float CY, int _color)
    :A(AX,AY),B(BX,BY),C(CX,CY),Shape(_color){}

    MyTriangle(const MyTriangle &old){
        A = old.A;
        B = old.B;
        C = old.C;
        myColor = old.myColor;
    }

    MyPoint getPointA(){
        return A;
    }

    MyPoint getPointB(){
        return B;
    }

    MyPoint getPointC(){
        return C;
    }

    void setPointA(MyPoint _A){
        A = _A;
    }

    void setPointB(MyPoint _B){
        B = _B;
    }

    void setPointC(MyPoint _C){
        C = _C;
    }

    void drawTriangle(){
        setcolor(myColor);

        line(A.getX(),A.getY(),B.getX(),B.getY());
        line(C.getX(),C.getY(),B.getX(),B.getY());
        line(A.getX(),A.getY(),C.getX(),C.getY());
    }

    ~MyTriangle(){}
};

class MyRectangle : public Shape
{
private:
    MyPoint ul;
    MyPoint br;

public:
    MyRectangle(){}

    MyRectangle(float AX, float AY, float BX, float BY, int _color)
    :ul(AX,AY),br(BX,BY),Shape(_color){}

    MyRectangle(const MyRectangle &old){
        ul = old.ul;
        br = old.br;
        myColor = old.myColor;
    }

    MyPoint getUL(){
        return ul;
    }

    MyPoint getBR(){
        return br;
    }

    void setPointUL(MyPoint _ul){
        ul = _ul;
    }

    void setPointBR(MyPoint _br){
        br = _br;
    }

    void drawRec(){
        setcolor(myColor);
        rectangle(ul.getX(),ul.getY(),br.getX(),br.getY());
    }

    ~MyRectangle(){}
};

class Picture
{
private:
    MyLine *linePtr;
    int lineSize;
    MyCircle *cirPtr;
    int cirSize;
    MyRectangle *recPtr;
    int recSize;
    MyTriangle *triPtr;
    int triSize;

public:
    Picture(){
        linePtr = NULL;
        triPtr = NULL;
        cirPtr = NULL;
        recPtr = NULL;
        recSize = cirSize = lineSize = triSize = 0;
    }

    void setLines(MyLine *_lPtr,int _lSize){
        linePtr = _lPtr;
        lineSize = _lSize;
    }

    void setRectangles(MyRectangle *_rPtr,int _rSize){
        recPtr = _rPtr;
        recSize = _rSize;
    }

    void setCircles(MyCircle *_cPtr,int _cSize){
        cirPtr = _cPtr;
        cirSize = _cSize;
    }

    void setTriangles(MyTriangle *_tPtr,int _tSize){
        triPtr = _tPtr;
        triSize = _tSize;
    }

    void drawPicture(){
        for (int i = 0; i<lineSize ; i++)
            linePtr[i].drawLine();

        for (int i = 0; i<cirSize ; i++)
            cirPtr[i].drawCircle();

        for (int i = 0; i<recSize ; i++)
            recPtr[i].drawRec();

        for (int i = 0; i<triSize ; i++)
            triPtr[i].drawTriangle();
    }
};

const int LINES = 4;
const int CIRCLES = 2;
const int RECTANGLES = 1;
const int TRIANGLES = 2;


int main()
{
    initgraph();

    MyLine lineArr [LINES] = {
        MyLine (201,433,201,515,200),   //left bottom line
        MyLine (255,433,255,515,200),   //right bottom line
        MyLine (178,174,157,366,15),   //left upper line
        MyLine (276,174,300,366,15)};  //right upper line

    //Filling gap of abajora
    for (int i = 178;i<270 ;i++ ){
        MyLine l(i,174,i-25,366,15);
        l.drawLine();
    }

    for (int i = 240;i<276 ;i++ ){
        MyLine l(i,174,i+25,366,15);
        l.drawLine();
    }

    MyCircle cirArr[CIRCLES] = {
        MyCircle (227,364,150,169),      //large circle
        MyCircle (227,174,100,169)};     //small circle

    MyRectangle recArr[RECTANGLES] = {MyRectangle (36,515,430,590,200)};     //bottom rectangle

    MyTriangle triArr [TRIANGLES] = {
        MyTriangle (363,531,335,571,394,571,100),   //left bottom triangle
        MyTriangle (83,531,55,571,114,571,100)};     // right bottom triangle
        //MyTriangle (178,224,276,224,300,414,15),
        // MyTriangle (178,224,157,414,300,414,15)

    Picture p1;

    p1.setLines(lineArr,LINES);
    p1.setCircles(cirArr,CIRCLES);
    p1.setRectangles(recArr,RECTANGLES);
    p1.setTriangles(triArr,TRIANGLES);

    p1.drawPicture();

    return 0;
}
