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
#include <math.h>


int GetInt(void);
unsigned long long GetLongLong(void);
char* GetString(void);
char* ulToBin(unsigned long long val, unsigned long long base);
unsigned long long ShiftLeft(int position, unsigned long long number);
unsigned long long ShiftRight(int position, unsigned long long number);

int main()
{
	int numCount = GetInt();
	unsigned long long* numbers = (unsigned long long*)malloc(sizeof(unsigned long long) * numCount);
	for (size_t i = 0; i < numCount; i++)
	{
		numbers[i] = GetLongLong();
	}


	char* command = GetString();
	while (strcmp(command, "end") != 0)
	{
		// parse command
		char* directionEnd = strchr(command, ' ');
		char direction[10];
		int dirLen = directionEnd - command;
		strncpy(direction, command, dirLen);
		direction[dirLen] = '\0';
		int position = strtol(directionEnd, NULL, 10);
		for (size_t i = 0; i < numCount; i++)
		{
			if (strcmp(direction, "left") == 0)
			{
				numbers[i] = ShiftLeft(position, numbers[i]);
			}

			else
			{
				numbers[i] = ShiftRight(position, numbers[i]);
			}
		}
		command = GetString();
	}
	//print results
	for (size_t i = 0; i < numCount; i++)
	{
		printf("%llu\n", numbers[i]);
	}
	return 0;
}

unsigned long long ShiftLeft(int position, unsigned long long number)
{
	// start at pos 63 
	unsigned long long mask = 1;
	int lastTakenPosition = 64;
	char buffer[65];
	for (int i = 63; i >= position; i--)
	{
		//if bit at position i = 1
		if ((number >> i) & 1)
		{
			//set the last free position to the left to 1
			number = number | (mask << (lastTakenPosition - 1));
			//set the bit at position i to 0 
			if(i!=63)number &= ~(mask << i);
			//set the first free position to the right
			lastTakenPosition--;

			_ui64toa(number, buffer, 2);
		}
	}

	return number;
}

unsigned long long ShiftRight(int position, unsigned long long number)
{
	// start at pos 0 
	unsigned long long mask = 1;
	int lastTakenPosition = -1;
	char buffer[65];
	for (int i = 0; i <= position; i++)
	{
		//if bit at position i = 1
		if ((number >> i) & 1)
		{
			//set the last free position to the left to 1
			number = number | (mask << (lastTakenPosition + 1));
			//set the bit at position i to 0 
			if(i!=0)number &= ~(mask << i);
			//set the first free position to the right
			lastTakenPosition++;

			_ui64toa(number, buffer, 2);
		}
	}

	return number;
}

int GetInt(void)
{
	while (1)
	{
		char* line = GetString();
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
		char* line = GetString();
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

char* GetString(void)
{
	char* buffer = NULL;

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

			char* temp = (char *)realloc(buffer, capacity * sizeof(char));
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

	char* minimal = (char *)malloc((n + 1) * sizeof(char));
	strncpy(minimal, buffer, n);
	free(buffer);

	minimal[n] = '\0';

	return minimal;
}

char* ulToBin(unsigned long long val, unsigned long long base)
{
	static char buf[64] = {0};

	int i = 63;

	for (; val && i; --i , val /= base)
	{
		int digit = val % base;
		buf[i] = "0123456789abcdef"[digit];
	}
	return &buf[i + 1];
}
