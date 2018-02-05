/*
* SoftUni
* Course:		C Programming
* Lecture:		Exam Preparation
* Problem:		1. Spy Hard
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			11-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>

#define INITIAl_SIZE 20
// Prototypes

int GetInt(void);
char* GetString(void);
int GetCharValue(char ch);
int GetCharSum(char* msg);

int main(void)
{
	int sysBase = GetInt();
	char* msg = GetString();

	char sumToBinary[64];
	int charSum = GetCharSum(msg);
	itoa(charSum, sumToBinary, sysBase);

	printf("%i%i%s\n", sysBase, strlen(msg), sumToBinary);
	free(msg);
	return 0;
}

int GetInt(void)
{
	while (1)
	{
		char* line = GetString();
		if (line == NULL)
		{
			return INT_MAX;
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

int GetCharSum(char* msg)
{
	int sum = 0;
	size_t msgLength = strlen(msg);
	for (int i = 0; i < msgLength; i++)
	{
		sum += GetCharValue(msg[i]);
	}
	return sum;
}

int GetCharValue(char ch)
{
	if ((ch >= 97 && ch <= 122) || (ch >= 65 && ch <= 90))
	{
		return tolower(ch) - 96;
	}
	else return ch;
}