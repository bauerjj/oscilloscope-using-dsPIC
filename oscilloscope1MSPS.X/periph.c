#include "periph.h"
#include "vars.h"

_FBS(BSS_NO_FLASH & BWRP_WRPROTECT_OFF)
_FGS(GSS_OFF & GWRP_OFF)
_FOSCSEL(FNOSC_FRC & IESO_OFF)
_FOSC(FCKSM_CSECMD & IOL1WAY_OFF & OSCIOFNC_ON & POSCMD_NONE)
_FWDT(FWDTEN_OFF & WINDIS_OFF & WDTPRE_PR128 & WDTPOST_PS512)
_FPOR(FPWRT_PWR16)
_FICD(ICS_PGD3 & JTAGEN_OFF)

void Init_Core(void)
{
	PLLFBD = PLLM-2;
	CLKDIVbits.PLLPOST = PLLN1 - 2;
	CLKDIVbits.PLLPRE = PLLN2 - 2;

    __builtin_write_OSCCONH(0x01);			/* New Oscillator FRC w/ PLL */
    __builtin_write_OSCCONL(0x01);  		/* Enable Switch */
      
	while(OSCCONbits.COSC != 0b001);		/* Wait for new Oscillator to become FRC w/ PLL */  
    while(OSCCONbits.LOCK != 1);			/* Wait for Pll to Lock */

	/* Now setup the ADC and PWM clock for 120MHz
	   ((FRC * 16) / APSTSCLR ) = (7.37 * 16) / 1 = ~ 120MHz*/

	ACLKCONbits.FRCSEL = 1;					/* FRC provides input for Auxiliary PLL (x16) */
	ACLKCONbits.SELACLK = 1;				/* Auxiliary Oscillator provides clock source for PWM & ADC */
	ACLKCONbits.APSTSCLR = 7;				/* Divide Auxiliary clock by 1 */
	ACLKCONbits.ENAPLL = 1;					/* Enable Auxiliary PLL */
	
	while(ACLKCONbits.APLLCK != 1);			/* Wait for Auxiliary PLL to Lock */
	
	CORCONbits.SATA = 1;					// Turn saturation on to insure that overflows will be handled smoothly.
	CORCONbits.SATB = 1;					// Turn saturation on to insure that overflows will be handled smoothly.
	CORCONbits.IF = 1;						// Integer mode enabled
	CORCONbits.SATDW = 1;					// Turn on data space write saturation.
	RCONbits.SWDTEN = 0;	   				// Disable Watch Dog Timer
	INTCON1bits.NSTDIS = 1;         		// Disable nested interrupts
}

void Init_Ports(void)
{
	//GPIO
	TRISBbits.TRISB3 = 1;					// BUT2 input
	TRISBbits.TRISB4 = 1;					// BUT1 input
	TRISCbits.TRISC2 = 0;					// LED2 output
	TRISCbits.TRISC7 = 0;					// LED1 output
	
	//PWM
	TRISBbits.TRISB11 = 0;					// PWM3H output
	TRISBbits.TRISB12 = 0;					// PWM3L output
	TRISBbits.TRISB13 = 0;					// PWM2H output
	TRISBbits.TRISB14 = 0;					// PWM2L output
	TRISAbits.TRISA4 = 0;					// PWM1H output
	TRISAbits.TRISA3 = 0; 					// PWM1L output
	
	//uart
	TRISCbits.TRISC4 = 0;					// USB-UART TX output
	TRISCbits.TRISC5 = 1;					// USB-UART RX input
	
	//ANs
	TRISAbits.TRISA0 = 1;
	TRISAbits.TRISA1 = 1;
	TRISAbits.TRISA2 = 1;
	TRISBbits.TRISB0 = 1;
	TRISBbits.TRISB9 = 1;
	TRISBbits.TRISB10 = 1;
	
	ADPCFG = 0xFFFF;	//set all pins as DIGITAL
	ADPCFGbits.PCFG0 = 0;	//AN0/CS
	ADPCFGbits.PCFG1 = 0;	//AN1/TEMP
	ADPCFGbits.PCFG2 = 0;	//AN2/VOUT		- POT_LEFT
	ADPCFGbits.PCFG3 = 0;	//AN3			- POT_MIDDLE
	ADPCFGbits.PCFG4 = 0;	//AN4			- POT_RIGHT
	ADPCFGbits.PCFG5 = 0;	//AN5
	
	//remapable pins
	__builtin_write_OSCCONL(OSCCON & (~(1<<6))); // clear bit 6 

	RPOR10bits.RP20R = 0b000011;	//tx -- rp20
	RPINR18bits.U1RXR = 21;			//rx -- rp21
	__builtin_write_OSCCONL(OSCCON | (1<<6)); 	 // Set bit 6
}

void Init_PWM(void)
{
	PTPER = MHZ_CAL_VALUE;
	MDC = (0.5*PTPER);

	IOCON1bits.PENH = 0;   					/* PWM1H is NOT controlled by PWM module */
    IOCON1bits.PENL = 0;   					/* PWM1L is NOT controlled by PWM module, so no output from PWM, just internal running */
    IOCON1bits.PMOD = 0;   					/* Select Complementary Output PWM mode */
	IOCON1bits.OVRENH = 1;					/* Start with outputs pulled down */
	IOCON1bits.OVRENL = 1;					/* Start with outputs pulled down */
	IOCON1bits.OVRDAT = 0; 
	
    PWMCON1bits.TRGIEN = 0;
	PWMCON1bits.MDCS = 1;
	
	DTR1    = 0;
	ALTDTR1 = 0;
    PHASE1 = 0;     			    		/* No phase shift */

    PTCONbits.PTEN = 1;			   			/* Enable the PWM Module */	
}

