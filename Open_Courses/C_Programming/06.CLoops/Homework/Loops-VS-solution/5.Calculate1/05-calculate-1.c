/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		Calculate 1 + 1!/X + 2!/X^2 + … + N!/X^N
*				Write a program that, for a given two integer numbers n and x,
*				calculates the sum S = 1 + 1!/x + 2!/x^2 + … + n!/x^n. Use only one loop.
*				Print the result with 5 digits after the decimal point.
*
* Date:			23-10-2015
*/

#include <stdio.h>
#include <math.h>

// Prototypes
unsigned long long Factorial(int n);

int main(void)
{
	int n;
	int x;
	printf("Enter n: ");
	scanf("%i", &n);
	printf("Enter x: ");
	scanf("%i", &x);

	double sum = 1;
	for (int i = 1; i <= n; i++)
	{
		sum = sum + Factorial(i) / pow(x, i);
	}
	printf("Sum is : %.5lf\n", sum);
	return 0;
}
unsigned long long Factorial(int n)
{
	if (n == 0)
		return 1;
	else
		return(n * Factorial(n - 1));
}