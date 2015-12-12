
#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <stdlib.h>
#include <math.h>


int GetInt(void);
unsigned long long GetLongLong(void);
char* GetString(void);
double circle_x, circle_y, circle_r;
double head_x, head_y, head_r;
double hand_ulx, hand_uly, hand_brx, hand_bry;
double shot_x, shot_y;
int health = 100;
int points = 0;
int ratio;
int boardHIts = 0;
int shotsTaken = 0;

int isBoardHit(double shot_x, double shot_y);

int isHeadHit(double shot_x, double y);

int isHandHit(double shot_x, double shot_y);

int main()
{
	

	char* end_ptr;
	//read board
	char * firstLine = GetString();
	circle_x = strtod(firstLine, &end_ptr);
	circle_y = strtod(end_ptr, &end_ptr);
	circle_r = strtod(end_ptr, NULL);
	//read head
	char* secondLine = GetString();
	head_x = strtod(secondLine, &end_ptr);
	head_y = strtod(end_ptr, &end_ptr);
	head_r = strtod(end_ptr, NULL);
	//read hand
	char *thirdLine = GetString();
	hand_ulx = strtod(thirdLine, &end_ptr);
	hand_uly = strtod(end_ptr, &end_ptr);
	hand_brx = strtod(end_ptr, &end_ptr);
	hand_bry = strtod(end_ptr, NULL);
	//read shot count
	int shotCount =GetInt();

	//read each shot and do the work
	for (size_t i = 0; i < shotCount; i++)
	{
		// health is less ot equal to 0 break and print results
		if (health <= 0)
		{
			health = 0;
			break;
		}
		

		char *shot = GetString();
		shot_x = strtod(shot, &end_ptr);
		shot_y = strtod(end_ptr, NULL);
		shotsTaken++;		
		
		// if board is hit 
		int _isBoardHit = isBoardHit(shot_x, shot_y);
		if (_isBoardHit)
		{
			points += 50;
			boardHIts++;
		}
		//if head is hit
		if (isHeadHit(shot_x, shot_y))
		{
			health -= 25;
			if (_isBoardHit) points -= 25;
		}
		//if hand is hit
		if(isHandHit(shot_x,shot_y))
		{
			health -= 30;
			if (_isBoardHit) points -= 25;
		}
		
		free(shot);
	}
	printf("Points: %i\n", points);
	int hit_ratio = ((double)boardHIts / shotsTaken) * 100;
	printf("Hit ratio: %i%%\n", hit_ratio);
	printf("Bay Mile: %i\n", health);
	
	free(firstLine);
	free(secondLine);
	free(thirdLine);
	
	return 0;
}
int isBoardHit(double shot_x, double shot_y)
{
	double distFromCenterSq = (shot_x - circle_x)*(shot_x - circle_x) + (shot_y - circle_y)*(shot_y - circle_y);
	if (distFromCenterSq <= circle_r*circle_r) return 1;
	return 0;
}

int isHeadHit(double shot_x, double y)
{
	double distFromCenterSq = (shot_x - head_x)*(shot_x - head_x) + (shot_y - head_y)*(shot_y - head_y);
	if (distFromCenterSq <= head_r*head_r) return 1;
	return 0;
}

int isHandHit(double shot_x, double shot_y)
{
	if((shot_x >=hand_ulx && shot_x<= hand_brx) && (shot_y<=hand_uly && shot_y>= hand_bry))
	{
		return 1;
	}
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


