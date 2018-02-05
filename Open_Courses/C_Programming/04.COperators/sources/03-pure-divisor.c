/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		3. Pure Divisor
*				Write a program that prints if a number is divided by 9, 11 or 13 without remainder
*/
#include <stdio.h>;

//Prototypes
int IsDivisibleBy(int number, int divisor);

int main(void) {
    int div_a = 9;
    int div_b = 11;
    int div_c = 13;

    int number;
    printf("Enter an integer:");
    scanf("%i", &number);
    if (IsDivisibleBy(number, div_a) || IsDivisibleBy(number, div_b) || IsDivisibleBy(number, div_c))
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