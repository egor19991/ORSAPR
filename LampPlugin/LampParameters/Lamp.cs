using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// В теории класс должен содержать данные лампы и объединить все части лампы !!Прототип
    /// </summary>
    public class Lamp
    {
        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private double _heightBody;

        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private double _diametrBody;

        /// <summary>
        /// Высота выключателя
        /// </summary>
        public const double HeightSwitch = 22;

        /// <summary>
        /// Ширина выключателя
        /// </summary>
        public const double WightSwitch = 28;

        /// <summary>
        /// Ширина провода
        /// </summary>
        public const double WightCable = 6;

        /// <summary>
        /// Высота провода
        /// </summary>
        public const double HeightCable = 4;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private double _heightTube;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private double _diametrTube;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private double _heightSocketPlatform;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private double _diametrSocketPlatform;

        /// <summary>
        /// Расстояние между отверстиями
        /// </summary>
        public const double DistanceHole = 57;

        /// <summary>
        /// Диаметр отверстия
        /// </summary>
        public const double DiametrHole = 3;

        //нужно спросить можно ли так
        private const double maxBodyHeight = 100;
        private const double minBodyHeight = 50;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public double BodyHeight
        {
            get { return _heightBody; }
            set
            {
                if (value <= maxBodyHeight && value >= minBodyHeight)
                {
                    _heightBody = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Height" +
                                                $"should be more then {minBodyHeight}" +
                                                $"and less then {maxBodyHeight}");
                }
            }
        }

        //нужно спросить можно ли так
        private const double maxBodyDiametr = 180;
        private const double minBodyDiametr = 90;

        /// <summary>
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public double BodyDiametr
        {
            get { return _diametrBody; }
            set
            {

                if (value >= minBodyDiametr && value <= maxBodyDiametr)
                {
                    _diametrBody = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {minBodyDiametr} " +
                                                $"and less then {maxBodyDiametr}");
                }
            }
        }

        private const double maxTubeHeight = 200;
        private const double minTubeHeight = 150;

        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public double TubeHeight
        {
            get { return _heightTube; }
            set
            {
                if (value <= maxTubeHeight && value >= minTubeHeight)
                {
                    _heightTube = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Tube Height" +
                                                $"should be more then {minTubeHeight}" +
                                                $"and less then {maxTubeHeight}");
                }
            }
        }

        private const double maxTubeDiametr = 60;
        private const double minTubeDiametr = 30;

        /// <summary>
        /// Свойство, задающее диамеир стойки
        /// </summary>
        public double TubeDiametr
        {
            get { return _diametrTube; }
            set
            {
                if (value >= minTubeDiametr && value <= maxTubeDiametr)
                {
                    _diametrTube = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Tube Diametr " +
                                                $"should be more then {minTubeDiametr} " +
                                                $"and less then {maxTubeDiametr}");
                }
            }
        }

        private const double maxSocketPlatformHeight = 6;
        private const double minSocketPlatformHeight = 2;

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public double SocketPlatformHeight
        {
            get { return _heightSocketPlatform; }
            set
            {
                if (value <= maxSocketPlatformHeight && value >= minSocketPlatformHeight)
                {
                    _heightSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Height" +
                                                $"should be more then {minSocketPlatformHeight}" +
                                                $"and less then {maxSocketPlatformHeight}");
                }
            }
        }

        private const double maxSocketPlatformDiametr = 100;
        private const double minSocketPlatformDiametr = 70;

        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public double SocketPlatformDiametr
        {
            get { return _diametrSocketPlatform; }
            set
            {
                if (value >= minSocketPlatformDiametr && value <= maxSocketPlatformDiametr)
                {
                    _diametrSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {minSocketPlatformDiametr} " +
                                                $"and less then {maxSocketPlatformDiametr}");
                }
            }
        }

        public void AvgValue()
        {
            _diametrBody = (minBodyDiametr + maxBodyDiametr) / 2;
            _heightBody = (minBodyHeight + maxBodyHeight) / 2;
            _diametrSocketPlatform = (minSocketPlatformDiametr + maxSocketPlatformDiametr) / 2;
            _heightSocketPlatform = (minSocketPlatformHeight + maxSocketPlatformHeight) / 2;
            _diametrTube = (minTubeDiametr + maxTubeDiametr) / 2;
            _heightTube = (minTubeHeight + maxTubeHeight) / 2;
        }

        public void MaxValue()
        {
            _diametrBody = maxBodyDiametr;
            _heightBody = maxBodyHeight;
            _diametrSocketPlatform = maxSocketPlatformDiametr;
            _heightSocketPlatform = maxSocketPlatformHeight;
            _diametrTube = maxTubeDiametr;
            _heightTube = maxTubeHeight;
        }

        public void MinValue()
        {
            _diametrBody = minBodyDiametr;
            _heightBody = minBodyHeight;
            _diametrSocketPlatform = minSocketPlatformDiametr;
            _heightSocketPlatform = minSocketPlatformHeight;
            _diametrTube = minTubeDiametr;
            _heightTube = minTubeHeight;
        }
    }
}