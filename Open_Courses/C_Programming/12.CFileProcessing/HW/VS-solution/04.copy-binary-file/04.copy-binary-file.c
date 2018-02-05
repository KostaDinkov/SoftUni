/*
* SoftUni
* Course:		C Programming
* Lecture:		C File Processing
* Problem:		4. Copy Binary File
*				Write a program that copies the contents of a binary file
*				to another file.
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			10-11-2015
*/

#include <stdio.h>

#define BUFFER_SIZE 4096
int main(void)
{
	FILE *inputFile = fopen("bb8.jpg", "rb"); //rb - opens the file in binary mode, otherwise not working on Windows !?!
	FILE *resultFile = fopen("copy.jpg", "wb");
	if (!inputFile || !resultFile)
	{
		printf("Error opening file! Exiting...");
		getchar();
		return 1;
	}
	char buffer[BUFFER_SIZE];

	while (!feof(inputFile))
	{
		size_t bytesRead = fread(buffer, 1, sizeof(buffer), inputFile);
		fwrite(buffer, 1, bytesRead, resultFile);
	}

	fclose(inputFile);
	fclose(resultFile);

	printf("Press Enter to Exit\n");
	getchar(); // wait for key press before exiting the programm
	return 0;
}