#include "loops.h"

#include "mytypes.h"
#include "defs.h"
#include "vars.h"
#include "comm.h"

void OffLoop(void)
{
	Status.bits.DCState = TON_STATE;
}

void TurnOn(void)
{
	Enable_Interrupts();
	Status.bits.DCState = ON_STATE;
}

void OnLoop(void)
{
	if(Status.bits.DataReady == 1)
		Comm_Process_Data();


}

void TurnOff(void)
{
	Disable_Interrupts();
	Status.bits.DCState = WAIT_STATE;
}

void WaitLoop(void)
{
	//treat the fault here
	
	//if the fault hasn't been 
	if(Status.bits.Fault)
		while(1);
		
	Status.bits.DCState = OFF_STATE;	//restart
}
