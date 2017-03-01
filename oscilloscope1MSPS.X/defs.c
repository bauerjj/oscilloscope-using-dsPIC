#include "defs.h"
#include "loops.h"
#include "comm.h"

/* Main state machine */
FLAGBITS Status;					// Internal status flags
UINT16	XVal;
UINT16	YVal;
UINT16	TriggerValue;
UINT16	OldValue;

UINT8  v[1600];
UINT16 vi;
UINT16 *viaddress;

/* Useful */
void Init_Global(void) {

	Status.Word = 0x0000;
	Status.bits.DCState = OFF_STATE;		//STATE_OFF may not necesarily be 0

	TriggerValue = 512;		//half
	Status.bits.Slope = SLOPE_POSITIVE;
}

UINT16 Counter(UINT16 counts)
{
	if(Status.bits.SlowTick == 0) // only need to check the timer if bit has not expired
	{
		if(_TON == 0)				// If the timer is off need to initialize the timer and count
		{
			_T1IF = 0;				// Reset the interrupt flag
			TMR1 = 0;				// Reset the timer
			PR1 = counts;			// Set amount to wait
			_TON = 1;				// Turn on the timer
		}
		else
		{
			if(_T1IF == 1)			// If the timer has expired
			{
				Status.bits.SlowTick = 1;	// Set flag to indicate that timer has expired
				_TON = 0;						// Turn off the timer
			}
		}
	}
	return(Status.bits.SlowTick);
}
