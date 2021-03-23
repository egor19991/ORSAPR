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
using LampParameters;

namespace LampBuilder
{
    public class LampBuild
    {
        public void BuildLamp(Lamp lamp)
        {
           
            KompasConnector.Instance.InitializationKompas();
            //KompasConnector.Instance.Document2D.ksCircle(2, 3, 4, 1);

            CreateСylinder(lamp.BodyHeight,lamp.BodyDiametr,0);
            CreateRecess(lamp.HeightSwitch, lamp.WightSwitch, lamp.BodyDiametr, true);

            CreateСylinder(lamp.TubeHeight,lamp.TubeDiametr,lamp.BodyHeight);
           
        }

        /// <summary>
        /// Метод для создания цилиндра
        /// </summary>
        /// <param name="height"></param>
        /// <param name="diametr"></param>
        /// <param name="heightPlane"></param>
        private void CreateСylinder(double height, double diametr, double heightPlane)
        {
            ksEntity currentPlane = (ksEntity)KompasConnector.Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksEntity newPlane = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            // Интерфейс настроек смещенной плоскости
            ksPlaneOffsetDefinition newPlaneDefinition = (ksPlaneOffsetDefinition)newPlane.GetDefinition();

            newPlaneDefinition.SetPlane(currentPlane); // начальная позиция плоскости: от предыдущей
            newPlaneDefinition.direction = true; // направление смещения: прямое
            newPlaneDefinition.offset = heightPlane; // расстояние смещения
            newPlane.Create(); // создать плоскость

            currentPlane = newPlane; // установить последнюю созданную плоскость текущей

            ksEntity Sketch1 = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition SketchDef1 = Sketch1.GetDefinition();
            SketchDef1.SetPlane(currentPlane);
            Sketch1.Create();

            ksDocument2D document2D = (ksDocument2D)SketchDef1.BeginEdit();
            var xc = 0;
            var yc = 0;
            var rad = diametr / 2;

            document2D.ksCircle(xc, yc, rad, 1);
            SketchDef1.EndEdit();

            var iBaseExtrusionEntity = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            // интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef = (ksBossExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();

            iBaseExtrusionDef.SetSideParam(true, 0, height);   //толщина выдавливания
            iBaseExtrusionDef.SetSketch(SketchDef1); // эскиз операции выдавливания
            iBaseExtrusionEntity.Create(); // создать операцию
        }

        private void CreateRecess(double height, double width, double bodyDiametr, bool type)
        {
            ksEntity currentPlane = (ksEntity)KompasConnector.Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            
            //Эскиз для кнопки

            double radiusBodyDiametr = bodyDiametr / 2;

            double x2 = Math.Sqrt(Math.Pow(radiusBodyDiametr, 2) - Math.Pow(width / 2, 2));

            if (type == false)
            {
                double val = -1 * x2;
                x2 = val;
            }

            currentPlane = (ksEntity)KompasConnector.Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

            ksEntity Sketch2 = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition SketchDef2 = Sketch2.GetDefinition();
            SketchDef2.SetPlane(currentPlane);
            Sketch2.Create();
            ksDocument2D document2D = (ksDocument2D)SketchDef2.BeginEdit();

            // document2D = (ksDocument2D)SketchDef2.BeginEdit();
            document2D.ksLineSeg(0, -(width / 2), 0, (width / 2), 1);
            document2D.ksLineSeg(0, -(width / 2), x2, -(width / 2), 1);
            document2D.ksLineSeg(0, (width / 2), x2, (width / 2), 1);
            document2D.ksArcByPoint(0, 0, radiusBodyDiametr, x2, -(width / 2), x2, (width / 2), 1, 1);
            SketchDef2.EndEdit();

            //Вырез кнопки
            var iBaseExtrusionEntity1 = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
            // интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef1 = (ksCutExtrusionDefinition)iBaseExtrusionEntity1.GetDefinition();
            //iBaseExtrusionDef1.SetDepthObject(true, SketchDef3);
            iBaseExtrusionDef1.SetSideParam(true, 0, height);   //толщина выдавливания
            iBaseExtrusionDef1.SetSketch(SketchDef2); // эскиз операции выдавливания
            iBaseExtrusionEntity1.Create(); // создать операцию
        }


        public void Exit()
        {
            KompasConnector.Instance.UnloadKompas();
        }
    }
}
