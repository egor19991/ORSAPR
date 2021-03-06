using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KompasAPI7;
using Kompas6API5;
using Kompas6Constants;
using KAPITypes;

namespace Kompas3DConnector
{
    public class Class1
    {
        private KompasObject kompas;

        public void OpenKompas()
        {
            if (kompas == null)
            {
                #if __LIGHT_VERSION__
                Type t = Type.GetTypeFromProgID("KOMPASLT.Application.5");
                #else
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                #endif
                kompas = (KompasObject) Activator.CreateInstance(t);
            }
            if (kompas != null)
            {
                kompas.Visible = true;
                kompas.ActivateControllerAPI();
            }
        }
    }
}
