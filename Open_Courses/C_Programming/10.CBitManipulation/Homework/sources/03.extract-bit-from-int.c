/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		3.Extract Bit from Integer
*				Write an expression that extracts from given integer n the value of given bit at index p.
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
	
	int mask = 1 << index;
	mask = input & mask;
	mask = mask >> index;

	printf("%s\n", mask ? "true":"false");
	return 0;
}