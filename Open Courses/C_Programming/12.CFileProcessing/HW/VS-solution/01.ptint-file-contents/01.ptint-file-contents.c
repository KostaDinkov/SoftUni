/*
* SoftUni
* Course:		C Programming
* Lecture:		C File Processing
* Problem:		01. Print File Contents
*				Write a program that reads a text file and prints its contents on the console
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			10-11-2015
*/

#include <stdio.h>

#define BUFFER_SIZE 4096

int main(void)
{
	FILE *textFile = fopen("input.txt", "r");
	if (!textFile)
	{
		printf("Error opening file! Exiting...");
		getchar();
		return 1;
	}
	char buffer[BUFFER_SIZE + 1];
	while (!feof(textFile))
	{
		size_t bytesRead = fread(buffer, 1, BUFFER_SIZE, textFile);
		buffer[bytesRead] = '\0';
		printf("%s", buffer);
	}
	printf("\n");
	fclose(textFile);
	printf("Press Enter to Exit\n");
	getchar(); // wait for key press before exiting the programm
	return 0;
}