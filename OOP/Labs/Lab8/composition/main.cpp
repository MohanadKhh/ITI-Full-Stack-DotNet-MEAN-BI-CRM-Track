#include <iostream>
#include "graphics.h"

using namespace std;

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

    ~MyPoint(){

    }
};

class MyCircle
{
private:
    MyPoint center;
    int radius;
    int color;

public:
    MyCircle(){
        color = 0;
    }

    MyCircle(float cX, float cY, int rad, int color)
    :center(cX,cY)
    {
        radius = rad;
        this->color = color;
    }

    MyPoint getCenter(){
        return center;
    }

    int getRadius(){
        return radius;
    }

    int getColor(){
        return color;
    }

    void setCenter(MyPoint cent){
        center = cent;
    }

    void setRadius(int rad){
        radius = rad;
    }

    void setCirColor(int _color){
        color = _color;
    }

    void drawCircle(){
        setcolor(color);
        circle(center.getX(),center.getY(), radius);
    }

    ~MyCircle(){
    }
};


class MyLine
{
private:
    MyPoint start;
    MyPoint endd;
    int color;

public:
    MyLine(){
        color=0;
    }

    MyLine(float stX, float stY, float endX, float endY, int _color)
    :start(stX,stY), endd(endX,endY)
    {
        color = _color;
    }

    MyLine (const MyLine &old){
        start = old.start;
        endd = old.endd;
        color = old.color;
    }

    MyPoint getStartPoint(){
        return start;
    }

    MyPoint getEndPoint(){
        return endd;
    }

    int getColor(){
        return color;
    }

    void setStartPoint(MyPoint _start){
        start = _start;
    }

    void setEndPoint(MyPoint _end){
        endd = _end;
    }

    void setLineColor(int _color){
        color = _color;
    }

    void drawLine(){
        setcolor(color);
        line(start.getX(), start.getY(), endd.getX(), endd.getY());
    }

    ~MyLine(){
    }
};

class MyTriangle
{
private:
    MyPoint A;
    MyPoint B;
    MyPoint C;
    int color;

public:
    MyTriangle(){
        color = 0;
    }

    MyTriangle(float AX, float AY, float BX, float BY, float CX, float CY, int _color)
    :A(AX,AY),B(BX,BY),C(CX,CY)
    {
        color = _color;
    }

    MyTriangle(const MyTriangle &old){
        A = old.A;
        B = old.B;
        C = old.C;
        color = old.color;
    }

    MyPoint getPointA(){
        return A;
    }

    MyPoint getPointB(){
        return B;
    }

    int getColor(){
        return color;
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

    void setTriColor(int _color){
        color = _color;
    }

    void drawTriangle(){
        setcolor(color);
        line(A.getX(),A.getY(),B.getX(),B.getY());
        line(C.getX(),C.getY(),B.getX(),B.getY());
        line(A.getX(),A.getY(),C.getX(),C.getY());
    }

    ~MyTriangle(){
    }
};

class MyRectangle
{
private:
    MyPoint ul;
    MyPoint br;
    int color;

public:
    MyRectangle(){
        color = 0;
    }

    MyRectangle(float AX, float AY, float BX, float BY, int _color)
    :ul(AX,AY),br(BX,BY)
    {
        color = _color;
    }

    MyRectangle(const MyRectangle &old){
        ul = old.ul;
        br = old.br;
        color = old.color;
    }

    MyPoint getUL(){
        return ul;
    }

    MyPoint getBR(){
        return br;
    }

    int getRecColor(){
        return color;
    }

    void setPointUL(MyPoint _ul){
        ul = _ul;
    }

    void setPointBR(MyPoint _br){
        br = _br;
    }

    void setRecColor(int _color){
        color = _color;
    }

    void drawRec(){
        setcolor(color);
        rectangle(ul.getX(),ul.getY(),br.getX(),br.getY());
    }

    ~MyRectangle(){
    }
};

int main()
{
    initgraph();

    MyCircle largeCir(227,414,150,15);
    MyCircle smallCir(227,224,100,15);
    largeCir.drawCircle();
    smallCir.drawCircle();

    MyLine leftLine(178,224,157,414,200);
    MyLine rightLine(276,224,300,414,200);
    leftLine.drawLine();
    rightLine.drawLine();

    MyLine bottomLeftLine(201,483,201,515,200);
    MyLine bottomRightLine(255,483,255,515,200);
    bottomLeftLine.drawLine();
    bottomRightLine.drawLine();

    MyRectangle rec(36,515,430,590,60);
    rec.drawRec();

    MyTriangle leftTri(363,531,335,571,394,571,100);
    MyTriangle rightTri(83,531,55,571,114,571,100);
    leftTri.drawTriangle();
    rightTri.drawTriangle();

    return 0;
}
