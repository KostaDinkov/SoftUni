#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

// Prototypes
int GetInt(void);
unsigned long long GetLongLong(void);
char* GetString(void);
#define BUFFER_SIZE 16


void PrintError(char*msg)
{
	printf("%s: No such file or directory\n",msg);
}

void SwapBuffer(char buffer[16])
{
	char tmp[8];
	memcpy(tmp, buffer, 8);
	memmove(buffer, &buffer[8], 8);
	memcpy(buffer, tmp, 8);
}
int main(int argv, char*argc[])
{
	unsigned long long offset = argc[2];
	unsigned long long repairSize = argc[3];
	char* fileName = argc[1];
	FILE *file = fopen(fileName, "r+b");
	if (file == NULL) 
	{
		PrintError(fileName);
		exit(1);
	}
	fseek(file, offset, SEEK_SET);

	for (size_t i = 0; i < repairSize / 16; i++)
	{
		char buffer[BUFFER_SIZE];
		
		fread(buffer, 1, BUFFER_SIZE, file);
		SwapBuffer(buffer);
		fseek(file, -16, SEEK_CUR);
		fwrite(buffer, 1, BUFFER_SIZE, file);

	}
	fclose(file);
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

unsigned long long GetLongLong(void)
{
	while (1)
	{
		char* line = GetString();
		if (line == NULL)
		{
			return ULLONG_MAX;
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


