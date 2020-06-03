using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaWorld;

namespace Sala
{
    public class SalaEvents
    {
        public void InitEventRegister()
        {
            EventMgr.Instance.RegisterEvent(g_emEvent.ThingUpdateGridKey, Sala_OnThingUpdateGridKey);
            EventMgr.Instance.RegisterEvent(g_emEvent.NpcPracticeChange, Sala_OnNpcPracticeChange);
            
        }

        private void Sala_OnNpcPracticeChange(Thing sender, object[] obs)
        {
            if (World.Instance.GetFlag(111111002) != 1)
            {
                foreach (var npc in ThingMgr.Instance.NpcList)
                {
                    if (npc.Camp == XiaWorld.Fight.g_emFightCamp.Player)
                    {
                        if (npc.PropertyMgr.CheckExperienceVaild("SALA_Idlest") == false && npc.PropertyMgr.CheckFeature("ProtagonistOfSala") == true)
                        {
                            if (npc.Rank == g_emNpcRank.Disciple)
                            {
                                GlobalSet.SetNpcCanDoWorkAndDisciple(npc);
#if DEBUG
                                KLog.Dbg("initWorkerBehaviour");
#endif
#if DEBUG
                                foreach (var behaviour in GlobalSet.GetNpcBehaviours(npc))
                                {
                                    KLog.Dbg(behaviour.GetType().ToString());
                                }
#endif
                                World.Instance.SetFlag(111111002, 1);
                            }

                        }
                    }
                }

            }

            if (World.Instance.GetFlag(111111002) == 1)
            {
                EventMgr.Instance.RemoveEvent(g_emEvent.NpcPracticeChange, Sala_OnNpcPracticeChange);
            }
        }

        private void Sala_OnThingUpdateGridKey(Thing sender, object[] obs)
        {
            if (World.Instance.GetFlag(111111001) != 1)
            {
                foreach (var npc in ThingMgr.Instance.NpcList)
                {
#if DEBUG
                    KLog.Dbg("Check ProtagonistOfSala");
#endif
                    if (npc.Camp == XiaWorld.Fight.g_emFightCamp.Player)
                    {
                        if (npc.PropertyMgr.CheckExperienceVaild("SALA_Idlest") == false && npc.PropertyMgr.CheckFeature("ProtagonistOfSala") == false)
                        {
                            npc.PropertyMgr.AddFeature("ProtagonistOfSala");
                        }
                        else
                        {
                            npc.DoDeath();
                        }
                    }
                }

                Wnd_Message.Show("不对，还有一个人在天雷中活了下来，如此气运恐怕将成为修仙界新的传奇。", 1, null, true, "全新的传奇");
                Wnd_Message.Show("当空一声霹雳，好不容易逃出来的太一幸存者，就这样全部倒下了。游戏就这样结束了。", 1, null, true, "逃亡的终结");

                World.Instance.SetFlag(111111001, 1);
            }

            


            if(World.Instance.GetFlag(111111001) == 1)
            {
                EventMgr.Instance.RemoveEvent(g_emEvent.ThingUpdateGridKey, Sala_OnThingUpdateGridKey);
            }
        }
    }
}
