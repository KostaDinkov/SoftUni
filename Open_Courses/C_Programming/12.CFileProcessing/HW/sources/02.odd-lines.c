/*
* SoftUni
* Course:		C Programming
* Lecture:		C File Processing
* Problem:		2. Odd Lines
*				Write a program that reads a text file and prints on the console its odd lines
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			10-11-2015
*/

#include <stdio.h>
#include <limits.h>

char *GetLine(FILE *input);

int main(void)
{
	FILE *textFile = fopen("input.txt", "r");

	if (!textFile)
	{
		printf("Error opening file! Exiting...");
		getchar();
		return 1;
	}

	int rowNumber = 1;
	while (!feof(textFile))
	{
		char *line = GetLine(textFile);
		if (rowNumber % 2 != 0)
		{
			printf("%s\n", line);
		}
		free(line);
		rowNumber++;
	}

	fclose(textFile);
	printf("Press Enter to Exit\n");
	getchar(); // wait for key press before exiting the programm
	return 0;
}
char * GetLine(FILE *input)
{
	char * buffer = NULL;

	unsigned int capacity = 0;

	unsigned int n = 0;

	int c;

	while ((c = fgetc(input)) != '\n' && c != EOF)
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