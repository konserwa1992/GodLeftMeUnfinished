#pragma once
#include <Windows.h>

extern "C" {
	__declspec(dllexport) int AttackTarget(DWORD skill, DWORD MonsterIndex);
}


extern "C" {
	__declspec(dllexport) long long  GetBaseAdress();
}

extern "C" {
	__declspec(dllexport) uintptr_t GetInt64(uintptr_t Adress);
}

extern "C" {
	__declspec(dllexport) uintptr_t GetInt32(uintptr_t Adress);
}

