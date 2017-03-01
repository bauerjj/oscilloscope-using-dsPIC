#include "comm.h"
#include "defs.h"

UINT8 Command_Id;
UINT16 TXBuf_Counter;
UINT8 RXBuffer[50];
UINT8 RXBuffI;

void Init_Comm(void)
{
	Status.bits.TxInProgress = 0;
	Command_Id = 0;
	TXBuf_Counter = 0;
	RXBuffI = 0;
}

void Comm_Process_Data(void)
{
	if(Status.bits.TxInProgress == 0)
	{
		if(Status.bits.DataReady == 1)
		{
			TXBuf_Counter = 0;
			Command_Id = 0xA0;
			Status.bits.TxInProgress = 1;
		}
		
		
	}
	
	if( (Status.bits.TxInProgress == 1) && (U1STAbits.TRMT) )	//if transmitting and uart-transmitter is free
	{
		if(TXBuf_Counter < 4)
		{
			switch(TXBuf_Counter)    ///snpC"   "end
			{
				case 0: U1TXREG = 's'; break;
				case 1: U1TXREG = 'n'; break;
				case 2: U1TXREG = 'p'; break;
				case 3: U1TXREG = Command_Id; break;
			}
		}
		else
		{
			switch(Command_Id)
			{	
				case 0xA0:		//report arrays with all data
					
					if(TXBuf_Counter < 1604)
						U1TXREG = v[TXBuf_Counter-4];
					else	
						switch(TXBuf_Counter)
						{
							case 1604: U1TXREG = 'e'; break;
							case 1605: U1TXREG = 'n'; break;
							case 1606:
								U1TXREG = 'd';
								Status.bits.TxInProgress = 0;
								Status.bits.DataReady = 0;
							break;	
						};						
				break;	
			};
		}
		//has transmitted a character, now increment
		TXBuf_Counter++;	
	}
}


void __attribute__ ( (interrupt, no_auto_psv) ) _U1RXInterrupt( void )
{
	_U1RXIF = 0;

	U1STAbits.OERR = 0;

	RXBuffer[RXBuffI++] = U1RXREG;

	if(RXBuffI > 2)
	{
		if( (RXBuffer[RXBuffI - 3] == 'e') && (RXBuffer[RXBuffI - 2] == 'n') && (RXBuffer[RXBuffI - 1] == 'd'))
		{
			//snp received
			YVal = RXBuffer[RXBuffI - 4];
			XVal = RXBuffer[RXBuffI - 5];
			XVal = MHZ_CAL_VALUE << XVal;
			TriggerValue = (RXBuffer[RXBuffI - 6] << 2);
			if(RXBuffer[RXBuffI - 7] == '0')
				Status.bits.Slope = SLOPE_POSITIVE;
			else
				Status.bits.Slope = SLOPE_NEGATIVE;

			RXBuffI = 0;

			if( (Status.bits.Trig == 0) && (Status.bits.DataReady == 0) )
				Status.bits.PreTrig = 1;

			LED1_WRITE ^= 1;
		}
	}

}
