using System;
using System.Collections.Generic;

namespace ModelParameters
{
    /// <summary>
    /// Класс содержит данные лампы
    /// </summary>
    public class LampParameters
    {
        /// <summary>
        /// Лист параметров
        /// </summary>
        private readonly List<Parameter> _parameters;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public Parameter BodyHeight { get; set; }

        /// <summary>
        /// Свойство, задающее диаметр корпуса
        /// </summary>
        public Parameter BodyDiameter { get; set; }

        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public Parameter TubeHeight { get; set; }

        /// <summary>
        /// Свойство, задающее диаметр стойки
        /// </summary>
        public Parameter TubeDiameter { get; set; }

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public Parameter SocketPlatformHeight { get; set; }

        /// <summary>
        /// Свойство, задающее диаметр платформы под патрон
        /// </summary>
        public Parameter SocketPlatformDiameter { get; set; }
        
        /// <summary>
        /// Константа, хранящая диаметр отверстия
        /// на площадке под патрон для саморезов
        /// </summary>
        public const double DiameterHole = 3;

        /// <summary>
        /// Константа, хранящая расстояние между
        /// отверстиями на площадке под патрон для саморезов
        /// </summary>
        public const double DistanceHole = 57;

        /// <summary>
        /// Константа, хранящая высоту кабеля провода
        /// </summary>
        public const double HeightCable = 4;
        
        /// <summary>
        /// Свойство, возращающее ширину кнопки
        /// </summary>
        public const double WightSwitch = 28;

        /// <summary>
        /// Константа, хранящая высоту кнопки
        /// </summary>
        public const double HeightSwitch = 22;

        /// <summary>
        /// Константа, хранящая ширину кабеля провода
        /// </summary>
        public const double WightCable = 6;

        /// <summary>
        /// Свойство, возращающее глубину отверстия
        /// в корусе, ножке, платформе
        /// </summary>
        public double DepthHole
        {
            get
            {
                if (BodyHeight.Value > 0 && TubeHeight.Value > 0
                                         && SocketPlatformHeight.Value >0 )
                {
                    return BodyHeight.Value + TubeHeight.Value 
                                            + SocketPlatformHeight.Value;
                }
                else
                {
                    throw new ArgumentException("Not set BodyHeight or " +
                                                "TubeHeight or SocketPlatformHeight");
                }
            }
        }

        /// <summary>
        /// Свойство, присваивающее значение по умолчанию
        /// для зависимых параметров
        /// </summary>
        public void DefaultValue()
        {

            foreach (var carrentParameter in _parameters)
            {
                carrentParameter.Value = carrentParameter.DefaultValue;
            }
        }

        /// <summary>
        /// Свойство, присваивающе максимальное
        /// значение для зависимых параметров
        /// </summary>
        public void MaxValue()
        {
            foreach (var currentParameter in _parameters)
            {
                currentParameter.Value = currentParameter.MaximumValue;
            }
        }

        /// <summary>
        /// Свойство, присваивающее минимальное
        /// значение для зависимых параметров
        /// </summary>
        public void MinValue()
        {
            foreach (var currentParameter in _parameters)
            {
                currentParameter.Value = currentParameter.MinimumValue;
            }
        }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public LampParameters()
        {
            this.BodyDiameter = new Parameter("Body Diameter",
                90, 180, 150);
            this.SocketPlatformDiameter = new Parameter(
                "Socket Platform Diameter", 70, 100, 100);
            this.TubeDiameter = new Parameter("Tube Diameter ", 
                30, 60, 60);
            this.BodyHeight = new Parameter("Body Height",
                50, 100,100);
            this.SocketPlatformHeight = new Parameter(
                "SocketPlatform Height", 2,6, 4);
            this.TubeHeight = new Parameter("Tube Height",
                150, 200, 200);
            _parameters = new List<Parameter>
            {
                BodyDiameter,
                BodyHeight,
                TubeDiameter,
                TubeHeight,
                SocketPlatformDiameter,
                SocketPlatformHeight
            };
        }
    }
}