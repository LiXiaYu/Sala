using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XiaWorld;

namespace Sala
{
    public static class GlobalSet
    {
        public static void SetSchoolMaxNpcAsOne()
        {
            GameDefine.SchoolMaxNpc[0] = 1;
            GameDefine.SchoolMaxNpc[1] = 1;
            GameDefine.SchoolMaxNpc[2] = 1;
            GameDefine.SchoolMaxNpc[3] = 1;
        }


        public static void SetNpcCanDoWorkAndDisciple(Npc npc)
        {
            MethodInfo methodInfo = npc.GetType().GetMethod("InitWorkerBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(npc, new object[] { });
            
        }

        public static List<BehaviourBase> GetNpcBehaviours(Npc npc)
        {
            FieldInfo fieldInfo = npc.JobEngine.GetType().GetField("m_lisBehaviours", BindingFlags.Instance | BindingFlags.NonPublic);
            return fieldInfo.GetValue(npc.JobEngine) as List<BehaviourBase>;
        }
    }
}
