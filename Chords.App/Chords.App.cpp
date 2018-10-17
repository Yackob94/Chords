#include "stdafx.h"
#include "SDKDLL.h"


using namespace System;

const auto device_index = DEV_MKeys_S_White;

int main(array<System::String ^> ^args)
{
    SetControlDevice(device_index);
    auto bPlug = IsDevicePlug();

    if (bPlug)
    {
        Console::WriteLine("Keyboard is plugged in");
    }
    else
    {
        return 0;
    }

    EnableLedControl(true, device_index);

    EnableLedControl(false, device_index);

    Console::ReadLine();
    return 0;
}
