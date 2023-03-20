#include "pch.h"
#include "GameOutMethods.h"

typedef void(__fastcall* _AttackTarget)(DWORD skill, DWORD monsteIndex);


int AttackTarget(DWORD skill, DWORD MonsterIndex) {
    _AttackTarget attackTargetWithSkill = (_AttackTarget)(GetBaseAdress() + (long long)0x0000041B41);

    attackTargetWithSkill(skill, MonsterIndex);
    return 1;
}


long long GetBaseAdress()
{
    // return BaseAddres;
    return (uintptr_t)GetModuleHandle(L"trose.exe");
}



uintptr_t GetInt64(uintptr_t Adress)
{
    uintptr_t p = (uintptr_t)Adress;
    return *reinterpret_cast<long long*>(p);
}


uintptr_t GetInt32(uintptr_t Adress)
{
    uintptr_t p = (uintptr_t)Adress;
    return *reinterpret_cast<int*>(p);
}