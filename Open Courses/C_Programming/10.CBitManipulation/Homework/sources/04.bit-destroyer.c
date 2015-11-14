/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		4. Bit Destroyer
*				Write a program that sets the bit at position p to 0. Print the resulting number
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			09-11-2015
*/

#include <stdio.h>

int main(void) 
{
	int input, index;
	printf("Integer: ");
	scanf("%i", &input);
	printf("Index: ");
	scanf("%i", &index);

	input = input &(~(1 << index));

	printf("%i\n", input);
	return 0;
}