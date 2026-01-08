#include <iostream>

using namespace std;

int calc_diff_days(int currentDay, int userDay, int userMonth, int userYear);
int calc_diff_Months(int currentDay, int currentMonth, int userDay, int userMonth);
int calc_diff_years(int currentDay, int currentMonth, int currentYear,int userDay, int userMonth, int userYear);

int main()
{
    int currentDay  = 20, currentMonth = 10, currentYear = 2025;
    int userDay, userMonth, userYear;
    int diffDays, diffMonths, diffYears;
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

    diffDays = calc_diff_days(currentDay,userDay, userMonth, userYear);
    diffMonths = calc_diff_Months(currentDay,currentMonth,userDay,userMonth);
    diffYears = calc_diff_years(currentDay, currentMonth, currentYear, userDay, userMonth, userYear);

    cout<<diffYears<<" Years\t"<<diffMonths<<" Months\t"<<diffDays<<" Days\t"<<endl;
    return 0;
}

int calc_diff_days(int currentDay, int userDay, int userMonth, int userYear){
    int result = 0;
    switch(userMonth){
        case 1:
        case 3:
        case 5:
        case 7:
        case 8:
        case 10:
        case 12:
            result = 31 - userDay;
            break;
        case 4:
        case 6:
        case 9:
        case 11:
            result = 30 - userDay;
            break;
        case 2:
            if (userYear % 4 == 0){
                result = 29 - userDay;
            }
            else{
                result = 28 - userDay;
            }
            break;
    }
    result += currentDay -1;
    return result;
}

int calc_diff_years(int currentDay, int currentMonth, int currentYear,int userDay, int userMonth, int userYear){
    int result;
    if(currentMonth>userMonth){
        result = currentYear - userYear;
    }
    else if (currentMonth<userMonth){
        result = currentYear - userYear - 1;
    }
    else{
        if(currentDay<userDay)
            result = currentYear - userYear - 1;
        else
            result = currentYear - userYear;
    }
    return result;
}

int calc_diff_Months(int currentDay, int currentMonth, int userDay, int userMonth){
    int result;
    if (currentMonth>userMonth){
        if(currentDay>userDay)
            result = currentMonth - userMonth;
        else
            result = currentMonth - userMonth - 1;
    }
    else if (currentMonth<userMonth){
        if(currentDay>=userDay)
            result = 12 - userMonth + currentMonth;
        else
            result = 11 - userMonth + currentMonth;
    }
    else
        result = 0;

    return result;
}

