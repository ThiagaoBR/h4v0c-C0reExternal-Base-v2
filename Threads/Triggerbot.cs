using C0reExternalBase_v2.Variables;
using System;
using System.Threading;
using static C0reExternalBase_v2.Memory;
using static C0reExternalBase_v2.Structs.Entitys;
using static C0reExternalBase_v2.Utility.Hotkeys;

namespace C0reExternalBase_v2.Threads
{
    class Triggerbot
    {
        public static void Trigger()
        {
            TimeSpan lastshot;
            Random gerador = new Random(LocalPlayer.m_iBase);

            // Infinite Loop
            while (true)
            {
                // Check If Triggerbot Is Active
                if (true)
                {
                    //PRESS ALT TO WORK
                    if ((KEY_ALT_STATE))
                    //if (true)
                    {

                        Entity InCrossEntity = new Entity();

                        InCrossEntity.m_iID = ManageMemory.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iCrosshairId);

                        if (InCrossEntity.m_iID > 0 && InCrossEntity.m_iID <= 64)
                        {
                            InCrossEntity.m_iBase = ManageMemory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.dwEntityList + (InCrossEntity.m_iID - 1) * 0x10);
                            InCrossEntity.m_iTeam = ManageMemory.ReadMemory<int>(InCrossEntity.m_iBase + Offsets.m_iTeamNum);
                            if (InCrossEntity.m_iTeam != LocalPlayer.m_iTeam)
                            {
                                mouse_event(MouseLeftDown, 0, 0, 0, new UIntPtr());
                                mouse_event(MouseLeftUp, 0, 0, 0, new UIntPtr());
                                Thread.Sleep(20);

                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}