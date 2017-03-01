#ifndef __VARS_H__
#define __VARS_H__

/* Project related vars */
//dsPIC
#define PLLM				43		//for 40 MIPS
#define PLLN1				2		//by default
#define PLLN2				2		//by default
#define VREF				3.3		//volts, bias voltage
#define ADCRES				1024	//10 bits, microcontroller ADC resolution

#define UART_BAUD			57600	//UART baud rate

#define MHZ_CAL_VALUE		940

/* Do not modify beyond this point. Numbers are autocalculated from the ones above. */
#define FOSC				(7370000L*PLLM/(PLLN1*PLLN2))
#define FCY					(FOSC/2)								//cycle frequency
#define PWM_RESOLUTION		1.06e-9									//1.06 ns resolution

#define UART_BRG			((FCY/4/UART_BAUD)-1)


#endif
