#include "pch.h"
#include "GameOutMethods.h"
#include <exception>
#include <typeinfo>
#include <string>



typedef void(__fastcall* _AttackTarget)(DWORD skill, DWORD monsteIndex);
typedef void(__fastcall* _PacketSend)(uintptr_t deviceAddr, char packet[]);

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



int SendPacketToServer(uintptr_t deviceAddr, char packet[])
{
    _PacketSend attackTargetWithSkill = (_PacketSend)(GetBaseAdress() + (long long)0x26521);

    attackTargetWithSkill(deviceAddr, packet);

    return 0; 
}
