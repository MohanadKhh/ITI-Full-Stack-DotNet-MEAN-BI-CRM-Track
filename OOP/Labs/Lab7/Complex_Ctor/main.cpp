#include <iostream>

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
        cout<<"\nConstructor without param was called\n";
    }

    Complex(int real){
        this -> real = real;
        cout<<"\nConstructor with one param was called\n";
    }

    Complex(int real, int img){
        this -> real = real;
        this -> img = img;
        cout<<"\nConstructor with two param was called\n";
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

    Complex Add(const Complex &right){
        Complex res;
        res.real = this->real + right.real;
        res.img = this->img + right.img;
        return res;
    }

    ~Complex(){
        cout<<"\nDestructor was called\n";
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
    cout<<"______WELCOME TO COMPLEX NUMBERS PROGRAM______\n\n";

    int temp, temp2;
    Complex c3;

    cout<<"Enter Complex(1):\n";
    cout<<"Real: ";
    cin>>temp;
    Complex c1(temp);
    cout<<"Img: ";
    cin>>temp;
    c1.SetImg(temp);

    cout<<"Enter Complex(2):\n";
    cout<<"Real: ";
    cin>>temp;
    cout<<"Img: ";
    cin>>temp2;
    Complex c2(temp,temp2);

    cout<<"\nComplex(1) number is : ";
    c1.print();
    cout<<"Complex(2) number is : ";
    c2.print();

    cout<<"\nResult of adding complex(1) with Complex(2): ";
    c3 = AddComplex(c1,c2);
    c3.print();
    return 0;
}
