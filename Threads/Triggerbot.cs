using System;
using System.Threading;
using C0reExternalBase_v2.Variables;
using static C0reExternalBase_v2.Memory;
using static C0reExternalBase_v2.Utility.Hotkeys;
using static C0reExternalBase_v2.Structs.Entitys;
using static C0reExternalBase_v2.Structs.CheatMenu;

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
                    // Verifica se ALT pressionado
                    if ((KEY_ALT_STATE))
                    //if (true)
                    {

                        Entity InCrossEntity = new Entity();

                        //player posicionado
                        InCrossEntity.m_iID = ManageMemory.ReadMemory<int>(LocalPlayer.m_iBase + Offsets.m_iCrosshairId);

                        //se é  um objeto valido
                        if (InCrossEntity.m_iID > 0 && InCrossEntity.m_iID <= 64)
                        {

                            // Obtem o player na memoria
                            InCrossEntity.m_iBase = ManageMemory.ReadMemory<int>(Offsets.m_ClientPointer + Offsets.dwEntityList + (InCrossEntity.m_iID - 1) * 0x10);

                            // Obtem o time do player
                            InCrossEntity.m_iTeam = ManageMemory.ReadMemory<int>(InCrossEntity.m_iBase + Offsets.m_iTeamNum);


                            //Console.WriteLine("Player health " + InCrossEntity.m_iHealth);

                            // Verifica se é inimigo
                            if (InCrossEntity.m_iTeam != LocalPlayer.m_iTeam)
                            {
                                ////TIROS PERSONALIZADOS POR ARMAS
                                //if (LocalPlayer.m_weaponType == 40829882
                                //    || LocalPlayer.m_weaponType == 16515351) //USP-S/ fiveseven
                                //{

                                //    int intervalo = gerador.Next(25, 175);

                                //    //3 shots
                                //    mouse_event(MouseLeftDown, 0, 0, 0, new UIntPtr());
                                //    mouse_event(MouseLeftUp, 0, 0, 0, new UIntPtr());

                                //    Thread.Sleep(25);
                                //    //Console.WriteLine("intervalo usp (ms): " + intervalo);
                                //}
                                //else if (LocalPlayer.m_weaponType == 17367607) //DEAGLE
                                //{
                                //    int intervalo = gerador.Next(250, 500);

                                //    mouse_event(MouseLeftDown, 0, 0, 0, new UIntPtr());
                                //    mouse_event(MouseLeftUp, 0, 0, 0, new UIntPtr());
                                //    //Console.WriteLine("intervalo DEAGLE (ms): " + intervalo);
                                //    Thread.Sleep(230);
                                //}
                                //else
                                //{

                                //Thread.Sleep(25);
                                mouse_event(MouseLeftDown, 0, 0, 0, new UIntPtr());
                                mouse_event(MouseLeftUp, 0, 0, 0, new UIntPtr());
                                Thread.Sleep(25);
                                //}
                            }
                        }


                        //NOFLASH TESTE''



                    }


                    

                }
                Thread.Sleep(1);
            }
        }
    }
}