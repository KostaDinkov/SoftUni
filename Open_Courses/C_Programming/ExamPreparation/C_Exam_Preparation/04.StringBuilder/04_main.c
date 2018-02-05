#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>


// prototypes

char* concat(char* string);
char* GetString(void);
char* TrimWhiteSpace(char* str);
void ExtractCommandLine(char* input);
void ProcessCommandLine();
char* command[3];
char* resultString;

int main(int argc, char* argv[])
{
	char* input = GetString();
	while (strcmp(input, "over") != 0)
	{
		ExtractCommandLine(input);
		ProcessCommandLine();
		free(input);
		input = GetString();
	}
	printf("%s\n", resultString);
	free(input);
	free(resultString);
}

void ConcatString(char* string)
{
	int endIndex;
	if (resultString == NULL) endIndex = 0;
	else endIndex = strlen(resultString);
	resultString = (char*) realloc(resultString, endIndex + strlen(string) + 1);
	strcpy(&resultString[endIndex], string);
}

void InsertString(char* string, char* index)
{
	int resultLen = strlen(resultString);
	int strLen = strlen(string);
	int fullLen = resultLen + strLen + 1;
	int insertIndex = atoi(index);
	resultString = (char*)realloc(resultString, fullLen);
	resultString[fullLen - 1] = '\0';
	memcpy(&resultString[insertIndex + strLen], &resultString[insertIndex], resultLen - insertIndex);
	memcpy(&resultString[insertIndex], string, strLen);
}

char* ReplaceString(char* orig, char* rep, char* with)
{
	char* result; // the return string
	char* ins; // the next insert point
	char* tmp; // varies
	int len_rep; // length of rep
	int len_with; // length of with
	int len_front; // distance between rep and end of last rep
	int count; // number of replacements

	if (!orig)
		return NULL;
	if (!rep)
		rep = "";
	len_rep = strlen(rep);
	if (!with)
		with = "";
	len_with = strlen(with);

	ins = orig;
	for (count = 0; tmp = strstr(ins, rep); ++count)
	{
		ins = tmp + len_rep;
	}

	tmp = result = (char*)malloc(strlen(orig) + (len_with - len_rep) * count + 1);

	if (!result)
		return NULL;

	while (count--)
	{
		ins = strstr(orig, rep);
		len_front = ins - orig;
		tmp = strncpy(tmp, orig, len_front) + len_front;
		tmp = strcpy(tmp, with) + len_with;
		orig += len_front + len_rep; // move to next "end of rep"
	}
	strcpy(tmp, orig);
	return result;
}

void ProcessCommandLine()
{
	if (strcmp(command[0], "concat") == 0)
	{
		ConcatString(command[1]);
	}
	else if (strcmp(command[0], "insert") == 0)
	{
		InsertString(command[1], command[2]);
	}
	else if (strcmp(command[0], "replace") == 0)
	{
		char* tmp = ReplaceString(resultString, command[1], command[2]);
		free(resultString);
		resultString = tmp;
	}
	else if (strcmp(command[0], "over") == 0)
	{
		return;
	}
}

void ExtractCommandLine(char* input)
{
	//TODO split the input to its commands and return an
	char* token;
	token = strtok(input, "-");

	int index = 0;
	while (token != NULL)
	{
		command[index] = token;
		token = strtok(NULL, "-");

		index++;
	}
}

int GetInt(void)
{
	while (1)
	{
		char* line = GetString();
		if (line == NULL)
		{
			return INT_MAX ;
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

char* TrimWhiteSpace(char* str)
{
	char* end;

	// Trim leading space
	while (isspace(*str)) str++;

	if (*str == 0) // All spaces?
		return str;

	// Trim trailing space
	end = str + strlen(str) - 1;
	while (end > str && isspace(*end)) end--;

	// Write new null terminator
	*(end + 1) = 0;

	return str;
}
