/*
* SoftUni
* Course:		C Programming
* Lecture:		Formated Input / Output
* Problem:		1. Sum of 3 Numbers
*				Write a program that reads 3 real numbers from the console and prints their sum.
*/

#include <stdio.h>

//prototypes
double SumNumbers(double arr[]);

#define NUMCOUNT 3 //change this for more numbers
int main(void)
{


    double numbers[NUMCOUNT];
    for (int i = 0; i < NUMCOUNT; i++)
    {
        printf("Enter a number: ");
        scanf("%lf", &numbers[i]);
    }
    double sum = SumNumbers(numbers, NUMCOUNT);
    printf("The sum of the numbers is %.2lf\n", sum);
    return 0;
}
double SumNumbers(double arr[], int arrSize)
{
    double sum = 0;
    for (int i = 0; i < arrSize; i++)
    {
        sum = sum + arr[i];
    }
    return sum;
}