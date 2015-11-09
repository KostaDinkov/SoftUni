/*
* SoftUni
* Course:		C Programming
* Lecture:		C Characters and Strings
* Problem:		3. String Length
*				Write a program that reads from the console a string of maximum 20 characters. 
*				If the length of the string is less than 20, the rest of the characters should be filled with 
*				asterisks '*'. Print the resulting string on the console.
*
* IDE:			Visual Studio / MSVC compiler
* Date:			07-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>

char * GetString(void);
#define RESULT_SIZE 21

int main(void) 
{
	//define an empty string
	char result[RESULT_SIZE] ;
	
	//initialize the string with * symbols
	memset(result, '*', RESULT_SIZE-1);
	
	//terminate the string 
	result[RESULT_SIZE - 1] = '\0';
	
	//get input from user
	char *input = GetString();
	size_t inputLength = strlen(input);
	if (inputLength > 20) inputLength = 20;
	
	//copy at most 20 characters from the input over the result string
	memcpy(result, input, inputLength);
	
	//print the result
	printf("%s\n", result);
	free(input);
	return 0;
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