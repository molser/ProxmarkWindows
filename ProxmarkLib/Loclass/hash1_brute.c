/*****************************************************************************
 * WARNING
 *
 * THIS CODE IS CREATED FOR EXPERIMENTATION AND EDUCATIONAL USE ONLY. 
 * 
 * USAGE OF THIS CODE IN OTHER WAYS MAY INFRINGE UPON THE INTELLECTUAL 
 * PROPERTY OF OTHER PARTIES, SUCH AS INSIDE SECURE AND HID GLOBAL, 
 * AND MAY EXPOSE YOU TO AN INFRINGEMENT ACTION FROM THOSE PARTIES. 
 * 
 * THIS CODE SHOULD NEVER BE USED TO INFRINGE PATENTS OR INTELLECTUAL PROPERTY RIGHTS. 
 *
 *****************************************************************************
 *
 * This file is part of loclass. It is a reconstructon of the cipher engine
 * used in iClass, and RFID techology.
 *
 * The implementation is based on the work performed by
 * Flavio D. Garcia, Gerhard de Koning Gans, Roel Verdult and
 * Milosch Meriac in the paper "Dismantling IClass".
 *
 * Copyright (C) 2014 Martin Holst Swende
 *
 * This is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License version 2 as published
 * by the Free Software Foundation, or, at your option, any later version. 
 *
 * This file is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with loclass.  If not, see <http://www.gnu.org/licenses/>.
 * 
 * 
 ****************************************************************************/

#include <stdio.h>
#include "cipherutils.h"
#include <stdint.h>
#include <stdbool.h>
#include <string.h>
//#include <unistd.h>
#include <ctype.h>
#include "elite_crack.h"

void calc_score(uint8_t* csn, uint8_t* k)
{
    uint8_t score =0 ;
    uint8_t i;
    uint8_t goodvals[16] = {0};
    uint8_t uniq_vals[8] = {0};
    memset(goodvals, 0x00, 16);
    memset(uniq_vals, 0x00, 8);
    uint8_t badval = 0;
    int badscore =0;
    for(i=0; i < 8 ; i++)
    {
        if(k[i] == 0x01) continue;
        if(k[i] == 0x00) continue;
        if(k[i] == 0x45) continue;
        if(k[i] < 16){
            goodvals[k[i]] = 1;
        }
//        if(k[i] ==9 || k[i]==8){
//            goodvals[k[i]] = 1;
//        }

        else if(k[i]>=16){
            badscore++;
            badval = k[i];
        }
    }
    for(i =0; i < 16; i++)
    {
        if(goodvals[i])
        {
            uniq_vals[score] = i;
            score +=1;
        }
    }
    if(score >=1 && badscore < 2)
    {
        printf("CSN\t%02x%02x%02x%02x%02x%02x%02x%02x\t%02x %02x %02x %02x %02x %02x %02x %02x\t"
               ,csn[0],csn[1],csn[2],csn[3],csn[4],csn[5],csn[6],csn[7]
                ,k[0],k[1],k[2],k[3],k[4],k[5],k[6],k[7]
                );
        for(i =0 ; i < score; i++)
        {
            printf("%d,", uniq_vals[i]);
        }
        printf("\tbadscore: %d (%02x)", badscore, badval);
        printf("\r\n");

    }

}

void brute_hash1(){
    //uint8_t csn[8] = {0,0,0,0,0xf7,0xff,0x12,0xe0};
    uint8_t k[8]= {0,0,0,0,0,0,0,0};
    uint16_t a,b,c,d;
	//uint8_t testcsn[8] ={0x00,0x0d,0x0f,0xfd,0xf7,0xff,0x12,0xe0} ;
    uint8_t csn[8] = {0x04,0x0f,0x0f,0xf7,0xf7,0xff,0x12,0xe0};
	//uint8_t testkey2[8] = {0};
    hash1(csn, k);
    printf("CSN\t%02x%02x%02x%02x%02x%02x%02x%02x\t%02x %02x %02x %02x %02x %02x %02x %02x\t"
               ,csn[0],csn[1],csn[2],csn[3],csn[4],csn[5],csn[6],csn[7]
                ,k[0],k[1],k[2],k[3],k[4],k[5],k[6],k[7]
                );

	//uint8_t testkey[8] ={0x05 ,0x01 ,0x00 ,0x10 ,0x45 ,0x08 ,0x45,0x56} ;
    calc_score(csn,k);
    printf("Brute forcing hashones\n");
    //exit(1);
    for(a=0;a < 256;a++)
    {
        //if(a > 0)printf("%d/256 done...\n", a);
        for(b=0;b < 256 ; b++)
            for(c=0;c < 256;c++)
               for(d=0;d < 256;d++)
                {
                    csn[0] = a;
                    csn[1] = b;
                    csn[2] = c;
                    csn[3] = d;
                    csn[4] = 0xf7;
                    csn[5] = 0xff;
                    csn[6] = 0x12;
                    csn[7] = 0xe0;
                    hash1(csn, k);
                    calc_score(csn,k);
               }
    }

}

