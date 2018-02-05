/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		5.Array Manipulation
*				Declare the following functions in a header file (.h). 
*				Implement them in a separate .c file. Include the .h file in your main 
*				program and demonstrate the written functions.
*
* Date:			24-10-2015
*/
//NOTE: Added the functions to my previously created utils.h and utils.c to reduce the number of external files

#include <stdio.h>
#include "utils.h"

#define ARRLEN 10
int main(void) 
{
	int arr[10] = { 1, 4, 33, 69, -1, -72, 423, 203, -666, 0 };
	printf("Min element: %i\n", ArrMin(arr, ARRLEN));
	printf("Max element: %i\n", ArrMax(arr, ARRLEN));
	printf("Sum of elements: %lli\n", ArrSum(arr, ARRLEN));
	printf("Average of elements: %lf\n", ArrAvg(arr, ARRLEN));
	printf("Array contains number 4: %s\n", ArrContains(arr, ARRLEN, 4) ? "true" : "false");
	ArrClear(arr, ARRLEN);
	printf("Array after clearing:\n");
	ArrPrint(arr, ARRLEN);
	return 0;
}