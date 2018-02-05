#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>

// Prototypes
int GetInt(void);
unsigned long GetLongLong(void);
char* GetString(void);
char *ulToBin(unsigned  long val, unsigned  long base);


void Execute(char arguments[6][50], unsigned long* numbers, size_t currentNumber);

int main()
{
	char arguments[6][50];
	int numCount = GetInt();
	unsigned long *numbers = (unsigned long*)malloc(numCount * sizeof(unsigned long));
	for (size_t i = 0; i < numCount; i++)
	{
		numbers[i] = GetLongLong();
	}
	//parse input
	while (1) 
	{
		
		char* commandLine = GetString();
		char* token = strtok(commandLine, " ");
		if (strcmp(token, "over") == 0) break;
		strcpy(arguments[0], token);
		for (size_t i = 1; i < 6; i++)
		{
			token = strtok(NULL, " ");
			if(token!=NULL) strcpy(arguments[i], token);
		}
		//do work for all numbers
		for (size_t currentNumber = 0; currentNumber < numCount; currentNumber++)
		{
			Execute(arguments, numbers, currentNumber);
		}
		
		
	}
	for (size_t i = 0; i < numCount; i++)
	{
		printf("%lu\n", numbers[i]);
	}
	return 0;
}

unsigned long SetBits(unsigned long number,int from_bit, int bit_count)
{
	//generate mask
	unsigned long mask = (1 << bit_count) - 1;
	number |= mask << from_bit;
	return number;
}

unsigned long UnsetBits(unsigned long number, int from_bit, int bit_count)
{
	unsigned long mask = (1 << bit_count) - 1;
	number &= ~(mask << from_bit);
	
	return number;
	
}

unsigned long FlipBits(unsigned long number, int from_bit, int bit_count)
{
	unsigned long mask = (1 << bit_count) - 1;
	number ^= mask << from_bit;
	return number;
}

unsigned long CopyTo(unsigned long number, int from_bit, int bit_count, char(* arguments)[50])
{
	unsigned long mask = (1 << bit_count) - 1;
	int toBit = atoi(arguments[5]);
	mask = number & (mask << from_bit);
	if (toBit < from_bit) mask = mask >> abs(toBit - from_bit);
	if (toBit > from_bit) mask = mask << toBit - from_bit;
	number = UnsetBits(number, toBit, bit_count);
	number = number | mask;
	return number;
}

unsigned long MoveTo(unsigned long number, int from_bit, int bit_count, char(* arguments)[50])
{
	//printf("%s\n", ulToBin(number, 2));
	unsigned long mask = (1 << bit_count) - 1;
	int toBit = atoi(arguments[5]);
	mask = number & (mask << from_bit);
	//unset the sopied region
	number = UnsetBits(number,from_bit, bit_count);
	//printf("%s\n", ulToBin(number, 2));
	
	if (toBit < from_bit) mask = mask >> abs(toBit - from_bit);
	if (toBit > from_bit) mask = mask << toBit - from_bit;
	
	number = UnsetBits(number,toBit, bit_count);
	//printf("%s\n", ulToBin(number, 2));
	number = number | mask;
	
	//printf("%s\n", ulToBin(number, 2));
	return number;
}

void Execute(char arguments[6][50], unsigned long* numbers, size_t currentNumber)
{
	unsigned long number = numbers[currentNumber];
	int fromBit = atoi(arguments[1]);
	int bitCount = atoi(arguments[3]);
	char* command = arguments[4];
	if (strcmp(command,"set_bits")==0)
	{
		number = SetBits(number,fromBit, bitCount);
	}
	else if (strcmp( command, "unset_bits") == 0)
	{
		number = UnsetBits(number, fromBit, bitCount);
	}
	else if (strcmp(command, "flip_bits") == 0)
	{
		number = FlipBits(number, fromBit, bitCount);
	}
	else if(strcmp(command, "copy_to") == 0)
	{
		number = CopyTo(number, fromBit, bitCount, arguments);
	}
	else if(strcmp(command, "move_to") == 0)
	{
		number = MoveTo(number, fromBit, bitCount, arguments);
	}
	
	numbers[currentNumber] = number;
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

unsigned long GetLongLong(void)
{
	while (1)
	{
		char* line = GetString();
		if (line == NULL)
		{
			return ULONG_MAX;
		}

		unsigned long n;
		char c;
		if (sscanf(line, " %lu %c", &n, &c) == 1)
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
char *ulToBin(unsigned  long val, unsigned  long base)
{
	static char buf[32] = { 0 };

	int i = 32;

	for (; val && i; --i, val /= base)
	{
		int digit = val % base;
		buf[i] = "0123456789abcdef"[digit];
	}
	return &buf[i + 1];
}


