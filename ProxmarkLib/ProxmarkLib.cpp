// CrossPlatformLibrary.cpp : Defines the exported functions for the DLL application.
//

#include "ProxmarkLib.h"
//#include <Windows.h>
#include <stdio.h>
#include <stdbool.h>

#include <string.h>
#include <ctype.h>
#include "Loclass\cipherutils.h"
#include "Loclass\cipher.h"
#include "Loclass\ikeys.h"
#include "Loclass\fileutils.h"
#include "Loclass\elite_crack.h"
#include "Loclass\hash1_brute.h"
#include "Iceman\crc16.h"

/*
int32_t __stdcall ProcessData(int32_t start, int32_t count, Notification notification)
{
	if (notification == nullptr)
	{
		return 0;
	}
	int32_t result = 0;
	for (int32_t i = 0; i < count; ++i)
	{
		char buffer[64];
		result += sprintf_s(buffer, "Notification %d from C++", i + start);
		notification(buffer);
		Sleep(rand() % 500 + 500);
	}
	return result;
}
*/

void byteArrayToChars(const uint8_t * arr, char * str, int len) {
	int i;
	for (i = 0; i < len; i++)
	{
		/* sprintf converts each byte to 2 chars hex string and a null byte, for example
		* 10 => "0A\0".
		*
		* These three chars would be added to the output array starting from
		* the ptr location, for example if ptr is pointing at 0 index then the hex chars
		* "0A\0" would be written as output[0] = '0', output[1] = 'A' and output[2] = '\0'.
		*
		* sprintf returns the number of chars written execluding the null byte, in our case
		* this would be 2. Then we move the ptr location two steps ahead so that the next
		* hex char would be written just after this one and overriding this one's null byte.
		*
		* We don't need to add a terminating null byte because it's already added from
		* the last hex string. */
		str += sprintf(str, "%02X", arr[i]);
	}
}

