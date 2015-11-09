/*
* SoftUni
* Course:		C Programming
* Lecture:		C Characters and Strings
* Problem:		3. Series Of Letters
*				Write a program that reads a string from the console and
*				replaces all series of consecutive identical letters with a single one.
*
* IDE:			Visual Studio / MSVC compiler
* Date:			07-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>

char * GetString(void);

int main(void)
{
	char *input = GetString();
	size_t inputLength = strlen(input);
	char *result = malloc(inputLength * sizeof(char));
	char current = input[0];
	result[0] = current;
	int i, j;
	for (i = 1, j=1 ; i < inputLength ; i++)
	{
		if (input[i]!=current)
		{
			result[j] = input[i];
			j++;
			current = input[i];
		}
	}
	result[j] = '\0';
	printf("%s\n", result);
	free(input);
	free(result);
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