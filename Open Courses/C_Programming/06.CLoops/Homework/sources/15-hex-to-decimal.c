/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		15. Hexadecimal to Decimal Number
*				Using loops write a program that converts a hexadecimal integer number
*				to its decimal form. The input is entered as string.
*				The output should be a variable of type long.
*				Do not use the built-in .NET functionality.
*
* Date:			23-10-2015
*/

//Note: I'm not using any .NET functionality ;)
//But anyway, the homework problem specifications are copied directly form the ones for C# basics.
//They didn't even edit the text a bit, so that at least the ".NET functionality" is erased.

#include<stdio.h>
#include<stdlib.h>
#include<math.h>

//Prototypes
char * GetString(void);

int main()
{
	printf("Enter something ... hexy:");
	char * hex = GetString();

	unsigned long long  dec = strtoull(hex, NULL, 16);
	printf("%lld\n", dec);
	return 0;

	return 0;
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