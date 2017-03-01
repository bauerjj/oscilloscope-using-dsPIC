#include "mytypes.h"
#include "periph.h"
#include "defs.h"
#include "vars.h"
#include "loops.h"
#include "comm.h"
#include <math.h>
#include "libpic30.h"

int main()
{
	Init_Core();			/* Clock, Auxiliary clock, nested interrupts */
	Init_Ports();			/* Port directions and analog/digital */
	Init_PWM();				/* Initialization of PWM module */
	Init_ADC();				/* Initialization of ADC module */
	Init_Timer();			/* Timer init */
	Init_UART();
    
    

	Init_Global();			/* Global variables mostly */
	Init_Comm();

	Init_Interrupts();		/* Enable requested interrupts */
    vi = 0;
	viaddress = &v[0];
    
//    while(1){
//        __delay_ms(200);
//        U1TXREG = 'D';
//                __delay_ms(200);
//
//    }
    
    while(1)
	{
         

       //__delay_ms(200);
       // U1TXREG = 'D';
         

		switch(Status.bits.DCState)
		{
			case	OFF_STATE:
					OffLoop();
			break;
	
			case	TON_STATE:
					TurnOn();
			break;

			case	ON_STATE:
					OnLoop();
			break;
					
			case	TOFF_STATE:
					TurnOff();
			break;
	
			case	WAIT_STATE:
					WaitLoop();
			break;

			default:	//critical error
				Status.bits.Fault = 1;
				Status.bits.DCState = TOFF_STATE;
			break;

		};
                
	}

	return 0;				/* ... */
}


void __attribute__((__interrupt__,auto_psv)) _DefaultInterrupt ()
{
	//never ever should it get here
	while(1)
		Nop();
}
