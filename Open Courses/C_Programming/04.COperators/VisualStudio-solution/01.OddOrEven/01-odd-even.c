/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		1. Odd or Even Integers
*				Write an expression that checks if given integer is odd or even.
*/

#include <stdio.h>;

int main(void) {

    printf("Enter integer: ");
    int a;
    scanf("%i", &a);
    printf("Odd ? : %i\n", a % 2 != 0 ? 1 : 0);

	return 0;
}