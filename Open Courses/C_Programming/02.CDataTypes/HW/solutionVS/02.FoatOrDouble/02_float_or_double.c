/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		2. Float or Double
*				Which of the following values can be assigned to a
*				variable of type float and which to a variable of type double:
*				34.567839023, 12.345, 8923.1234857, 3456.091?
*				Write a program to assign the numbers in variables and print
*				them to ensure no precision is lost.
*/

#include <stdio.h>

int main(void)
{
	double myDouble = 34.567839023;
	float myFloat = 12.345;
	double otherDouble = 8923.1234857;
	float otherFloat = 3456.091;

	printf("Input: 34.567839023 | Output: %.10f\n", myDouble);
	printf("Input: 12.345 | Output: %.10f\n", myFloat);
	printf("Input: 8923.1234857 | Output: %.10f\n", otherDouble);
	printf("Input: 3456.091 | Output: %.10f\n", otherFloat);

}