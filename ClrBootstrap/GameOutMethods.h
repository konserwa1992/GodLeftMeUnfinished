#pragma once
#include <Windows.h>
#include <string>

extern "C" {
	__declspec(dllexport) int AttackTarget(DWORD skill, DWORD MonsterIndex);
}


extern "C" {
	__declspec(dllexport) long long  GetBaseAdress();
}

extern "C" {
	__declspec(dllexport) long long GetInt64(uintptr_t Adress);
}

extern "C" {
	__declspec(dllexport) int GetInt32(uintptr_t Adress);
}

extern "C" {
	__declspec(dllexport) float GetFloat(uintptr_t Adress);
}


extern "C" {
	__declspec(dllexport) int SendPacketToServer(uintptr_t deviceAddr, char packet[]);
}

extern "C" {
	__declspec(dllexport) BYTE GetByte(uintptr_t Adress);
}


extern "C" {
	__declspec(dllexport) void GetByteArray(uintptr_t adress, char* outTable, int size);
}


extern "C" {
	__declspec(dllexport) short GetShort(uintptr_t Adress);
}