/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		10. Edd and Even Procuct
*				You are given n integers (given in a single line, separated by a space).
Write a program that checks whether the product of the odd elements is equal to the product of the even elements. Elements are counted from 1 to n, so the first element is odd, the second is even, etc.
*
* Date:			23-10-2015
*/

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Prototypes
char * GetString(void);
char ** SplitString(char *input, char *delim);

int main(void)
{
	char *input = GetString();
	char ** elements = SplitString(input, " ");
	int oddProduct = 1;
	int evenProduct = 1;
	
	// iterate over the numbers
	int count = 1;

	char** temp = elements; // assign a pointer temp that we will use for the iteration

	while (*temp != NULL)     // while the value contained in the first level of temp is not NULL
	{
		char *number = *temp;
		if (count % 2 == 0)
		{
			evenProduct *= atoi(number);
		}
		else
		{
			oddProduct *= atoi(number);
		}
		temp++; // increment the pointer to the next cell
		count++;
	}

	// Print the results
	if (evenProduct == oddProduct)
	{
		printf("yes\nproduct = %i\n", evenProduct);
	}
	else
	{
		printf("no\nodd_product = %i\neven_product = %i\n", oddProduct, evenProduct);
	}

	free(input);

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

char ** SplitString(char *input, char *delim)
{
	char ** res = NULL;
	char *  p = strtok(input, delim);
	int n_spaces = 0, i;

	/* split string and append tokens to 'res' */

	while (p) {
		res = realloc(res, sizeof(char*) * ++n_spaces);

		if (res == NULL)
			exit(-1); /* memory allocation failed */

		res[n_spaces - 1] = p;

		p = strtok(NULL, " ");
	}

	/* realloc one extra element for the last NULL */

	res = realloc(res, sizeof(char*) * (n_spaces + 1));
	res[n_spaces] = 0;

	return res;

	/* free the memory allocated */

	free(res);
}