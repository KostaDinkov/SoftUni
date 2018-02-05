/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		3. Variable in Hexadecimal Format
*				Declare an integer variable and assign it with the value 
*				254 in hexadecimal format (0x##). Use a calculator online to find its hexadecimal
*				representation. Print the variable and ensure that the result is "254".
*/

#include <stdio.h>

int main(void)
{
	int hexVal = 0xFE;
	printf("%d\n", hexVal);
}