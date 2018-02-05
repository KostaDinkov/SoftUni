/*
* SoftUni
* Course:		C Programming
* Lecture:		C File Processing
* Problem:		5. Slicing File
*				Write a program that takes any file and slices it to n parts. Write the following functions:
*				slice(const char *sourceFile, const char *destinationFile, size_t parts)
*					- slices the given source file into n parts and saves
*					them in destinationDirectory.
*				assemble(const char **parts, const char *destinationDirectory)
*					- combines all parts into one, in the order they are passed,
*					and saves the result in destinationDirectory.
*				The input file names, destination directory and parts
*				should be passed to the program as arguments.
*				The program should produce proper error
*				messages in case of errors. Use buffered reading.
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			10-11-2015
*/

#include <stdio.h>
#include <math.h>
#include <errno.h>
#include <string.h>

#define BUFFER_SIZE 4096

void slice(const char *sourceFile, const char *destinationDir, size_t parts);
void assemble(const char **parts, size_t partsCount, const char *destinationDirectory);
void kill(char* programName, const char *msg);

int main(int argc, char **argv)
{
	//check command mode
	char *mode = argv[1];

	//if mode is -s, do slicing
	if (strncmp("-s", mode, 2) == 0)
	{
		char destination[50]; //TODO remove hard-coded value;
		char *sourceFile = argv[2];
		if (argc == 4) *destination = NULL;
		else *destination = argv[4];

		int parts = (int)strtol(argv[3], NULL, 10);

		slice(sourceFile, destination, parts);
	}
	//if mode id -a, do assembling
	else if (strncmp("-a", mode, 2) == 0)
	{
		size_t partsCount = argc - 3;
		char * destination = argv[argc - 1];
		assemble(argv, partsCount, destination);
	}
	//else throw error
	else
	{
		kill(argv[0], "Invalid input\n");
	}
	printf("Press Enter to Exit!");
	getchar();
	return 0;
}
void kill(const char *msg)
{
	printf("Usage:\n  -s filename partCount [targetDir]\n"
		"-a filename.1 filename.2 ... filename.n targetDir\n");
	if (errno)perror(msg);
	else printf("Error: %s\n", msg);
	exit(1);
}
void slice(const char *sourceFile, const char *destinationDir, size_t parts)
{
	char buffer[BUFFER_SIZE];
	FILE *input = fopen(sourceFile, "rb");
	if (!input) kill("Cant open file");

	//get the input file size
	fseek(input, 0, SEEK_END);
	size_t fileSize = ftell(input);
	fseek(input, 0, SEEK_SET);
	size_t partSize = ceil((double)fileSize / parts);

	for (int i = 0; i < parts; i++)
	{
		size_t bytesRead;
		size_t bytesRemaining = partSize;

		char partName[50];
		//check if a destination directory has been provided
		if (strlen(destinationDir) != 0)
		{
			sprintf(partName, "%s\\%s.%i", destinationDir, sourceFile, i + 1);
		}
		else sprintf(partName, "%s.%i", sourceFile, i + 1);

		FILE *part = fopen(partName, "wb");
		if (!part) kill("Can't create file ");
		while (bytesRemaining > BUFFER_SIZE)
		{
			bytesRead = fread(buffer, 1, BUFFER_SIZE, input);
			fwrite(buffer, 1, BUFFER_SIZE, part);
			bytesRemaining -= bytesRead;
		}
		bytesRead = fread(buffer, 1, bytesRemaining, input);
		fwrite(buffer, 1, bytesRemaining, part);
		fclose(part);
	}
	fclose(input);
}
void assemble(const char **parts, size_t partsCount, const char *destinationDirectory)
{
	char buffer[BUFFER_SIZE];
	//TODO make destination directory optional
	
	char fileName[50];
	sprintf(fileName, "%s\\%s", destinationDirectory, parts[2]);
	
	//get rid of the postfix in the filename
	char *pch = strrchr(fileName, '.');
	*pch = '\0';

	FILE *output = fopen(fileName, "wb");
	if (!output) kill("Can't create output file \n""Check if directory exists.\n");

	for (int i = 0; i < partsCount; i++)
	{
		char *currPart = parts[i + 2];
		FILE *part = fopen(currPart, "rb");
		if (!part) kill("Can't open file: \n");
		while (!feof(part))
		{
			size_t bytesRead = fread(buffer, 1, BUFFER_SIZE, part);
			fwrite(buffer, 1, bytesRead, output);
		}
		fclose(part);
	}
	fclose(output);
}