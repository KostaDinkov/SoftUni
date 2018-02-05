/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		2. Big And Odd
*				Write a program that that prints if the number is both greater than 20 and odd.
*/

#include <stdio.h>;

int main(void) {

    printf("Enter integer: ");
    int a;
    scanf("%i", &a);
    printf("Odd ? : %i\n", (a % 2 != 0 && a > 20)? 1 : 0);

    return 0;
}