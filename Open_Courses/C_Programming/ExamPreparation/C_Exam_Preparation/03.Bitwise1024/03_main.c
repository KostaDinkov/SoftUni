/*
* SoftUni
* Course:		C Programming
* Lecture:		Exam Preparation
* Problem:		3. Bitwise 1024
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			13-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>

int GetInt(void);
unsigned long long GetLongLong(void);
char *GetString(void);
char *ulToBin(unsigned long long val, unsigned long long base);

int ParseCommand(char *commandLine, char *command);
unsigned long long ShiftLeft(unsigned long long number, int pivot);
unsigned long long ShiftRight(unsigned long long number, int pivot);
void PrintNumbers(unsigned long long *numbers, int numCount);


int main()
{
	size_t numCount = (size_t)GetInt();
	unsigned long long *numbers = (unsigned long long *)malloc(numCount * sizeof(unsigned long long));

	for (size_t i = 0; i < numCount; i++)
	{
		numbers[i] = GetLongLong();
	}


	// Parse the commands

	char command[10];
	int pivot;
	char *commandLine = GetString();
	pivot = ParseCommand(commandLine, command);


	while (strcmp(command, "end") != 0)
	{
		if (strcmp(command, "left") == 0)
		{
			//for all the numbers
			for (size_t numIndex = 0; numIndex < numCount; numIndex++)
			{
				numbers[numIndex] = ShiftLeft(numbers[numIndex], pivot);
			}
		}
		if (strcmp(command, "right") == 0)
		{
			for (size_t numIndex = 0; numIndex < numCount; numIndex++)
			{
				numbers[numIndex] = ShiftRight(numbers[numIndex], pivot);
			}
		}

		free(commandLine);
		commandLine = GetString();
		pivot = ParseCommand(commandLine, command);
	}
	PrintNumbers(numbers, numCount);
	free(commandLine);
	free(numbers);
	return 0;
}

void PrintNumbers(unsigned long long *numbers, int numCount)
{
	for (size_t i = 0; i < numCount; i++)
	{
		printf("%llu\n", numbers[i]);
	}
}

unsigned long long MoveBit(unsigned long long number, size_t bitIndex, int *lastFreePosition, int direction)
{
	unsigned long long mask = 1;
	int bitAtPosition = (number >> bitIndex) & mask;

	if (bitAtPosition == 1)
	{
		//clear bit at position bitIndex
		number &= ~(mask << bitIndex);

		//set bit at lastFreePosition
		number |= mask << *lastFreePosition;

		//update the last free position
		*lastFreePosition += direction;
	}
	//printf("Moving bit %d, - %s\n",bitIndex, ulToBin(number, 2)); // for debugging only
	return number;
}

unsigned long long ShiftLeft(unsigned long long number, int pivot)
{
	int lastFreePosition = 63;
	unsigned long long mask = 1;

	for (size_t i = 63; i >= 0; i--)
	{
		if (((number >> i) & mask) == 0)
		{
			lastFreePosition = i;
			break;
		}
	}

	//for every pivot from 63 to pivot
	for (int i = lastFreePosition; i >= pivot; i--)
	{
		number = MoveBit(number, i, &lastFreePosition, -1);
	}
	return number;
}

unsigned long long ShiftRight(unsigned long long number, int pivot)
{
	int lastFreePosition = 0;
	unsigned long long mask = 1;

	for (size_t i = 0; i <= 63; i++)
	{
		if ((number >> i) & mask == 0)
		{
			lastFreePosition = i;
		}
	}

	for (size_t i = 0; i <= pivot; i++)
	{
		number = MoveBit(number, i, &lastFreePosition, 1);
	}
	return number;
}

int ParseCommand(char *commandLine, char *command)
{
	int commandParam = 0;
	char *token = strtok(commandLine, " ");
	strcpy(command, token);
	token = strtok(NULL, " ");
	if (token != NULL)
	{
		commandParam = atoi(token);
	}
	return commandParam;
}

int GetInt(void)
{
	while (1)
	{
		char *line = GetString();
		if (line == NULL)
		{
			return INT_MAX ;
		}

		int n;
		char c;
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

unsigned long long GetLongLong(void)
{
	while (1)
	{
		char *line = GetString();
		if (line == NULL)
		{
			return ULLONG_MAX ;
		}

		unsigned long long n;
		char c;
		if (sscanf(line, " %llu %c", &n, &c) == 1)
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

char *GetString(void)
{
	char *buffer = NULL;

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

			char *temp = (char *)realloc(buffer, capacity * sizeof(char));
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

	char *minimal = (char *)malloc((n + 1) * sizeof(char));
	strncpy(minimal, buffer, n);
	free(buffer);

	minimal[n] = '\0';

	return minimal;
}

char *ulToBin(unsigned long long val, unsigned long long base)
{
	static char buf[64] = {0};

	int i = 64;

	for (; val && i; --i , val /= base)
	{
		int digit = val % base;
		buf[i] = "0123456789abcdef"[digit];
	}
	return &buf[i + 1];
}
