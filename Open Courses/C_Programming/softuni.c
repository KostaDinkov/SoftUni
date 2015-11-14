#include <stdio.h>
#include <stdlib.h>
#include <string.h>

//
char* itoa(int val, int base){
	
	static char buf[32] = {0};
	
	int i = 30;
	
	for(; val && i ; --i, val /= base)
	
		buf[i] = "0123456789abcdef"[val % base];
	
	return &buf[i+1];
	
}
/**
	 * C++ version 0.4 char* style "itoa":
	 * Written by Lukás Chmela
	 * Released under GPLv3.

	 */
	char* itoa(int value, char* result, int base) {
		// check that the base if valid
		if (base < 2 || base > 36) { *result = '\0'; return result; }

		char* ptr = result, *ptr1 = result, tmp_char;
		int tmp_value;

		do {
			tmp_value = value;
			value /= base;
			*ptr++ = "zyxwvutsrqponmlkjihgfedcba9876543210123456789abcdefghijklmnopqrstuvwxyz" [35 + (tmp_value - value * base)];
		} while ( value );

		// Apply negative sign
		if (tmp_value < 0) *ptr++ = '-';
		*ptr-- = '\0';
		while(ptr1 < ptr) {
			tmp_char = *ptr;
			*ptr--= *ptr1;
			*ptr1++ = tmp_char;
		}
		return result;
	}

char GetChar(void)
{
	{
		char * line = GetString();
		if (line == NULL)
		{
			return CHAR_MAX;
		}

		char c1, c2;
		if (sscanf(line, " %c %c", &c1, &c2) == 1)
		{
			free(line);
			return c1;
		}
		else
		{
			free(line);
			printf("Retry: ");
		}
	}
}

double GetDouble(void)
{
	while (true)
	{
		char * line = GetString();
		if (line == NULL)
		{
			return DBL_MAX;
		}

		double d; char c;
		if (sscanf(line, " %lf %c", &d, &c) == 1)
		{
			free(line);
			return d;
		}
		else
		{
			free(line);
			printf("Retry: ");
		}
	}
}

float GetFloat(void)
{
	while (true)
	{
		char * line = GetString();
		if (line == NULL)
		{
			return FLT_MAX;
		}

		char c; float f;
		if (sscanf(line, " %f %c", &f, &c) == 1)
		{
			free(line);
			return f;
		}
		else
		{
			free(line);
			printf("Retry: ");
		}
	}
}



long long GetLongLong(void)
{
	while (true)
	{
		char * line = GetString();
		if (line == NULL)
		{
			return LLONG_MAX;
		}

		long long n; char c;
		if (sscanf(line, " %lld %c", &n, &c) == 1)
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
int GetInt(void)
{
	while (1)
	{
		char * line = GetString();
		if (line == NULL)
		{
			return INT_MAX;
		}

		int n; char c;
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

char * GetString(void)
{
	char * buffer = NULL;

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

			char * temp = (char *)realloc(buffer, capacity * sizeof(char));
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

	char * minimal = (char *)malloc((n + 1) * sizeof(char));
	strncpy(minimal, buffer, n);
	free(buffer);

	minimal[n] = '\0';

	return minimal;
}
