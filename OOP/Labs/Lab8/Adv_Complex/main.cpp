#include <iostream>
#include <cmath>

using namespace std;

class Complex
{
private:
    int real;
    int img;

public:
    Complex(){
        real = 0;
        img = 0;
        //cout<<"\nConstructor without param was called\n";
    }

    Complex(const Complex &old)
    {
        real = old.real;
        img = old.img;
        //cout<<"\nCopy Constructor was called\n";
    }

    Complex(int real){
        this -> real = real;
        //cout<<"\nConstructor with one param was called\n";
    }

    Complex(int real, int img){
        this -> real = real;
        this -> img = img;
        //cout<<"\nConstructor with two param was called\n";
    }

    int GetReal() const{
        return real;
    }

    int GetImg() const{
        return img;
    }

    void SetReal(int real){
        this->real = real;
    }

    void SetImg(int img){
        this->img = img;
    }

    void print(){
        if(img == 1 && real != 0){
            printf("%d+i\n",real,img);
        }
        else if(img == -1 && real != 0){
            printf("%d-i\n",real,img);
        }
        else if(img == -1 && real == 0){
            printf("-i\n",img);
        }
        else if(img == 1 && real == 0){
            printf("i\n",img);
        }
        else if (img>0 && real!=0){
            printf("%d+%di\n",real,img);
        }
        else if(img<0 && real!=0){
            printf("%d%di\n",real,img);
        }
        else if((real == 0 && img == 0) || real == 0){
            printf("%d\n",real);
        }
        else if(img == 0){
            printf("%d\n",real);
        }
    }

    double magnitude() const {
        return sqrt(real*real + img*img);
    }

    Complex Add(const Complex &right){
        Complex res;
        res.real = this->real + right.real;
        res.img = this->img + right.img;
        return res;
    }

    Complex & operator=(const Complex &right){
        real = right.real;
        img = right.img;
        return *this;
    }

    Complex operator+(const Complex &right){
        return Complex((real+right.real) , (img + right.img));
    }

    Complex operator+(int num){
        return Complex((real+ num) , img);
    }

    Complex& operator+=(const Complex &right){
        real += right.real;
        img += right.img;
        return *this;
    }

    Complex operator++(int){
        Complex res;
        res.real = real;
        res.img = img;

        real++;

        return res;
    }

    Complex operator++(){
        Complex res;
        res.real = ++real;
        res.img = img;
        return res;
    }

    int operator>(Complex right){
        return magnitude() > right.magnitude();
    }

    ~Complex(){
        //cout<<"\nDestructor was called\n";
    }
};

Complex operator+(int num, Complex right){
    Complex res;
    res.SetReal(right.GetReal() + num);
    res.SetImg(right.GetImg());

    return res;
}

Complex AddComplex(const Complex& left, const Complex& right){
        Complex res;
        int temp = left.GetReal() + right.GetReal();
        res.SetReal(temp);
        temp = left.GetImg() + right.GetImg();
        res.SetImg(temp);
        return res;
}

int main()
{
    cout<<"______WELCOME TO COMPLEX NUMBERS PROGRAM______\n\n";

    Complex c1,c2,c3;
    int temp;

    cout<<"Enter Complex(1):\n";
    cout<<"Real: ";
    cin>>temp;
    c1.SetReal(temp);
    cout<<"Img: ";
    cin>>temp;
    c1.SetImg(temp);

    cout<<"Enter Complex(2):\n";
    cout<<"Real: ";
    cin>>temp;
    c2.SetReal(temp);
    cout<<"Img: ";
    cin>>temp;
    c2.SetImg(temp);

    cout<<"\nComplex(1) number is : ";
    c1.print();
    cout<<"Complex(2) number is : ";
    c2.print();

    cout<<"\nResult of C1 + C2: ";
    c3 = c1 + c2;
    c3.print();

    cout<<"\nResult of C1 + 10: ";
    c3 = c1 + 10;
    c3.print();


    cout<<"\nResult of C1 += C2: ";
    c1 += c2;
    c1.print();

    cout<<"\nResult of C3 = C1++: \n";
    c3 = c1++;
    cout<<"C3 = ";  c3.print();
    cout<<"C1 = ";  c1.print();

    cout<<"\nResult of C3 = ++C1: \n";
    c3 = ++c1;
    cout<<"C3 = ";  c3.print();
    cout<<"C1 = ";  c1.print();

    cout<<"\nResult of C1 > C2: "<< (c1>c2 ? "True" : "False");


    cout<<"\nResult of 10 + C1: ";
    c3 = 10 + c1;
    c3.print();

    return 0;
}
