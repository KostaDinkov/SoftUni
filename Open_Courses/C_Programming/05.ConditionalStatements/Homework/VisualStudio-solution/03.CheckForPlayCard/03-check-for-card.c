/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		3. Check for a Play Card
*				Classical play cards use the following signs to designate the card face:
*				2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. Write a program that enters a string and prints
*				“yes” if it is a valid card sign or “no” otherwise.
*/

//Note: I have included a function for safer way of reading strings from the console
//The function is part of Harvard's CS50 library

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <string.h>

//Prototypes
int checkValidCard(char *input);
char *GetString(void);

int main(void) {
	printf("Enter a card: ");
	char *input = GetString();
	printf("%s\n", IsValidCard(input) ? "yes" : "no");

	return 0;
}
int IsValidCard(char *input) {
	char *cards[] = { "2","3","4","5","6","7","8","9","10","J","Q","K","A",0 };
	int index = 0;
	while (cards[index]) {
		if (strcmp(cards[index], input)==0)
		{
			return 1;
		}
		index++;
	}
	return 0;
}
/**
* Reads a line of text from standard input and returns it as a
* string (char*), sans trailing newline character.  (Ergo, if
* user inputs only "\n", returns "" not NULL.)  Returns NULL
* upon error or no input whatsoever (i.e., just EOF).  Leading
* and trailing whitespace is not ignored.  Stores string on heap
* (via malloc); memory must be freed by caller to avoid leak.
*/
char *GetString(void)
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
			char *temp = realloc(buffer, capacity * sizeof(char));
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
