using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XiaWorld;

namespace Sala
{
    public class EnterClass
    {
        public int Main()
        {
            KLog.Dbg("Start Sala");

            GlobalSet.SetSchoolMaxNpcAsOne();

            SalaEvents salaEvents = new SalaEvents();
            salaEvents.InitEventRegister();
            return 0;
        }
    }
}