void Init_ADC(void)
{
  	ADCONbits.FORM = 0;			// Integer data format
   	ADCONbits.EIE = 0;			// Early Interrupt disabled
   	ADCONbits.ORDER = 0;		// Convert even channel first
   	ADCONbits.SEQSAMP = 0;		// Select simultaneous sampling
	ADCONbits.ASYNCSAMP = 1; 	// Asynchronous sampling
	ADCONbits.SLOWCLK = 1; 		// High Frequency Clock input
   	ADCONbits.ADCS = 5;//2;			// ADC clock = FADC/6 = 120MHz / 6 = 20MHz
   	
   	/* when changing the following lines, please document the changes to the table in periph.h */

    ADSTATbits.P0RDY = 0;		/* clear interrupt bit if any */
    
    ADCPC0bits.IRQEN0 = 1;			// Pair 0 enable triggering
    ADCPC0bits.TRGSRC0 = 3; 		// Set trigger source to SEVTCMP
    
	SEVTCMP = 25;
    
    ADCONbits.ADON = 1;			/* start the ADC module checkAL */
}

void Init_Timer(void)
{
	//Timer1 used for SlowTick
	TMR1 = 0;
	PR1 = 0xFFFF;
	T1CONbits.TCKPS = 3;	// 1:256 prescale
}

void Init_UART(void)
{
	U1MODEbits.UEN = 0;		//just RX/TX
	U1MODEbits.BRGH = 1;	//1 for 4 clocks per bit period, 0 for 16x clocks per bit period

    U1BRG = UART_BRG;       

	U1MODEbits.UARTEN = 1;
	U1STAbits.UTXEN = 1;	//enable transmit
}

void Init_Interrupts(void)
{
	//setup interrupt
	_PWM1IP = 4;		// PWM Interrupt Priority 4
	_PWM1IF = 0;		// Clearing the PWM Interrupt Flag
	_PWM1IE = 0;

	//pair 0 interrupt
	_ADCP0IP = 4;				/* interrupt priority */
	_ADCP0IF = 0;				/* clear flag */
    _ADCP0IE = 0;

	//pair 1 interrupt   	
	_ADCP1IP = 3;				/* interrupt priority */
	_ADCP1IF = 0;				/* clear flag */
    _ADCP1IE = 0;
    
    //pair 2 interrupt   	
	_ADCP2IP = 3;				/* interrupt priority */
	_ADCP2IF = 0;				/* clear flag */
    _ADCP2IE = 0;
    
    //pair 3 interrupt
  	_ADCP3IP = 3;				/* interrupt priority */
	_ADCP3IF = 0;				/* clear flag */
    _ADCP3IE = 0;
    
    //uart interrupts
    _U1TXIP = 2;
    _U1RXIP = 3;
    
    _U1TXIF = 0;
    _U1TXIE = 0;
    
    _U1RXIF = 0;
    _U1RXIE = 0;
}

void Enable_Interrupts(void)
{
	_PWM1IF = 0;				// Clearing the PWM Interrupt Flag
	_PWM1IE = 0;				// Enabling the PWM interrupt	

	//pair 0 interrupt
	_ADCP0IF = 0;				/* clear flag */
    _ADCP0IE = 1;				/* enable interrupt */

	//pair 1 interrupt   	
	_ADCP1IF = 0;				/* clear flag */
    _ADCP1IE = 0;				/* enable interrupt */
    
    //pair 2 interrupt
	_ADCP2IF = 0;				/* clear flag */
    _ADCP2IE = 0;				/* disable interrupt */
    
    //pair 3 interrupt
	_ADCP3IF = 0;				/* clear flag */
    _ADCP3IE = 0;				/* disable interrupt */
    
    //uart interrupt
    _U1TXIF = 0;
    _U1TXIE = 0;
    
    _U1RXIF = 0;
    _U1RXIE = 1;
}

void Disable_Interrupts(void)
{
	_PWM1IF = 0;				// Clearing the PWM Interrupt Flag
	_PWM1IE = 0;				// Enabling the PWM interrupt	

	//pair 0 interrupt
	_ADCP0IF = 0;				/* clear flag */
    _ADCP0IE = 0;				/* disable interrupt */
    
    //pair 1 interrupt   	
	_ADCP1IF = 0;				/* clear flag */
    _ADCP1IE = 0;				/* disable interrupt */

	//pair 2 interrupt   	
	_ADCP2IF = 0;				/* clear flag */
    _ADCP2IE = 0;				/* disable interrupt */
    
    //pair 3 interrupt
	_ADCP3IF = 0;				/* clear flag */
    _ADCP3IE = 0;				/* disable interrupt */	
    
    //uart interrupt
    _U1TXIF = 0;
    _U1TXIE = 0;
    
    _U1RXIF = 0;
    _U1RXIE = 0;
}
