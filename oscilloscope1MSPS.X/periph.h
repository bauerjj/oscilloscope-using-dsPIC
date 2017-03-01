#ifndef __PERIPH_H__
#define __PERIPH_H__

#include "p33FJ16GS504.h"
#include "mytypes.h"

#define LED_ON	1
#define LED_OFF	0

#define SW_PRESSED		0
#define SW_UNPRESSED	1

#define SW1_READ	PORTBbits.RB4
#define SW2_READ	PORTBbits.RB3
#define LED1_WRITE	LATCbits.LATC7
#define LED2_WRITE	LATCbits.LATC2

void Init_Core(void);
void Init_Ports(void);
void Init_PWM(void);
void Init_ADC(void);
void Init_Timer(void);
void Init_UART(void);

void Init_Interrupts(void);
void Enable_Interrupts(void);
void Disable_Interrupts(void);

#endif
