/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		Calculate N! / K!
*				Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop.
*
* Date:			23-10-2015
*/

// NOTE: If the difference between n and k is too big especially in the n=99 range
// I don't think we can solve it using standard numeric data types
// For Example: n= 90, k=60. n-k = 30, so it is almost like to calculate 90 to the 30th power
// and I can't find a way to store such a number.

#include <stdio.h>

// Prototypes
int GetInt(void);
unsigned long long PartFactorial(int n, int count);

int main(void)
{
	printf("%llu\n", PartFactorial(50, 1));
	int n = GetInt();
	int k = GetInt();

	printf("%llu\n", PartFactorial(n, n - k));
	return 0;
}
// Partial Factorial - calculates n! only n-k times, instead down to 1
unsigned long long PartFactorial(int n, int count)
{
	long long  result = 1;

	for (int c = 0; c < count; c++)
	{
		result = result * n;
		n--;
	}
	return result;
}
int GetInt(void)
{
	printf("Enter an integer: ");
	int n;
	scanf("%i", &n);
	return n;
}