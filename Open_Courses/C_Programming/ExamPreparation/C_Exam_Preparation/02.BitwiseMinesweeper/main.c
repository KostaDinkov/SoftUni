
#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>


int GetInt(void);
unsigned long GetLongLong(void);
char* GetString(void);
int row = 0;
int col = 0;
void GameOver(int row, int col);

int main()
{
	int numCount = GetInt();
	
	unsigned long* matrix = (unsigned long*)malloc(numCount * sizeof(unsigned long));
	//fill the matrix
	size_t uintSize = sizeof(unsigned long);

	for (size_t i = 0; i < numCount; i++)
	{
		unsigned long number = GetLongLong();
		matrix[i] = number;
	}
	//read the commands
	char * command = GetString();
	while(strcmp(command,"end")!=0)
	{
		if(strcmp(command, "up") == 0)
		{
			int lastrow = row;
				
			//check boundries
			if (row == 0)
			{
				row = numCount - 1;
				
			}
			else row--;
			
			//check next position
			if(matrix[row] & (1<<col))
			{
				//has hit a 1 bit, game over
				GameOver(row, col);
				break;
			}
			else matrix[row] |= (1 << col);
			//clear last position
			matrix[lastrow] &= ~(1 << col);
		}
		if (strcmp(command, "right") == 0)
		{
			
			int lastcol = col;
			//check boundries
			if (col == 0) col = 31;
			else col--;
			//check next position
			if (matrix[row] & (1 << col))
			{
				//has hit a 1 bit, game over
				GameOver(row, col);
				break;
			}
			else matrix[row] |= (1 << col);
			//clear current position
			matrix[row] &= ~(1 << (lastcol));
		}
		if (strcmp(command, "left") == 0)
		{
			int lastcol = col;

			//check boundries
			if (col == 31) col = 0;
			else col++;
			//check next position
			if (matrix[row] & (1 << col))
			{
				//has hit a 1 bit, game over
				GameOver(row, col);
				break;
			}
			else matrix[row] |= (1 << col);
			//clear current position
			matrix[row] &= ~(1 << (lastcol));
		}
		if (strcmp(command, "down") == 0)
		{
			int lastrow = row;

			//check boundries
			if (row == numCount-1) row = 0;
			else row++;
			//check next position
			if (matrix[row] & (1 << col))
			{
				//has hit a 1 bit, game over
				GameOver(row, col);
				break;
			}
			else matrix[row] |= (1 << col);
			//clear last position
			matrix[lastrow] &= ~(1 << col);
		}
		command = GetString();
	}
	//print matrix
	for (size_t i = 0; i < numCount; i++)
	{
		printf("%lu\n", matrix[i]);
	}
	
	free(matrix);

	return 0;
}
void GameOver(int row, int col)
{
	printf("GAME OVER. Stepped a mine at %i %i\n", row, col);
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

unsigned  long GetLongLong(void)
{
	while (1)
	{
		char* line = GetString();
		if (line == NULL)
		{
			return UINT_MAX;
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


