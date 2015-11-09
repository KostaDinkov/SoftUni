/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		13.Binary to Decimal Number
*				Using loops write a program that converts a binary integer
*				number to its decimal form. The input is entered as string.
*				The output should be a variable of type long. Do not use the built-in .NET functionality.
*
* Date:			23-10-2015
*/

//NOTE: Do not copy paste binary numbers ... doesn't work for me;

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Prototypes
int GetInt(char *prompt);
int binaryToDecimal(int n);
char * GetString(void);

int main(void)
{
	char *input = GetString();
	int result = binaryToDecimal(input);
	printf("Input in decimal form: %i\n", result);
	return 0;
}
int binaryToDecimal(char *input) /* Function to convert binary to decimal.*/
{
	int counter = 0;
	char bin = input[counter];
	int dec = 0;

	while (bin != '\n') {
		if (bin == '1') dec = dec * 2 + 1;
		else if (bin == '0') dec *= 2;
		counter++;
		bin = input[counter];
	}
	return dec;
}

char * GetString(void)
{
	// growable buffer for chars
	char * buffer = NULL;

	// capacity of buffer
	unsigned int capacity = 0;

	// number of chars actually in buffer
	unsigned int n = 0;

	// character read or EOF
	int c;

	// iteratively get chars from standard input
	while ((c = fgetc(stdin)) != '\n' && c != EOF)
	{
		// grow buffer if necessary
		if (n + 1 > capacity)
		{
			// determine new capacity: start at 32 then double
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

			// extend buffer's capacity
			char * temp = realloc(buffer, capacity * sizeof(char));
			if (temp == NULL)
			{
				free(buffer);
				return NULL;
			}
			buffer = temp;
		}

		// append current character to buffer
		buffer[n++] = c;
	}

	// return NULL if user provided no input
	if (n == 0 && c == EOF)
	{
		return NULL;
	}

	// minimize buffer
	char * minimal = malloc((n + 1) * sizeof(char));
	strncpy(minimal, buffer, n);
	free(buffer);

	// terminate string
	minimal[n] = '\0';

	// return string
	return minimal;
}