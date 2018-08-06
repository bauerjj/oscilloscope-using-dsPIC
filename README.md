# oscilloscope-using-dsPIC
PIC Based Oscilloscope at 1MSPS. Sends data to PC at 57000 baud hosting a C# GUI program that shows the analog waveform


![alt text](http://mcuhq.com/uploads/1610207fb580915.JPG)

Please follow the complete guide here: http://mcuhq.com/33/diy-oscilloscope-using-a-dspic

## Introduction

This repo contains an MPLABX project using the free version of the XC16 compiler. The associated C# program graphs the data sent up from the MCU via a TTL-to-USB converter. Both the PC and embedded firmware can be built from source using free tools.

Here is a youtube video that shows the generated oscilloscope plotting the data in real-time: https://www.youtube.com/watch?v=lfed25rVaQg

## Required Tools

These are the parts I used, however please note that digikey stock fluctuates over the years and so the exact model shown does not need to be used. 

| Part   |   Digkey | Description |  Purpose
|----------|:-------------:|------:|:-------:|
| dsPIC33 | [MA330020-ND](https://www.digikey.com/product-detail/en/microchip-technology/MA330020/MA330020-ND/2059584) | MODULE PLUG-IN DSPIC33F 44-QFN | Embedded Target |
| 8MHz Crystal | [XC1922-ND](https://www.digikey.com/product-detail/en/ecs-inc/ECS-080-20-4X-DU/XC1922-ND/2781927) | CRYSTAL 8.0000MHZ 20PF T/H | Accurate clock for ADC |
| Crystal Capacitors | [399-8916-ND](https://www.digikey.com/product-detail/en/kemet/C317C200J5G5TA/399-8916-ND/3522973) | CAP CER 20PF 50V NP0 RADIAL | Crystal Stabalization |
| Decoupling HF Capacitors | [BC2659CT-ND](http://www.digikey.com/scripts/DkSearch/dksus.dll?Detail&itemSeq=220562679&uq=636239161586120277) | CAP CER 1000PF 50V X7R RADIAL | Decoupling HF |
| Decoupling LF Capacitors | [493-10470-1-ND](http://www.digikey.com/scripts/DkSearch/dksus.dll?Detail&itemSeq=220562603&uq=636239161586120277) | CAP ALUM 4.7UF 20% 16V RADIAL | Decoupling LF |
| USB to TTL converter | [768-1015-ND](http://www.digikey.com/product-detail/en/ftdi-future-technology-devices-international-ltd/TTL-232R-3V3/768-1015-ND/1836393) | CABLE USB EMBD UART 3.3V .1"HDR | PC to MCU Communication |

Also needed is the PICKit 3 programmer.

A function generator would also be useful to test your scope for accuracy.

The compiler and IDE are freely available on Microchip's website. The tools work on linux, mac, and windows.

## Setup

There are more than 15 connections that must be made between the plug-in-module (PIM) and Power/GND as well as the USB to serial adapter. I simply connected wires into the PIM. It would be better to design a circuit board or buy the explorer kit that would make it much easier.

1. Make the needed connections between the PIM, USB converter, and PWR/GND. Your computer's GND will be shared between the circuit and the host. 
2. Clone the project from github
3. Download MPLABx and the XC16 compiler and flash the PIM
4. Run the C# computer program and select the COM port to listen to data from the PIC

## Feedback

Please submit all issues to the github tracker. Pull requests are also encouraged. General comments can be left at [mcuhq.com](http://mcuhq.com/33/diy-usb-oscilloscope-using-a-dspic)