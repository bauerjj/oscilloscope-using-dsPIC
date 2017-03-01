

.ifndef _ASSEMBLY_INC_
.equiv  _ASSEMBLY_INC_,1

.include "p33FJ16GS504.inc"

.equiv STATUS_SLOPE_BIT,		5
.equiv STATUS_TRIGSTOP_BIT,		6
.equiv STATUS_PRETRIG_BIT,		7
.equiv STATUS_TRIG_BIT,			8
.equiv STATUS_DATAREADY_BIT,	9

.equiv MHZ_CAL_VALUE,		940
		
.section *,ymemory,bss,align(2)

.section *,xmemory,bss,align(2)

.global _Status
.global _TriggerValue
.global _OldValue

.global _v
.global _vi
.global _viaddress

.global 

.endif

.text

.global __ADCP0Interrupt	; Globalize adc pair 1 interrupt
