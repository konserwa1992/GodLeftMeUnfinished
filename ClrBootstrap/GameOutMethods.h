#pragma once
#include <Windows.h>

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

