using System;
using Kompas3DConnector;
using Kompas6API5;
using Kompas6Constants3D;
using ModelParameters;

namespace ModelBuilder
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
            if (lamp.EnableFloorLamp)
            {
                CreateFloorLamp( lamp.BodyDiameter.Value, lamp.DepthHole - lamp.SocketPlatformHeight.Value,
                    lamp.SocketPlatformDiameter.Value, 3, lamp.SocketPlatformHeight.Value);
            }
        }

        /// <summary>
        /// Метод для создания цилиндра
        /// </summary>
        /// <param name="height">Высота цилиндра</param>
        /// <param name="diameter">Диаметер цилиндра</param>
        /// <param name="heightPlane">Выстоа плоскости</param>
        private void CreateСylinder(double height, double diameter, double heightPlane)
        {
            var sketchDef = CreateSketch(heightPlane);
            sketchDef = CreateCircle(0, 0, diameter, sketchDef);
            sketchDef.EndEdit();
            BossExtrusion(height, sketchDef, true, false);
        }

        /// <summary>
        /// Метод для создания торшера
        /// </summary>
        /// <param name="diameter">диаметер нижней окружности торшера</param>
        /// <param name="heightPlane">высота плоскости, с которой начинается построение</param>
        /// <param name="diameterSocketPlatform">диаметер окружности, к которой происходит присоедиенение креплений</param>
        /// <param name="line">количество линий</param>
        /// <param name="heightSocketPlatform">высота площадки под патрон</param>
        private void CreateFloorLamp( double diameter, double heightPlane, double diameterSocketPlatform,
            int line, double heightSocketPlatform)
        {
            double scale = 1.4;
            //Окружность для крепления
            double diameterBase = diameter * scale;
            var sketchDef1 = CreateSketch(heightPlane); 
            sketchDef1 = CreateCircle(0,0, diameterBase, sketchDef1);

            //Линии для соединения площадки под патрон и окружности
            ksDocument2D document2D = (ksDocument2D) sketchDef1.BeginEdit();
            scale = 0.991;
            for (int i = 1; i <= line; i++)
            {
                double rad = (360 / line * i) * (Math.PI / 180.0);
                
                var x1 = diameterSocketPlatform / 2 * Math.Cos(rad) * scale;
                var y1 = diameterSocketPlatform / 2 * Math.Sin(rad) * scale;
                var x2 = diameterBase / 2 * Math.Cos(rad);
                var y2 = diameterBase / 2 * Math.Sin(rad);
                document2D.ksLineSeg(x1, y1, x2, y2, 1);
            }
            sketchDef1.EndEdit();
            BossExtrusion(heightSocketPlatform, sketchDef1,true, true);

            //Нижняя окружность для торшера
            var sketchDef2 = CreateSketch(heightPlane + heightSocketPlatform);
            sketchDef2 = CreateCircle(0,0, diameterBase,  sketchDef2);
            sketchDef2.EndEdit();

            //Верхняя окружность для торшера
            scale = 1.33;
            var sketchDef3 = CreateSketch((heightPlane + heightSocketPlatform) * scale);
            sketchDef3 = CreateCircle(0 ,0,diameterBase*0.8, sketchDef3);
            sketchDef3.EndEdit();

            //выдаливание нижней и верхней окружности
            var loftElement = (ksEntity)KompasConnector.Instance.KompasPart.NewEntity((short)Obj3dType.o3d_baseLoft);
            var baseLoftDefinition = (ksBaseLoftDefinition)loftElement.GetDefinition();
            baseLoftDefinition.SetLoftParam(false, true, true);
            baseLoftDefinition.SetThinParam(true, (short)Direction_Type.dtNormal, 1, 1);
            var sketches = (ksEntityCollection)baseLoftDefinition.Sketchs();
            sketches.Clear();
            sketches.Add(sketchDef2);
            sketches.Add(sketchDef3);
            loftElement.Create();
        }

        /// <summary>
        /// Метод для создания окружности
        /// </summary>
        /// <param name="xc">координата центра окружности x</param>
        /// <param name="yc">координата центра окружности y</param>
        /// <param name="diameter">Диаметер окружности</param>
        /// <param name="sketchDef">Скетч</param>
        /// <returns></returns>
        private ksSketchDefinition CreateCircle( double xc, double yc, double diameter, ksSketchDefinition sketchDef)
        {
            ksDocument2D document2D = (ksDocument2D)sketchDef.BeginEdit();
            var rad = diameter / 2;

            document2D.ksCircle(xc, yc, rad, 1);
            sketchDef.EndEdit();
            return sketchDef;
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

            ksEntity sketch = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDef = sketch.GetDefinition();
            sketchDef.SetPlane(currentPlane);
            sketch.Create();
            ksDocument2D document2D = (ksDocument2D)sketchDef.BeginEdit();
            document2D.ksLineSeg(0, -y, 0, y, 1);
            document2D.ksLineSeg(0, -y, x2, -y, 1);
            document2D.ksLineSeg(0, y, x2, y, 1);
            document2D.ksArcByPoint(0, 0, radiusBodyDiametr, x2, 
                -(width / 2), x2, (width / 2), direction, 1);
            sketchDef.EndEdit();

            CutExtrusion(depth, false,sketchDef);
        }

        /// <summary>
        /// Метод для создания отверстий
        /// </summary>
        /// <param name="xc">Координата центра окружности x</param>
        /// <param name="yc">Координата центра окружности y</param>
        /// <param name="diameter">Диаметр окружности</param>
        /// <param name="depth">Глубина отверстия</param>
        /// <param name="heightPlane">Расстояние от начала плоскости</param>
        private void CreateHole(double xc, double yc, double diameter, double depth, double heightPlane)
        {
            var sketchDef = CreateSketch(heightPlane);

            sketchDef = CreateCircle(xc,yc,diameter,sketchDef);
            sketchDef.EndEdit();

            CutExtrusion(depth,false, sketchDef);
        }

        /// <summary>
        /// Метод для создания эскиза
        /// </summary>
        /// <param name="heightPlane">Высота плоскости</param>
        /// <returns>Эскиз</returns>
        private ksSketchDefinition CreateSketch(double heightPlane)
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
        /// <param name="sketchDef">Эскиз</param>
        ///  <param name="forward">Направление выдавливания</param>
        private void CutExtrusion(double depth, bool forward, ksSketchDefinition sketchDef)
        {
            var iBaseExtrusionEntity1 = (ksEntity)KompasConnector
                .Instance.KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_cutExtrusion);
            //интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef1 = (ksCutExtrusionDefinition)iBaseExtrusionEntity1.GetDefinition();
            //толщина выдавливания
            iBaseExtrusionDef1.SetSideParam(forward, 0, depth);
            // эскиз операции выдавливания
            iBaseExtrusionDef1.SetSketch(sketchDef);
            // создать операцию
            iBaseExtrusionEntity1.Create();
        }

        /// <summary>
        /// Метод для выдавливания
        /// </summary>
        /// <param name="height">Высота выдавливания</param>
        /// <param name="sketchDef">Эскиз</param>
        /// <param name="forward">Направление выдавливания</param>
        /// <param name="thin">тонкая стенка</param>
        private void BossExtrusion(double height, ksSketchDefinition sketchDef, bool forward, bool thin)
        {
            var iBaseExtrusionEntity = (ksEntity)KompasConnector.Instance.
                KompasPart.NewEntity((short)ksObj3dTypeEnum.o3d_bossExtrusion);
            // интерфейс свойств базовой операции выдавливания
            var iBaseExtrusionDef = (ksBossExtrusionDefinition)iBaseExtrusionEntity.GetDefinition();
            //толщина выдавливания
            if (thin)
            {
                iBaseExtrusionDef.SetThinParam(true, 0, 1, 1);
            }
            iBaseExtrusionDef.SetSideParam(forward, 0, height);
            // эскиз операции выдавливания
            iBaseExtrusionDef.SetSketch(sketchDef);
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
