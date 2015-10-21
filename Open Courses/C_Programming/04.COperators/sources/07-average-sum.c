/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		7. Average Sum
*				Write a program that finds the average of the sum of 3 numbers
*/

#include <stdio.h>;

#define NUMCOUNT 3

int main(void) {
    double num_a ;
    double num_b ;
    double num_c ;

    printf("Enter first number:");
    scanf("%lf", &num_a);
    printf("Enter second number:");
    scanf("%lf", &num_b);
    printf("Enter third number:");
    scanf("%lf", &num_c);

    double result = (num_a + num_b + num_c) / 3;
    printf("Average is: %lf\n", result);
    double numbers[NUMCOUNT];

	return 0;
}