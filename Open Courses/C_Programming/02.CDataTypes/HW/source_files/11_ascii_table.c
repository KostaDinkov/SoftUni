/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		11. Print the ASCII Table
*				Find online more information about ASCII 
*				(American Standard Code for Information Interchange) 
*				and write a program to prints the entire ASCII table of 
*				characters at the console (characters from 0 to 255). 
*				Note that some characters have a special purpose and 
*				will not be displayed as expected. You may skip them or 
*				display them differently. You may need to use for-loops (learn in Internet how).
*/

#include <stdio.h>;

int main(void) {

	for (int i = 0; i < 256; i=i+8)
	{
		for (int j = i; j < i+8; j++)
		{
			printf("%i : %c\t", j, j);
		}
		printf("\n");
	}

	return 0;
}