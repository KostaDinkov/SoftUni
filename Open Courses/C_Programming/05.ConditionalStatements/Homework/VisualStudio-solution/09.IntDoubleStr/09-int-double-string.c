/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		9. Play with Int, Double and String
*				Write a program that, depending on the user’s choice,
*				inputs an int, double or string variable. If the variable is int or double,
*				the program increases it by one. If the variable is a string, the program appends
*				"*" at the end. Print the result at the console. Use switch statement.
*/

#include <stdio.h>
#include <string.h>
#include <stdlib.h>

//Prototypes
char *GetString(void);

int main(void) {
	printf("Please choose a type:\n");
	printf("1 --> int\n");
	printf("2 --> double\n");
	printf("3 --> string\n");

	int choice;
	scanf("%i", &choice);
	
	//there is a leftover char after reading with scanf
	//especially the new line char "\n"
	//so we must read the stream and discard it
	char c;
	while ((c = getchar()) != '\n' && c != EOF)	/* discard */;

	switch (choice)
	{
	case 1:
		printf("Please enter an integer: ");
		int intInput;
		scanf("%i", &intInput);
		printf("%i\n", intInput + 1);
		break;
	case 2:
		printf("Please enter a double: ");
		double doubleInput;
		scanf("%lf", &doubleInput);
		printf("%lf\n", doubleInput + 1);
		break;
	case 3:
		printf("Please enter a string: ");
		char *stringInput = GetString();
		strcat(stringInput, "*");
		printf("%s\n", stringInput);
		break;
	default:
		printf("Not a valid choice!\n");
		break;
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