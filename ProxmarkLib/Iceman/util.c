//-----------------------------------------------------------------------------
// Jonathan Westhues, Sept 2005
//
// This code is licensed to you under the terms of the GNU GPL, version 2 or,
// at your option, any later version. See the LICENSE.txt file for the text of
// the license.
//-----------------------------------------------------------------------------
// Utility functions used in many places, not specific to any piece of code.
//-----------------------------------------------------------------------------
#include "util.h"
#include <stdio.h>
#include <stdbool.h>
#include <ctype.h>
#include <stdint.h>
//size_t nbytes(size_t nbits) {
//	return (nbits >> 3)+((nbits % 8) > 0);
//}

/*
 ref  http://www.csm.ornl.gov/~dunigan/crc.html
 Returns the value v with the bottom b [0,32] bits reflected. 
 Example: reflect(0x3e23L,3) == 0x3e26
*/
uint32_t reflect(uint32_t v, int b) {
	uint32_t t = v;
	for ( int i = 0; i < b; ++i) {
		if (t & 1)
			v |=  BITMASK((b-1)-i);
		else
			v &= ~BITMASK((b-1)-i);
		t>>=1;
	}
	return v;
}

uint8_t reflect8(uint8_t b) {
	return ((b * 0x80200802ULL) & 0x0884422110ULL) * 0x0101010101ULL >> 32;
}
uint16_t reflect16(uint16_t b) {
    uint16_t v = 0;
    v |= (b & 0x8000) >> 15; 
    v |= (b & 0x4000) >> 13;
    v |= (b & 0x2000) >> 11;
    v |= (b & 0x1000) >> 9;
    v |= (b & 0x0800) >> 7;
    v |= (b & 0x0400) >> 5;
    v |= (b & 0x0200) >> 3;
    v |= (b & 0x0100) >> 1;

    v |= (b & 0x0080) << 1;
    v |= (b & 0x0040) << 3;
    v |= (b & 0x0020) << 5;
    v |= (b & 0x0010) << 7;
    v |= (b & 0x0008) << 9;
    v |= (b & 0x0004) << 11;
    v |= (b & 0x0002) << 13;
    v |= (b & 0x0001) << 15;
    return v;
}

void num_to_bytes(uint64_t n, size_t len, uint8_t* dest) {
	while (len--) {
		dest[len] = (uint8_t) n;
		n >>= 8;
	}
}

uint64_t bytes_to_num(uint8_t* src, size_t len) {
	uint64_t num = 0;
	while (len--) {
		num = (num << 8) | (*src);
		src++;
	}
	return num;
}

// RotateLeft - Ultralight, Desfire
void rol(uint8_t *data, const size_t len) {
    uint8_t first = data[0];
    for (size_t i = 0; i < len-1; i++) {
        data[i] = data[i+1];
    }
    data[len-1] = first;
}

void lsl (uint8_t *data, size_t len) {
    for (size_t n = 0; n < len - 1; n++) {
        data[n] = (data[n] << 1) | (data[n+1] >> 7);
    }
    data[len - 1] <<= 1;
}

int32_t le24toh (uint8_t data[3]) {
    return (data[2] << 16) | (data[1] << 8) | data[0];
}

//convert hex digit to integer
uint8_t hex2int(char hexchar){
    switch(hexchar){
        case '0': return 0; break;
        case '1': return 1; break;
        case '2': return 2; break;
        case '3': return 3; break;
        case '4': return 4; break;
        case '5': return 5; break;
        case '6': return 6; break;
        case '7': return 7; break;
        case '8': return 8; break;
        case '9': return 9; break;
        case 'a':
        case 'A': return 10; break;
        case 'b':
		case 'B': return 11; break;
        case 'c':
        case 'C': return 12; break;
        case 'd':
		case 'D': return 13; break;
        case 'e':
        case 'E': return 14; break;
        case 'f':
        case 'F': return 15; break;
        default:
            return 0;
    }
}


