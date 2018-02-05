/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		3. Min, Max, Sum and Average of N numbers
*				Write a program that reads from the console a sequence of n
*				integer numbers and returns the minimal, the maximal number, the sum and the
*				average of all numbers (displayed with 2 digits after the decimal point).
*				The input starts by the number n (alone in a line) followed by n lines, each
*				holding an integer number. The output is like in the examples below.
*
* Date:			23-10-2015
*/

#include <stdio.h>
#include <limits.h>
#include <stdlib.h>

// Prototypes
int Min(int arr[], int arrLen);
int Max(int arr[], int arrLen);
int Sum(int arr[], int arrLen);
double Avg(int arr[], int arrLen);

int main(void)
{
	int numCount;
	printf("Enter count of numbers to read: ");
	scanf("%i", &numCount);

	//Note: This homework is written in Visual Studio 2015, and MSVC doesn't support Variable Length Arrays-
	//that is arrays of which the size is allocated during the execution, so I am using malloc to create the array at runtime
	int *arr = malloc(numCount * sizeof(int));

	if (arr == NULL)// if malloc failed to allocate enough memory
	{
		printf("Error allocating memory!\n"); // print an error message
		return 1; // return with failure
	}

	for (int i = 0; i < numCount; i++)
	{
		scanf("%i", &arr[i]);
	}

	printf("min = %i\n", Min(arr, numCount));
	printf("max = %i\n", Max(arr, numCount));
	printf("sum = %i\n", Sum(arr, numCount));
	printf("average = %.2lf\n", Avg(arr, numCount));

	free(arr);
	return 0;
}
int Min(int arr[], int arrLen)
{
	int min = INT_MAX;
	for (int i = 0; i < arrLen; i++)
	{
		if (arr[i] < min) min = arr[i];
	}
	return min;
}
int Max(int arr[], int arrLen)
{
	int max = INT_MIN;
	for (int i = 0; i < arrLen; i++)
	{
		if (arr[i] > max) max = arr[i];
	}
	return max;
}
int Sum(int arr[], int arrLen)
{
	int sum = 0;
	for (int i = 0; i < arrLen; i++)
	{
		sum += arr[i];
	}
	return sum;
}
double Avg(int arr[], int arrLen)
{
	return Sum(arr, arrLen) / (double)arrLen;
}