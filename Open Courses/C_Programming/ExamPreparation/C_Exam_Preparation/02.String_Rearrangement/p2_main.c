/*
* SoftUni
* Course:		C Programming
* Lecture:		Exam Preparation
* Problem:		2. String Rearrangement
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			12-11-2015
*/

#include <stdio.h>
#include <limits.h>
#include <string.h>
#include <ctype.h>
#include <stdlib.h>
#include <assert.h>

// Prototypes

typedef struct NodeTag
{
	char* data;
	struct NodeTag* next;
} Node;

typedef struct ListTag
{
	struct NodeTag* first;
} List;

int GetInt(void);
char* GetString(void);
char* GetSequence(char* string);
Node* Node_create();
void Node_destroy(Node* node);
List* List_create();
void List_destroy(List* list);
void List_append(List* list, char* str);
char* List_get(List* list, int index);
int List_length(List* list);

#define INITIAl_SIZE 20

char* GetSequence(char* string);
int CheckPosition(long position, long len, size_t stringLength);
char* ConcatTo(char* str, char* sequence);
void Swap(char* result, long a, long b, long len);

int main(void)
{
	char* input = GetString();
	// split on | and store blocks in a list
	List* blocks = List_create();
	char* token = strtok(input, "|");
	List_append(blocks, token);
	while (1)
	{
		token = strtok(NULL, "|");
		if (token == NULL)break;
		List_append(blocks, token);
	}
	// parse the sequences and concatenate them
	int blocksCount = List_length(blocks);
	char* result = (char*)malloc(1);
	result[0] = '\0';
	for (size_t i = 0; i < blocksCount; i++)
	{
		char* sequence = GetSequence(List_get(blocks, i));
		if (sequence)
		{
			result = ConcatTo(result, sequence);
			free(sequence);
		}
	}
	free(input);
	List_destroy(blocks);

	//execute commands
	char* command = GetString();

	while (strcmp(command, "end") != 0)
	{
		// parse command, but skip the "swap" text
		size_t resultLength = strlen(result);
		long pA, pB, len;
		char* pEnd = strchr(command, ' ');
		pA = strtol(pEnd, &pEnd, 10);
		pB = strtol(pEnd, &pEnd, 10);
		len = strtol(pEnd, NULL, 10);
		// swap
		Swap(result, pA, pB, len);
		free(command);
		command = GetString();
	}
	printf("%s\n", result);
	free(command);
	free(result);

	return 0;
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

char* GetSequence(char* string)
{
	char* leftIndex = strchr(string, '{');
	if (!leftIndex) return NULL;
	char* rightIndex = strchr(leftIndex, '}');

	if (rightIndex)
	{
		int sequenceLength = abs(rightIndex - leftIndex) + 1;
		char* sequence = (char*)malloc(sequenceLength);
		if (!sequence) return NULL;
		memcpy(sequence, leftIndex + 1, sequenceLength - 2);
		sequence[sequenceLength - 2] = '\0';
		return sequence;
	}
	return NULL;
}

char* ConcatTo(char* str, char* sequence)
{
	size_t sequenceLength = strlen(sequence);
	size_t strLength = strlen(str);
	if (sequenceLength == 0)return str;
	char* result = (char*)realloc(str, strLength + sequenceLength + 1);
	char* endOfResult = strchr(result, '\0');
	strcpy(endOfResult, sequence);
	return result;
}

void Swap(char* result, long a, long b, long len)
{
	size_t resultLen = strlen(result);
	if (CheckPosition(a, len, resultLen) && CheckPosition(b, len, resultLen))
	{
		/*for (size_t i = 0; i < len; i++)
		{
			char tmp = result[a + i];
			result[a + i] = result[b + i];
			result[b + i] = tmp;
		}*/
		char* tmp = (char*)malloc(len);
		memcpy(tmp, &result[a], len);
		memcpy(&result[a], &result[b], len);
		memcpy(&result[b], tmp, len);
		free(tmp);
	}
}

int CheckPosition(long position, long len, size_t stringLength)
{
	if (position < 0 ||
		position >= stringLength ||
		position + len >= stringLength ||
		len < 0)
	{
		printf("Invalid command parameters\n");
		return 0;
	}
	return 1;
}

Node* Node_create()
{
	Node* node =(Node*) malloc(sizeof(Node));
	assert(node != NULL);

	node->data = "";
	node->next = NULL;

	return node;
}

void Node_destroy(Node* node)
{
	assert(node != NULL);
	free(node);
}

List* List_create()
{
	List* list = (List*)malloc(sizeof(List));
	assert(list != NULL);

	Node* node = Node_create();
	list->first = node;

	return list;
}

void List_destroy(List* list)
{
	assert(list != NULL);

	Node* node = list->first;
	Node* next;
	while (node != NULL)
	{
		next = node->next;
		free(node);
		node = next;
	}

	free(list);
}

void List_append(List* list, char* str)
{
	assert(list != NULL);
	assert(str != NULL);

	Node* node = list->first;
	while (node->next != NULL)
	{
		node = node->next;
	}

	node->data = str;
	node->next = Node_create();
}

int List_length(List* list)
{
	assert(list != NULL);

	Node* node = list->first;
	int length = 0;
	while (node->next != NULL)
	{
		length++;
		node = node->next;
	}

	return length;
}

char* List_get(List* list, int index)
{
	assert(list != NULL);
	assert(0 <= index);
	assert(index < List_length(list));

	Node* node = list->first;
	while (index > 0)
	{
		node = node->next;
		index--;
	}
	return node->data;
}
