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

    EnableLedControl(true);
    RefreshLed(false,device_index);

    SetLedColor(3, 1, 255, 255, 255);
    SetLedColor(3,1,0,0,0);
    SetLedColor(3, 1, 255, 255, 255);

    EnableLedControl(false);

    Console::ReadLine();
    return 0;
}
