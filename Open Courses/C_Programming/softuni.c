#include <stdio.h>
#include <stdlib.h>
#include <string.h>

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

int GetInt(void)
{
	while (true)
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