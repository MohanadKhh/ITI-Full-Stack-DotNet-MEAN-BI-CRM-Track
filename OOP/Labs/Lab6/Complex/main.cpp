#include <iostream>

using namespace std;

class Complex
{
private:
    int real;
    int img;

public:
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
        cout<<real<<" + "<<img<<"i\n";
    }

    Complex Add(const Complex &right){
        Complex res;
        res.real = this->real + right.real;
        res.img = this->img + right.img;
        return res;
    }
};

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
    int temp;
    Complex c1;
    Complex c2;
    Complex c3;

    cout<<"______WELCOME TO COMPLEX NUMBERS PROGRAM______\n\n";

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

    cout<<"\nResult of adding complex(1) with Complex(2): ";
    c3 = c1.Add(c2);
    c3.print();
    return 0;
}
