/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		8. Catalan Numbers
*				Write a program to calculate the nth Catalan number by given n (1 < n < 100).
*
* Date:			23-10-2015
*/

#include <stdio.h>
// Prototypes
typedef unsigned long long ull;
ull catalan(int n);
int GetInt(char *prompt);

int main(void)
{
	int n = GetInt("Enter an integer (1<n<100): ");
	printf("%ith catalan number is : %llu\n", n, catalan(n));
	return 0;
}
ull catalan(int n)
{
	return n ? 2 * (2 * n - 1) * catalan(n - 1) / (1 + n) : 1;
}
int GetInt(char *prompt)
{
	printf(prompt);
	int n;
	scanf("%i", &n);
	return n;
}