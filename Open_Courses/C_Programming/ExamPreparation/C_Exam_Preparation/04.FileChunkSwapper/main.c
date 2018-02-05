#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Prototypes

#define BUFFER_SIZE 4096

void SwapMiddle(char string[4096], size_t bytesRead);

void main(int argc, char *argv[])
{
	char *sourceFileName = argv[1];
	char *destFileName = argv[2];

	FILE *sourceFile = fopen(sourceFileName, "rb");
	
	//check if the file was opened successfully
	if (!sourceFile)
	{
		printf("%s: No such file or directory\n", sourceFileName);
		exit(1);
	}
	
	FILE *destFile = fopen(destFileName, "wb");
	char buffer[BUFFER_SIZE];
	
	//start reading / writing cycle
	while(!feof(sourceFile))
	{
		size_t bytesRead = fread(buffer, 1, BUFFER_SIZE, sourceFile);
		SwapMiddle(buffer, bytesRead);
		fwrite(buffer, 1, bytesRead, destFile);
		
	}
	printf("Success!\n");
	fclose(sourceFile);
	fclose(destFile);
}

void SwapMiddle(char source[4096], size_t bytesRead)
{
	size_t middle = bytesRead / 2;
	char *pivotPtr = &source[middle];
	char tmp[4096];
	memcpy(tmp, source, middle);
	memmove(source, pivotPtr, 4096 - middle);
	memmove(pivotPtr, tmp, middle);
}


