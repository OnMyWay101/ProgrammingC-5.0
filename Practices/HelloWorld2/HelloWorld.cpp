#include <stdio.h>
#include <stdlib.h>

void TestThePointerPluse();
void main()
{
	//printf("Hello World!");
	TestThePointerPluse();
	getchar();
}

#define  BUFF_SIZE 0x1000
void TestThePointerPluse()
{
	int * intPointer = NULL;
	intPointer = (int *)malloc(BUFF_SIZE);
	printf("intPointer Address1: 0x%x \n", intPointer);
	intPointer += 8;
	printf("intPointer Address2: 0x%x \n", intPointer);

	short * shortPointer = NULL;
	shortPointer = (short *)malloc(BUFF_SIZE);
	printf("shortPointer Address1: 0x%x \n", shortPointer);
	shortPointer += 8;
	printf("shortPointer Address2: 0x%x \n", shortPointer);

	char * charPointer = NULL;
	charPointer = (char *)malloc(BUFF_SIZE);
	printf("charPointer Address1: 0x%x \n", charPointer);
	charPointer += 8;
	printf("charPointer Address2: 0x%x \n", charPointer);
}