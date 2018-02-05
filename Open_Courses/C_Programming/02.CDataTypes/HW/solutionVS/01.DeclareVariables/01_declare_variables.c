/*
 * SoftUni
 * Course:		C Programming
 * Lecture:		C Data Types
 * Problem:		1. Declare Variables
 *				Declare five variables choosing for each of them the most appropriate of the types 
 *				char, short, unsigned short, int, unsigned int, long, unsigned long to represent 
 *				the following values: 52130, 8942492113, -115, 4825932, 97, -10000, -35982859328592389. 
 *				Choose a large enough type for each number to ensure it will fit in it.
*/

int main(void)
{
	/*
	 * NOTE! assuming the following: the relation requirements are that the long long is not smaller than long, 
	 * which is not smaller than int, which is not smaller than short. 
	 * As char's size is always the minimum supported data type, all other data types can't be smaller.
	 * The minimum size for char is 8 bits, the minimum size for short and int is 16 bits, 
	 * for long it is 32 bits and long long must contain at least 64 bits.
	 */
	
	unsigned short uShortNumber = 52130;
	long long veryLongNumber = 8942492113;
	char charNumber = -115;
	long longNumber = 4825932;
	char otherCharNumber = 97;
	short shortNumber = -10000;
	long long realyLong = -35982859328592389;

		
}