using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas3DConnector;
using KompasAPI7;
using Kompas6API5;
using Kompas6Constants3D;
using KAPITypes;

namespace LampBuilder
{
    public class LampBuild
    {
        public static void SvinRT()
        {
            KompasConnector.Instance.InitializationKompas();
            //KompasConnector.Instance.Document2D.ksCircle(2, 3, 4, 1);

            ksEntity currentPlane = (ksEntity)KompasConnector.Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksEntity Sketch1 = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition SketchDef1 = Sketch1.GetDefinition();
            SketchDef1.SetPlane(currentPlane);
            Sketch1.Create();

            ksDocument2D document2D = (ksDocument2D)SketchDef1.BeginEdit();
            var xc = 0;
            var yc = 0;
            var rad = 12.5;

            document2D.ksCircle(xc, yc, rad, 1);
            SketchDef1.EndEdit();
           
        }
    }
}
