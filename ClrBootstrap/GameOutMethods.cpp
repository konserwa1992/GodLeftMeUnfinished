#include "pch.h"
#include "GameOutMethods.h"
#include <exception>

typedef void(__fastcall* _AttackTarget)(DWORD skill, DWORD monsteIndex);


int AttackTarget(DWORD skill, DWORD monsterIndex) {
    _AttackTarget attackTargetWithSkill = (_AttackTarget)(GetBaseAdress() + (long long)0x0000041B41);

    attackTargetWithSkill(skill, monsterIndex);
    return 1;
}


long long GetBaseAdress()
{
    // return BaseAddres;
    return (uintptr_t)GetModuleHandle(L"trose.exe");
}



long long GetInt64(uintptr_t adress)
{
    return *reinterpret_cast<long long*>(adress);
}


int GetInt32(uintptr_t adress)
{
    return *reinterpret_cast<int*>(adress);
}

float GetFloat(uintptr_t adress)
{
        return *reinterpret_cast<float*>(adress);
}