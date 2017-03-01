



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

.text		; start

; ADC Interrupt for Pair0
__ADCP0Interrupt:
	PUSH.S						; 1
	BTG		LATA,#3				; 2 bit toggle

	MOV		ADCBUF0, w1			; 3 load value from ADC in w1	

	BTSC	_Status, #STATUS_TRIG_BIT		; 5 daca este setat, mergem direct acolo
	BRA		TRIG							; 7

	BTSC	_Status, #STATUS_PRETRIG_BIT	; daca este in pretrig
	BRA		PRETRIG

	; else if trigger stopped

	BRA		ENDADCISR

PRETRIG:
	MOV		_TriggerValue, w0				; load trigger value to wreg

	BTSC	_Status, #STATUS_SLOPE_BIT		; skip if 0
	BRA		NEGSLOPE

 POSSLOPE:
	CP		ADCBUF0				;ADCBUF0-TrigValue
	BRA 	LT, ENDADCISR 
	
	CP		_OldValue			;OldVal-TrigVal
	BRA		GT, ENDADCISR

	MOV		_XVal, w0
	MOV		w0, PTPER
	BCLR	_Status, #STATUS_PRETRIG_BIT
	BSET	_Status, #STATUS_TRIG_BIT
	BRA		TRIG

 NEGSLOPE:
	CP		ADCBUF0				;ADCBUF0-TrigValue
	BRA 	GT, ENDADCISR 
	
	CP		_OldValue			;OldVal-TrigVal
	BRA		LT, ENDADCISR

	MOV		_XVal, w0
	MOV		w0, PTPER
	BCLR	_Status, #STATUS_PRETRIG_BIT
	BSET	_Status, #STATUS_TRIG_BIT
	BRA		TRIG


TRIG:
	LSR		w1, #2, w2			; 8 right shift by 2 the ADC
	MOV		_viaddress, w0		; 9 load the current index to w0
	MOV.B	w2, [w0]			; 10 put in v[w0]

	INC		_viaddress			; 11 increment pointer address
	INC		_vi					; increment actual vi, so to compare to max
	MOV		#1600, w0			; 13 max is 1600

	CP		_vi					; 14 compare vi-w0
	BRA		NZ, ENDADCISR		; 16 jump to 1f if not zero
	
	;sampling complet
	MOV		#MHZ_CAL_VALUE, w0
	MOV		w0, PTPER
	BSET	_Status, #STATUS_DATAREADY_BIT
	BCLR	_Status, #STATUS_TRIG_BIT
	CLR		_vi					; de la capat
	MOV		#_v, w0				; punem in viaddress adresa lui v[0]
	MOV		w0, _viaddress
	
	
ENDADCISR:
	MOV 	w1, _OldValue
	BCLR	IFS6,#ADCP0IF		;18 Clear ADCP0 interrupt flag
	POP.S						; 19
RETFIE
