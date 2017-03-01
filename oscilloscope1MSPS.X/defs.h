#ifndef __DEFS_H__
#define __DEFS_H__

#include "periph.h"
#include "mytypes.h"
#include "vars.h"

#define SLOPE_POSITIVE	0
#define SLOPE_NEGATIVE 	1

typedef union
{ 
	struct flagBITS
	{
		unsigned DCState		:	3;			//This is the state of the unit
		unsigned SlowTick		:	1;			//3 For waiting
		unsigned Fault			:	1;			//4
		unsigned Slope			:	1;			//5
		unsigned TrigStop		:	1;			//6
		unsigned PreTrig		:	1;			//7
		unsigned Trig			:	1;			//8
		unsigned DataReady		:	1;			//9
		unsigned TxInProgress	:	1;			//10
		unsigned unused			:	5;
	}bits;

	UINT16 Word;
}FLAGBITS;

extern FLAGBITS Status;					// Internal status flags
extern UINT16	XVal;
extern UINT16	YVal;
extern UINT16	TriggerValue;
extern UINT16	OldValue;

extern UINT8  v[1600];
extern UINT16 vi;
extern UINT16 *viaddress;

#define MS1			(0.001*FCY/256)
#define MS10		(0.01*FCY/256)
#define MS100		(0.1*FCY/256)
#define MS400		(0.4*FCY/256)



/* Useful */
void Init_Global(void);
UINT16 Counter(UINT16 counts);
#endif
