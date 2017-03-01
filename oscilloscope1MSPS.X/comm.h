#ifndef __COMM_H__
#define __COMM_H__

#include "mytypes.h"

void Init_Comm(void);
void Comm_Process_Data(void);

void __attribute__((interrupt, no_auto_psv)) _U1RXInterrupt(void);


#endif
