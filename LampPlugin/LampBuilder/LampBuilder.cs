using System;
using Kompas3DConnector;
using Kompas6API5;
using Kompas6Constants3D;
using ModelParameters;

namespace LampBuilder
{
    /// <summary>
    /// Класс для построения лампы
    /// </summary>
    public class LampBuilder
    {
        /// <summary>
        /// Метод для построения лампы целиком
        /// </summary>
        /// <param name="lamp"></param>
        public void BuildLamp(LampParameters lamp)
        {
            KompasConnector.Instance.InitializationKompas();
            CreateСylinder(lamp.BodyHeight.
                Value,lamp.BodyDiameter.Value,0);
            CreateСylinder(lamp.TubeHeight.Value, lamp.TubeDiameter.Value,
                lamp.BodyHeight.Value);
            CreateСylinder(lamp.SocketPlatformHeight.Value, 
                lamp.SocketPlatformDiameter.Value,
                lamp.BodyHeight.Value + lamp.TubeHeight.Value);
            CreateRecess(LampParameters.HeightSwitch,
                LampParameters.WightSwitch,
                lamp.BodyDiameter.Value, true);
            CreateRecess(LampParameters.HeightCable,
                LampParameters.WightCable,
                lamp.BodyDiameter.Value, false);
            CreateHole(0, 0, LampParameters.WightCable,
                lamp.DepthHole, 0);
            CreateHole(0, LampParameters.DistanceHole / 2,
                LampParameters.DiameterHole,
                lamp.DepthHole, lamp.BodyHeight.Value + lamp.TubeHeight.Value);
            CreateHole(0, -LampParameters.DistanceHole / 2,
                LampParameters.DiameterHole, 
                lamp.DepthHole, lamp.BodyHeight.Value + lamp.TubeHeight.Value);
        }

        /// <summary>
        /// Метод для создания цилиндра
        /// </summary>
        /// <param name="height">Высота цилиндра</param>
        /// <param name="diameter">Диаметер цилиндра</param>
        /// <param name="heightPlane">Выстоа плоскости</param>
        private void CreateСylinder(double height, double diameter, double heightPlane)
        {
             //TODO: RSDN
            var SketchDef = CreateSketch(heightPlane);

            ksDocument2D document2D = (ksDocument2D)SketchDef.BeginEdit();
            var xc = 0;
            var yc = 0;
            var rad = diameter / 2;

            document2D.ksCircle(xc, yc, rad, 1);
            SketchDef.EndEdit();
            BossExtrusion(height, SketchDef);
        }

        /// <summary>
        /// Метод для создания выемок в основании под провод и выключатель
        /// </summary>
        /// <param name="depth">Глубина выемки</param>
        /// <param name="width">Ширина выемки</param>
        /// <param name="diameter">Диаметер основания</param>
        /// <param name="type">направеление выреза</param>
        private void CreateRecess(double depth, double width, double diameter, bool type)
        {
            ksEntity currentPlane = (ksEntity)KompasConnector.Instance.
                KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            
            double radiusBodyDiametr = diameter / 2;
            double x2 = Math.Sqrt(Math.Pow(radiusBodyDiametr, 2) - Math.Pow(width / 2, 2));
            short direction = 1;
            double y = width / 2;
            if (type == false)
            {
                x2 = -1 * x2;
                direction = -1;
            }

            currentPlane = (ksEntity)KompasConnector.Instance.
                KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

             //TODO: RSDN
            ksEntity Sketch = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            //TODO: RSDN naming
            ksSketchDefinition SketchDef = Sketch.GetDefinition();
            SketchDef.SetPlane(currentPlane);
            Sketch.Create();
            ksDocument2D document2D = (ksDocument2D)SketchDef.BeginEdit();
            document2D.ksLineSeg(0, -y, 0, y, 1);
            document2D.ksLineSeg(0, -y, x2, -y, 1);
            document2D.ksLineSeg(0, y, x2, y, 1);
            document2D.ksArcByPoint(0, 0, radiusBodyDiametr, x2, 
                -(width / 2), x2, (width / 2), direction, 1);
            SketchDef.EndEdit();

            CutExtrusion(depth,SketchDef);
        }

