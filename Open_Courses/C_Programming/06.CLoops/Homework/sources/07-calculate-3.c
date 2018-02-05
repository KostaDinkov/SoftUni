/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		Calculate N! / (K! * (N-K)!)
*				In combinatorics, the number of ways to choose k different members out of a
*				group of n different elements (also known as the number of combinations) is calculated by the following formula: ...
*				For example, there are 2598960 ways to withdraw 5 cards out of a standard deck of 52 cards.
*				Your task is to write a program that calculates n! / (k! * (n-k)!)
*				for given n and k (1 < k < n < 100). Try to use only two loops.
*
* Date:			23-10-2015
*/

#include <stdio.h>

//Prototypes
int GetInt(void);
unsigned long long nChoosek(int n, int k);

int main(void)
{
	int n = GetInt("Enter an integer n: ");
	int k = GetInt("Enter an integer k: ");
	unsigned long long result = nChoosek(n,k);
	printf("N! / (K!*(n-k)!) = %llu\n", result);
	return 0;
}
int GetInt(char *prompt)
{
	printf(prompt);
	int n;
	scanf("%i", &n);
	return n;
}
unsigned long long nChoosek(int n, int k)
{
	if (k > n) return 0;
	if (k * 2 > n) k = n - k;
	if (k == 0) return 1;

	int result = n;
	for (int i = 2; i <= k; ++i) {
		result *= (n - i + 1);
		result /= i;
	}
	return result;
}