void  __stdcall ComputeReaderMAC(const uint8_t* key_p, const uint8_t* csn_p, const uint8_t* cc_nr_p, Notification notification) {
	
	uint8_t key[8]     = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t csn[8]     = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t cc_nr[12]  = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t div_key[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t rdr_mac[4] = { 0x00,0x00,0x00,0x00 };
	uint8_t crypted_csn[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	
	memcpy(key, key_p, 8);
	memcpy(csn, csn_p, 8);
	memcpy(cc_nr, cc_nr_p, 12);
	
	char buffer1[256] = "";
	char buffer2[80] = "";

	byteArrayToChars(key, buffer2, 8);
	strcat(buffer1, "Key: ");
	strcat(buffer1, buffer2);

	byteArrayToChars(csn, buffer2, 8);
	strcat(buffer1, " CSN: ");
	strcat(buffer1, buffer2);
	
	//diversifyKey(csn, key, div_key);
	diversifyKey2(csn, key, div_key,crypted_csn);

	byteArrayToChars(crypted_csn, buffer2, 8);
	strcat(buffer1, " Crypted_CSN: ");
	strcat(buffer1, buffer2);
	
	byteArrayToChars(div_key, buffer2, 8);
	strcat(buffer1, " DivKey: ");
	strcat(buffer1, buffer2);

	strcat(buffer1, " Nonce_reader: ");
	byteArrayToChars(cc_nr + 8, buffer2, 4);
	strcat(buffer1, buffer2);
	
	strcat(buffer1, " MAC_reader: ");
	doReaderMAC(cc_nr, div_key, rdr_mac);
	byteArrayToChars(rdr_mac, buffer2, 4);
	strcat(buffer1, buffer2);
	notification(buffer1);
}

void  __stdcall ComputeMAC(const uint8_t* div_key_p, const uint8_t* data_p, const int32_t size, const int32_t is_optimise, Notification notification) {

	uint8_t key[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t div_key[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t csn[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t mac[4] = { 0x00,0x00,0x00,0x00 };
	uint8_t cc[8] = { 0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00 };
	uint8_t nr[4] = { 0x00,0x00,0x00,0x00 };
	
	
	if (is_optimise == 1) {
		memcpy(key, data_p, 8);
		memcpy(csn, data_p +8, 8);
		memcpy(cc, data_p  +8+8, 8);
		memcpy(nr, data_p  +8+8+8, 4);
		diversifyKey(csn, key, div_key);
		State cipher_state;
		cipher_state = opt_doTagMAC_1(cc, div_key);
		opt_doTagMAC_2(cipher_state, nr, mac, div_key);
	}
	else {		
		memcpy(div_key, div_key_p, 8);
		doMAC_N(data_p, size, div_key, mac);
	}
	

	char buffer1[256] = "";
	char buffer2[80] = "";

	byteArrayToChars(div_key, buffer2, 8);
	strcat(buffer1, "DivKey: ");
	strcat(buffer1, buffer2);

	if (is_optimise == 1) {
		strcat(buffer1, " CC: ");
		byteArrayToChars(cc, buffer2, 8);
		strcat(buffer1, buffer2);

		strcat(buffer1, " Nonce_reader: ");
		byteArrayToChars(nr, buffer2, 4);
		strcat(buffer1, buffer2);

		strcat(buffer1, " MAC_tag: ");
		byteArrayToChars(mac, buffer2, 4);
		strcat(buffer1, buffer2);
	}
	else {
		strcat(buffer1, " Data: ");
		byteArrayToChars(data_p, buffer2, size);
		strcat(buffer1, buffer2);

		strcat(buffer1, " MAC: ");
		byteArrayToChars(mac, buffer2, 4);
		strcat(buffer1, buffer2);
	}	

	notification(buffer1);
}


void  __stdcall ComputeCRC(const uint8_t* data_p, const int32_t size, Notification notification) {

	uint8_t data[32] = { 0 };
	uint8_t crc_first = 0;
	uint8_t crc_second = 0;
	
	memcpy(data, data_p, size);
	compute_crc(CRC_ICLASS, data, size, &crc_first, &crc_second);
	
	char buffer1[256] = "";
	char buffer2[80] = "";
		
	byteArrayToChars(data, buffer2, size);
	strcat(buffer1, "Data: ");
	strcat(buffer1, buffer2);

	//buffer2[0] = '\0';
	strcat(buffer1, "    CRC: ");	
	sprintf(buffer2, "%02X%02X", crc_first, crc_second);
	//sprintf(buffer2, "%s %d", "один", 2);
	strcat(buffer1, buffer2);
	
	notification(buffer1);
}

void __stdcall EncryptBlock(const uint8_t  data[8], const uint8_t _key[16], const int mode, Notification notification) {
	uint8_t encryptedData[8];
	uint8_t key[16] = { 0xF4,0x16,0x3A,0xFE,0xA3,0xEC,0x12,0x0F,0x6B,0x57,0xB3,0x60,0x11,0xD3,0xDD,0x63 };
	memcpy(encryptedData, data, 8);
	//memcpy(key, _key, 16);
	char buffer1[256] = "";
	char buffer2[80] = "";
	byteArrayToChars(encryptedData, buffer2, 8);
	strcat(buffer1, "Data: ");
	strcat(buffer1, buffer2);

	des3_context ctx = { DES_DECRYPT ,{ 0 } };
	if (mode == 1)
	{
		des3_set2key_enc(&ctx, key);
		strcat(buffer1, "    Encrypted: ");
	}
	else
	{
		des3_set2key_dec(&ctx, key);
		strcat(buffer1, "    Decrypted: ");
	}	
	des3_crypt_ecb(&ctx, data, encryptedData);	
	byteArrayToChars(encryptedData, buffer2, 8);
	strcat(buffer1, buffer2);
	notification(buffer1);
}