        /// <summary>
        /// Метод для создания отверстий
        /// </summary>
        /// <param name="xc">Координата центра окружности x</param>
        /// <param name="yc">Координата центра окружности y</param>
        /// <param name="diameter">Диаметр окружности</param>
        /// <param name="depth">Глубина отверстия</param>
        /// <param name="heightPlane">Расстояние от начала плоскости</param>
        public void CreateHole(double xc, double yc, double diameter, double depth, double heightPlane)
        {
            //TODO: RSDN naming
            var SketchDef = CreateSketch(heightPlane);

            ksDocument2D document2D = (ksDocument2D)SketchDef.BeginEdit();
            var rad = diameter / 2;

            document2D.ksCircle(xc, yc, rad, 1);
            SketchDef.EndEdit();

            CutExtrusion(depth, SketchDef);
        }

        /// <summary>
        /// Метод для создания эскиза
        /// </summary>
        /// <param name="heightPlane">Высота плоскости</param>
        /// <returns>Эскиз</returns>
        public ksSketchDefinition CreateSketch(double heightPlane)
        {
            ksEntity currentPlane = (ksEntity)KompasConnector
                .Instance.KompasPart.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            ksEntity newPlane = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)Obj3dType.o3d_planeOffset);
            // Интерфейс настроек смещенной плоскости
            ksPlaneOffsetDefinition newPlaneDefinition = 
                (ksPlaneOffsetDefinition)newPlane.GetDefinition();

            // начальная позиция плоскости: от предыдущей
            newPlaneDefinition.SetPlane(currentPlane);
            // направление смещения: прямое
            newPlaneDefinition.direction = true;
            // расстояние смещения
            newPlaneDefinition.offset = heightPlane;
            // создать плоскость
            newPlane.Create();
            // установить последнюю созданную плоскость текущей
            currentPlane = newPlane;

            ksEntity Sketch = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition SketchDef = Sketch.GetDefinition();
            SketchDef.SetPlane(currentPlane);
            Sketch.Create();
            return SketchDef;
        }

        /// <summary>
        /// Метод для вырезания выдавливанием 
        /// </summary>
        /// <param name="depth">Глубина выреза</param>
        /// <param name="SketchDef">Эскиз</param>
        public void CutExtrusion(double depth, ksSketchDefinition SketchDef)
        {
            var iBaseExtrusionEntity1 = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
            //TODO: Duplication
            //интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef1 = (ksCutExtrusionDefinition)iBaseExtrusionEntity1.GetDefinition();
            //толщина выдавливания
            iBaseExtrusionDef1.SetSideParam(false, 0, depth);
            // эскиз операции выдавливания
            iBaseExtrusionDef1.SetSketch(SketchDef);
            // создать операцию
            iBaseExtrusionEntity1.Create();
        }

        //TODO: RSDN naming
        /// <summary>
        /// Метод для выдавливания
        /// </summary>
        /// <param name="height">Высота выдавливания</param>
        /// <param name="SketchDef">Эскиз</param>
        public void BossExtrusion(double height, ksSketchDefinition SketchDef)
        {
            var iBaseExtrusionEntity = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            //TODO: Duplication
            // интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef = (ksBossExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();
            //толщина выдавливания
            iBaseExtrusionDef.SetSideParam(true, 0, height);
            // эскиз операции выдавливания
            iBaseExtrusionDef.SetSketch(SketchDef);
            // создать операцию
            iBaseExtrusionEntity.Create(); 
        }
        
        /// <summary>
        /// Метод для завершения компаса
        /// </summary>
        public void CloseKompas()
        {
            KompasConnector.Instance.UnloadKompas();
        }
    }
}
