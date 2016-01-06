#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#include <ctype.h>
#include <math.h>

// Prototypes
int GetInt(void);
unsigned long long GetLongLong(void);
char* GetString(void);


unsigned long long CalculateTime(char string[51]);

int main()
{
	int passwordCount = GetInt();
	char ** passwords = (char**)malloc(passwordCount * sizeof(char*));
	unsigned long long totalTime = 0;
	int totalCracked = 0;
	// for each line
	for (size_t i = 0; i < passwordCount; i++)
	{
		//parse it
		char * line = GetString();
		unsigned long long timeLimit;
		char *token = strtok(line, " ");
		timeLimit = strtoull(token, NULL, 0);
		totalTime += timeLimit;
		token = strtok(NULL, " ");
		passwords[i] = (char*)malloc(strlen(token) + 1);
		strcpy(passwords[i], token);
				
	}
	/*for (size_t i = 0; i < passwordCount; i++)
	{
		printf("%s\n", passwords[i]);
	}*/
	for (size_t i = 0; i < passwordCount; i++)
	{
		int time = CalculateTime(passwords[i]);
		//compare
		if(time <=totalTime)
		{
			totalCracked++;
			printf("Password \"%s\" successfully cracked!\n", passwords[i]);
		}
		else
		{
			printf("Could not crack password \"%s\". %lu more seconds needed.\n",passwords[i],time-totalTime);
		}
	}
	double successRate = (double)totalCracked / passwordCount;
	printf("%.2f%% of all passwords were cracked\n", successRate*100);
	
	return 0;
}

unsigned long long CalculateTime(char *string)
{
	unsigned long long totalSeconds = 0;
	int strLen = strlen(string);
	
	for (size_t i = 0; i < strLen; i++)
	{

		//if char is digit
		if(isdigit(string[i]))
		{
			totalSeconds += 2;
		}
		else if(isalpha(string[i]))
		{
			totalSeconds += (int)string[i];
		}
		else
		{
			if(string[i]!=NULL)
			{
				totalSeconds *= 2;
			}
		}
		//else 
	}
	return totalSeconds;
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


