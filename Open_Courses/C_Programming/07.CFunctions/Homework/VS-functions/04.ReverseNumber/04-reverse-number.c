/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		4. Reverse Number
*				Write a function that reverses the digits of a given floating-point number. 
*				The function should receive a double number and a pointer to an integer variable. In case of 
*				format error, it should set error to 1 and in case of success to 0. Declare a function prototype 
*				before defining the function.
*
* Date:			24-10-2015
*/
// NOTE : I decided to check the validity of the input while reading the double in my utils.c functions
// and not in the reverse function
// It is better to separate functionality!

#include <stdio.h>
#include "utils.h"

double reverse(double input);
void reverse_string(char *str);
int main(void) 
{
	int *error;
	printf("Enter a decimal number: ");
	double input = GetDouble();
	double reversed = reverse(input);
	printf("%lf\n", reversed);
	return 0;
}
double reverse(double input)
{
	char doubleStr[50];
	//convert input to string
	sprintf(doubleStr, "%g", input);
	reverse_string(doubleStr);
	//convert result to double and return it
	return strtod(doubleStr, NULL, 10);
}
void reverse_string(char *str)
{
	/* skip null */
	if (str == 0)return;
	if (*str == 0)return;

	/* get range */
	char *start = str;
	char *end = start + strlen(str) - 1; /* -1 for \0 */
	char temp;

	/* reverse */
	while (end > start)
	{
		/* swap */
		temp = *start;
		*start = *end;
		*end = temp;

		/* move */
		++start;
		--end;
	}
}