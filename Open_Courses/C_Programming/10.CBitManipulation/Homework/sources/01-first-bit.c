/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		1.First Bit
*				Write a program that prints the bit at position 1 of a number
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			09-11-2015
*/

#include <stdio.h>
#include <limits.h>

// Prototypes
char * GetString(void);
int GetInt(void);

int main(void) 
{
	int input = GetInt();
	printf("%i\n", input & 1);
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
int GetInt(void)
{
	while (1)
	{
		char * line = GetString();
		if (line == NULL)
		{
			return INT_MAX;
		}

		int n; char c;
		if (sscanf(line, " %d %c", &n, &c) == 1)
		{
			free(line);
			return n;
		}
		else
		{
			free(line);
			printf("Retry: ");
		}
	}
}