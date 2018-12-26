using System;
using System.Diagnostics;
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
    class Update
    {
        public static Visuals _Visuals = new Visuals();

        public static void Read()
        {
            m_pWindowHandle = GetWindowHandle();

            while (true)
            {
                //LOCAL
                LocalPlayer.m_iBase = ManageMemory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.dwLocalPlayer);


                LocalPlayer.m_iTeam = ManageMemory.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iTeamNum);
                LocalPlayer.m_iClientState = ManageMemory.ReadMemory<int>(Offsets.m_EnginePointer + Offsets.dwClientState);
                LocalPlayer.m_iGlowBase = ManageMemory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.dwGlowObjectManager);
                LocalPlayer.m_iJumpFlags = ManageMemory.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_fFlags);
                LocalPlayer.m_angEyeAngles = ManageMemory.ReadMemory<QAngle>(LocalPlayer.m_iClientState + Offsets.m_angEyeAngles);
                LocalPlayer.m_VecOrigin = ManageMemory.ReadMemory<Vector3D>(LocalPlayer.m_iBase + Offsets.m_vecOrigin);
                LocalPlayer.m_weaponType = ManageMemory.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_hActiveWeapon);

                LocalPlayer.fFlashDuration = ManageMemory.ReadMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashDuration);
                LocalPlayer.m_fFlashAlpha = ManageMemory.ReadMemory<float>(LocalPlayer.m_iBase + Offsets.m_flFlashMaxAlpha);

                LocalPlayer.Arrays.ViewMatrix = ManageMemory.ReadMatrix<float>(Offsets.m_ClientPointer + Offsets.dwViewMatrix, 16);
                //ENTITY
                for (var i = 0; i < 64; i++)
                {
                    Entity Entity = Arrays.Entity[i];

                    Entity.m_iBase = ManageMemory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.dwEntityList + i * 0x10);

                    if (Entity.m_iBase > 0)
                    {
                        Entity.m_VecOrigin = ManageMemory.ReadMemory<Vector3D>(Entity.m_iBase + Offsets.m_vecOrigin);
                        Entity.m_VecMin = ManageMemory.ReadMemory<Vector3D>(Entity.m_iBase + Offsets.m_vecMins);
                        Entity.m_VecMax = ManageMemory.ReadMemory<Vector3D>(Entity.m_iBase + Offsets.m_vecMaxs);

                        Entity.m_iTeam = ManageMemory.ReadMemory<int>(Entity.m_iBase + Offsets.m_iTeamNum);
                        Entity.m_iHealth = ManageMemory.ReadMemory<int>(Entity.m_iBase + Offsets.m_iHealth);
                        Entity.m_iGlowIndex = ManageMemory.ReadMemory<int>(Entity.m_iBase + Offsets.m_iGlowIndex);

                        Entity.m_iTipoArma = ManageMemory.ReadMemory<int>(Entity.m_iBase + Offsets.m_hActiveWeapon);
                        
                        if (Entity.m_iHealth != 0)
                        {
                            Entity.m_estavivo = true;
                            ManageMemory.WriteMemory<int>(Entity.m_iBase + Offsets.m_bSpotted, 1);
                        }
                        else
                            Entity.m_estavivo = false;

                        Arrays.Entity[i] = Entity;


                    }
                }
                Thread.Sleep(1);
            }
        }


        private static IntPtr GetWindowHandle()
        {
            var processes = Process.GetProcessesByName("csgo");
            if (processes.Length > 0)
                return processes[0].MainWindowHandle;
            else
                return (IntPtr)null;
        }
    }
}
