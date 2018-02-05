/*
* SoftUni
* Course:		C Programming
* Lecture:		C Characters and Strings
* Problem:		1. Reverse String
*				Write a program that reads a string from the console
*				reverses it and prints the result back at the console
*
* Ide:			Visual Studio / MSVC compiler
* Date:			07-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>

//Prototypes
char * GetString(void);
void Reverse(char *input, int startIndex, int endIndex);

int main(void) 
{
	char *input = GetString();
	size_t inputLen = strlen(input);
	int startIndex = 0;
	int endIndex = inputLen - 1;
	Reverse(input,startIndex,endIndex);
	printf("%s\n", input);
	free(input);
	return 0;
}
void Reverse(char *input, int startIndex, int endIndex) {

	while (startIndex < endIndex)
	{
		//swap
		char tmp = input[startIndex];
		input[startIndex] = input[endIndex];
		input[endIndex] = tmp;
		startIndex++;
		endIndex--;
	}
}
char * GetString(void)
{
	char * buffer = NULL;

	unsigned int capacity = 0;

	unsigned int n = 0;

	int c;

	while ((c = fgetc(stdin)) != '\n' && c != EOF)
	{
		if (n + 1 > capacity)
		{
			if (capacity == 0)
			{
				capacity = 32;
			}
			else if (capacity <= (UINT_MAX / 2))
			{
				capacity *= 2;
			}
			else
			{
				free(buffer);
				return NULL;
			}

			char * temp = realloc(buffer, capacity * sizeof(char));
			if (temp == NULL)
			{
				free(buffer);
				return NULL;
			}
			buffer = temp;
		}

		buffer[n++] = c;
	}

	if (n == 0 && c == EOF)
	{
		return NULL;
	}

	char * minimal = malloc((n + 1) * sizeof(char));
	strncpy(minimal, buffer, n);
	free(buffer);

	minimal[n] = '\0';

	return minimal;
}