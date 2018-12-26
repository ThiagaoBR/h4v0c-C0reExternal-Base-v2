using System;
using System.Drawing;
using System.Threading;
using C0reExternalBase_v2.Structs;
using C0reExternalBase_v2.Variables;
using SlimDX.Direct3D9;
using static C0reExternalBase_v2.Memory;
using static C0reExternalBase_v2.Structs.Entitys;
using static C0reExternalBase_v2.Structs.Entitys.Entity;
using static C0reExternalBase_v2.Memory;
using static C0reExternalBase_v2.OverlayHelper;
using static C0reExternalBase_v2.Menu.CheatMenu;
using static C0reExternalBase_v2.Structs.Entitys;
using static C0reExternalBase_v2.Structs.CheatMenu;
using static C0reExternalBase_v2.Variables.Offsets;
using static C0reExternalBase_v2.Structs.Entitys.Entity;

namespace C0reExternalBase_v2.Threads
{
    class NoFlash
    {
        public static void See()
        {
            while (true)
            {
             
                float NoFlash_Value = 160;
                ManageMemory.WriteMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha, 255 - NoFlash_Value);
               
                Thread.Sleep(1);
            }
        }
    }
}
