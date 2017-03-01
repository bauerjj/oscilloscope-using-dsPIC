//******************************************************************************
// Filename: MyTypes.h
// Author:   jky
// #include "MyTypes.h"
// Created on November 28, 2012, 2:50 PM


#ifndef MYTYPES_H
#define	MYTYPES_H

#define UINT8	unsigned char
#define INT8	signed char
#define UINT16  unsigned int
#define INT16   signed int
#define UINT32  unsigned long int
#define INT32   signed long int

typedef union
{
	struct
	{
		UINT16	L;		// Low Word
		UINT16	H;		// High Word
	} W;
	UINT32	L;			// Combined two words
} LONGUNION;

#endif	/* MYTYPES_H */

