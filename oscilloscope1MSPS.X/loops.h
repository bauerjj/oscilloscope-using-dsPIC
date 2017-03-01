#ifndef __LOOPS_H__
#define __LOOPS_H__

/* Main state machine */
#define	OFF_STATE	0			// Off state value (ready to start)
#define TON_STATE	1			// Turn on state value
#define ON_STATE	2			// Evaluation state
#define TOFF_STATE	3			// On state value
#define WAIT_STATE	4			// Turn off state value


void OffLoop(void);
void TurnOn(void);
void OnLoop(void);
void TurnOff(void);
void WaitLoop(void);


#endif
