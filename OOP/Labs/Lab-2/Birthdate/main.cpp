#include <iostream>

using namespace std;

int main()
{
    int currentDay  = 3, currentMonth = 11, currentYear = 2025;
    int userDay, userMonth, userYear;
    int diffDays = 0, diffMonths = 0, diffYears = 0;
    int max_Day;

    do{
        cout<<"Please Enter your BD Year from 1980 to 2025:"<<endl;
        cin>>userYear;
    }
    while(userYear<1980 || userYear>2025);

    do{
        cout<<"Please Enter your BD Month:"<<endl;
        cin>>userMonth;
    }
    while(userMonth<1 || userMonth>12);

    switch(userMonth){
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
            max_Day = 31;
            break;
        case 4:
        case 6:
        case 9:
        case 11:
            max_Day = 30;
            break;
        case 2:
            if (userYear % 4 == 0){
                max_Day = 29;
            }
            else{
                max_Day = 28;
            }
            break;
    }

    do{
        cout<<"Please Enter your BD Day:"<<endl;
        cin>>userDay;

    }
    while(userDay<1 || userDay>max_Day);

    //Days
    if (currentDay < userDay){
        diffMonths--;
        diffDays = currentDay - userDay + max_Day;
    }
    else if(currentDay >= userDay)
        diffDays = currentDay - userDay;

    //Months
    if (currentMonth<userMonth){
        diffYears--;
        diffMonths += currentMonth - userMonth + 12;
    }
    else if(currentMonth > userMonth){
        diffMonths += currentMonth - userMonth;
    }
    else if(currentMonth == userMonth){
        if(currentDay<userDay){
            diffYears--;
            diffMonths += currentMonth - userMonth + 12;
        }
        else if(currentDay>=userDay){
            diffMonths += currentMonth - userMonth;
        }
    }

    //Years
    diffYears+= currentYear - userYear;


    cout<<diffYears<<" Years\t"<<diffMonths<<" Months\t"<<diffDays<<" Days\t"<<endl;
    return 0;
}
