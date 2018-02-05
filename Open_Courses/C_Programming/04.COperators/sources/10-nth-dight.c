/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		10. N-th number
*				Write a program that prints the n-th digit of a number (from right to left). If no such digit exists, print a dash "-".
*/

#include <stdio.h>;
#include <math.h>


int main(void) {

    int number;
    int digitIndex;
    printf("Enter a number:  ");
    scanf("%i", &number);
    printf("Enter the position of the digit to find (from right to left):");
    scanf("%i", &digitIndex);
    if (number < pow(10,digitIndex))
    {
        printf("-\n");
        return 0;
    }
    for (size_t i = 1; i < digitIndex; i++)
    {
        number /= 10;
    }
    printf("%i\n", number % 10 );

    return 0;
}