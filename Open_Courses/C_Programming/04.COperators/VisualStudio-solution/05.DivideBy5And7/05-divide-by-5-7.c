/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		5. Divide by 7 and 5
*				Write a Boolean expression that checks for given integer
*               if it can be divided (without remainder) by 7 and 5 in the same time.
*/

#include <stdio.h>;

//Prototypes
int IsDivisibleBy(int number, int divisor);

int main(void) {
    int div_a = 5;
    int div_b = 7;


    int number;
    printf("Enter an integer:");
    scanf("%i", &number);
    if (IsDivisibleBy(number, div_a) && IsDivisibleBy(number, div_b))
    {
        printf("1\n");
    }
    else
    {
        printf("0\n");
    }
    return 0;
}
int IsDivisibleBy(int number, int divisor) {

    return number % divisor == 0 ? 1 : 0;
}