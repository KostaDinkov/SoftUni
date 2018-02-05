/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		7. Sort 3 Numbers With Nested Ifs
*				Write a program that enters 3 real numbers and prints them
*				sorted in descending order. Use nested if statements. Don’t use arrays and
*				the built-in sorting functionality.
*/

#include <stdio.h>

//Prototypes
void swap(double *x, double *y);

int main(void)
{
	double a, b, c;

	printf("Enter three real numbers each on separate line:\n");
	scanf("%lf", &a);
	scanf("%lf", &b);
	scanf("%lf", &c);

	if (a < b) swap(&a, &b);
	if (b < c) swap(&b, &c);
	if (a < b) swap(&a, &b);

	printf("Sorted: %lf, %lf, %lf\n", a, b, c);

	return 0;
}
void swap(double *x, double *y)
{
	double temp;
	temp = *x;    /* save the value at address x */
	*x = *y;      /* put y into x */
	*y = temp;    /* put temp into y */

	return;
}