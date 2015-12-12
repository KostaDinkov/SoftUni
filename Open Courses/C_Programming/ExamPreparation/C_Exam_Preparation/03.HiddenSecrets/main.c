
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
 

int ProcessBuffer(char* buffer, int bytesRead);

char* GenerateFileName(char* string);

void Usage();

int main(int argc, char* argv[])
{
	int fileCount = argc - 1;
	if (fileCount==0) Usage();
	//generate filename based on the file extension
	char* resultFilename = GenerateFileName(argv[1]);
	
	FILE *resultFile = fopen(resultFilename, "wb");
	
	//read  files
	for (size_t i = 0; i < fileCount; i++)
	{
		FILE *crntInput = fopen(argv[i + 1], "rb");
		if(!crntInput)
		{
			printf("%s: No such file or directory\n",argv[i+1]);
			exit(0);
		}
		char buffer[64];
		
		while(!feof(crntInput))
		{
			size_t bytesRead = fread(buffer, 1, 64, crntInput);
			//process read information
			//action holds the number of bytes to copy from buffer to result file
			int bytesToCopy = ProcessBuffer(buffer, bytesRead);
			fwrite(buffer, 1, bytesToCopy, resultFile);

		}
		fclose(crntInput);

	}
	fclose(resultFile);
	free(resultFilename);
	printf("Eureka!\n");
	
	return 0;
}
int ProcessBuffer(char* buffer, int bytesRead)
{
	int result = 0;
	
	char sign[5];
	sign[4] = '\0';
	
	char *endOfBuffer = &buffer[bytesRead-1];
	memcpy(sign,endOfBuffer-3,4);
	
	// if apple
	if(strcmp(sign,"3456")==0)
	{
		result = bytesRead-4;
	}
	// if leaf
	if(strcmp(sign, "!\"#$") == 0)
	{
		result = (bytesRead-4) /2;
	}
	return result;

}
char* GenerateFileName(char* string)
{
	char* lastDot = strrchr(string, '.');
	
	char* result = (char*)malloc(5 + strlen(lastDot)+1);
	char name[] = "merged";
	strcpy(result, name);
	strcpy(&result[6], lastDot);
	return result;
}
void Usage()
{
	printf("Usage: [<src-file-1> <src-file-2> ...]\n");
	exit(0);
}




