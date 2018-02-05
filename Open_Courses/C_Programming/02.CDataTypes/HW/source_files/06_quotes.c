/*
* SoftUni
* Course:		C Programming
* Lecture:		C Date Types
* Problem:		06. Quotes in strings
*				Declare a string variable and assing to it the following value:
*				The "use" of quotations causes difficulties. \n, \t and \ are also special characters.
*				Print the resulting string on the console.
*/

#include <stdio.h>;

int main(void) {

	char *quotes = "The \"use\" of quotations causes difficulties. \\n, \\t and \\ are also special characters.";
	printf("%s\n", quotes);
	return 0;
}