// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the CROSSPLATFORMLIBRARY_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// CROSSPLATFORMLIBRARY_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef PROXMARKLIB_EXPORTS
#define PROXMARKLIB_API __declspec(dllexport)
#else
#define PROXMARKLIB_API __declspec(dllimport)
#endif

#include <cstdint>
#include <stdio.h>



typedef void(__stdcall* Notification)(const char*);
//typedef void(* Notification)(const char*);

extern "C"
{
	#include "Loclass\cipherutils.h"
	#include "Loclass\cipher.h"
	#include "Loclass\optimized_cipher.h"	
	#include "Loclass\ikeys.h"
	#include "Loclass\fileutils.h"
	#include "Loclass\elite_crack.h"
	#include "Loclass\hash1_brute.h"	
	//int32_t PROXMARKLIB_API __stdcall ProcessData(int32_t start, int32_t count, Notification notification);
	//void PROXMARKLIB_API __stdcall ComputeReaderMAC(uint8_t key[8], uint8_t cnc[8], uint8_t cc_nr [12], Notification notification);
	void PROXMARKLIB_API __stdcall ComputeReaderMAC(const uint8_t* key, const uint8_t* csn, const uint8_t* cc_nr, Notification notification);
	void PROXMARKLIB_API __stdcall ComputeMAC(const uint8_t* div_key, const uint8_t* data, int32_t size, int32_t is_optimize, Notification notification);
}

extern "C"
{
	#include "Iceman\crc16.h"	
	void PROXMARKLIB_API __stdcall ComputeCRC(const uint8_t* data, int32_t size, Notification notification);
}

extern "C"
{
	#include "Iceman\Common\Polarssl\des.h"	
	void PROXMARKLIB_API __stdcall EncryptBlock(const uint8_t  data [8], const uint8_t key[16], const int mode, Notification notification);
}