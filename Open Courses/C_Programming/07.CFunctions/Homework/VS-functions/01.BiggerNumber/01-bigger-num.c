/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		01.Bigger Number
*				Write a function get_max() with two parameters that returns the bigger of two integers. 
*				Write a program that reads 2 integers from the console and prints the largest of them using the function get_max(). 
*				Declare a function prototype before defining the function.
*
* Date:			24-10-2015
*/

#include <stdio.h>
#include "utils.h"

//Protorypes
int Max(int a, int b);

int main(void) 
{
	printf("Enter first integer: ");
	int a = GetInt();
	printf("Enter second integer: ");
	int b = GetInt();
	printf("%i is bigger.\n", Max(a, b));
	return 0;
}
int Max(int a, int b)
{
	return  a > b ? a : b;
}
