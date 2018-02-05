/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		05. Names
*				Declare two string (char array) variables holding your first 
*				name and last name. Print them in the console.
*/

#include <stdio.h>;

int main(void) {

	char firstName[] = "Minzuharcho";
	char lastName[] = "Kokichkov";

	printf("%s %s\n", firstName, lastName);

	return 0;
}