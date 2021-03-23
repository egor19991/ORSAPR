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
        private const double _heightSwitch = 22;

        /// <summary>
        /// Ширина выключателя
        /// </summary>
        private const double _wightSwitch = 28;

        /// <summary>
        /// Ширина провода
        /// </summary>
        private const double _wightCable = 6;

        /// <summary>
        /// Высота провода
        /// </summary>
        private const double _heightCable = 4;

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
        private const double _distanceHole = 57;

        /// <summary>
        /// Диаметр отверстия на площадке под патрон для саморезов
        /// </summary>
        private const double _diametrHole = 3;

        /// <summary>
        /// Максимальная высота корпуса лампы
        /// </summary>
        private const double _maxBodyHeight = 100;

        /// <summary>
        /// Минимальная высота корпуса лампы
        /// </summary>
        private const double _minBodyHeight = 50;

        /// <summary>
        /// Максимальный диаметр корпуса лампы
        /// </summary>
        private const double _maxBodyDiametr = 180;

        /// <summary>
        /// Минимальный диаметр корпуса лампы
        /// </summary>
        private const double _minBodyDiametr = 90;

        /// <summary>
        /// Максимальная высота стойки
        /// </summary>
        private const double _maxTubeHeight = 200;

        /// <summary>
        /// Минимальная высота стойки
        /// </summary>
        private const double _minTubeHeight = 150;

        /// <summary>
        /// Максимальный диаметр стойки
        /// </summary>
        private const double _maxTubeDiametr = 60;

        /// <summary>
        /// Минимальный диаметр стойки
        /// </summary>
        private const double _minTubeDiametr = 30;

        /// <summary>
        /// Максимальная высота платформы 
        /// </summary>
        private const double _maxSocketPlatformHeight = 6;

        /// <summary>
        /// Минимальная высота платформы 
        /// </summary>
        private const double _minSocketPlatformHeight = 2;

        /// <summary>
        /// Максимальная диаметр платформы 
        /// </summary>
        private const double _maxSocketPlatformDiametr = 100;

        /// <summary>
        /// Минимальная диаметр платформы 
        /// </summary>
        private const double _minSocketPlatformDiametr = 70;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public double BodyHeight
        {
            get { return _heightBody; }
            set
            {
                if (value <= _maxBodyHeight && value >= _minBodyHeight)
                {
                    _heightBody = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Height" +
                                                $"should be more then {_minBodyHeight}" +
                                                $"and less then {_maxBodyHeight}");
                }
            }
        }

        /// <summary>
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public double BodyDiametr
        {
            get { return _diametrBody; }
            set
            {

                if (value >= _minBodyDiametr && value <= _maxBodyDiametr)
                {
                    _diametrBody = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {_minBodyDiametr} " +
                                                $"and less then {_maxBodyDiametr}");
                }
            }
        }
        
        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public double TubeHeight
        {
            get { return _heightTube; }
            set
            {
                if (value <= _maxTubeHeight && value >= _minTubeHeight)
                {
                    _heightTube = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Tube Height" +
                                                $"should be more then {_minTubeHeight}" +
                                                $"and less then {_maxTubeHeight}");
                }
            }
        }

        /// <summary>
        /// Свойство, задающее диамеир стойки
        /// </summary>
        public double TubeDiametr
        {
            get { return _diametrTube; }
            set
            {
                if (value >= _minTubeDiametr && value <= _maxTubeDiametr)
                {
                    _diametrTube = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Tube Diametr " +
                                                $"should be more then {_minTubeDiametr} " +
                                                $"and less then {_maxTubeDiametr}");
                }
            }
        }

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public double SocketPlatformHeight
        {
            get { return _heightSocketPlatform; }
            set
            {
                if (value <= _maxSocketPlatformHeight && value >= _minSocketPlatformHeight)
                {
                    _heightSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Height" +
                                                $"should be more then {_minSocketPlatformHeight}" +
                                                $"and less then {_maxSocketPlatformHeight}");
                }
            }
        }
        
        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public double SocketPlatformDiametr
        {
            get { return _diametrSocketPlatform; }
            set
            {
                if (value >= _minSocketPlatformDiametr && value <= _maxSocketPlatformDiametr)
                {
                    _diametrSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {_minSocketPlatformDiametr} " +
                                                $"and less then {_maxSocketPlatformDiametr}");
                }
            }
        }

        /// <summary>
        /// Свойство, возращающее диаметр отверстия на площадке под патрон для саморезов
        /// </summary>
        public double DiametrHole
        {
            get { return _diametrHole; }
        }

        /// <summary>
        /// Свойство, возращающее расстояние между отверстиями на площадке под патрон для саморезов
        /// </summary>
        public double DistanceHole
        {
            get { return _distanceHole; }
        }

        /// <summary>
        /// Свойство, возращающее высоту кабеля провода
        /// </summary>
        public double HeightCable
        {
            get { return _heightCable; }
        }

        /// <summary>
        /// Свойство, возращающее ширину кабеля провода
        /// </summary>
        public double WightCable
        {
            get { return _wightCable; }
        }

        /// <summary>
        /// Свойство, возращающее ширину кнопки
        /// </summary>
        public double WightSwitch
        {
            get { return _wightSwitch; }
        }

        /// <summary>
        /// Свойство, возращающее высоту кнопки
        /// </summary>
        public double HeightSwitch
        {
            get { return _heightSwitch; }
        }

        /// <summary>
        /// Свойство, возращающее длину отверстия в корусе, ножке, платформе
        /// </summary>
        public double HightHole
        {
            get
            {
                if (_heightBody > 0 && _heightTube > 0 && _heightSocketPlatform >0 )
                {
                    return _heightBody + _heightTube + _heightSocketPlatform;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// Свойство, задающее среднее значение для зависимых параметров
        /// </summary>
        public void AvgValue()
        {
            _diametrBody = (_minBodyDiametr + _maxBodyDiametr) / 2;
            _heightBody = (_minBodyHeight + _maxBodyHeight) / 2;
            _diametrSocketPlatform = (_minSocketPlatformDiametr + _maxSocketPlatformDiametr) / 2;
            _heightSocketPlatform = (_minSocketPlatformHeight + _maxSocketPlatformHeight) / 2;
            _diametrTube = (_minTubeDiametr + _maxTubeDiametr) / 2;
            _heightTube = (_minTubeHeight + _maxTubeHeight) / 2;
        }

        /// <summary>
        /// Свойство, задающее максимальное значение для зависимых параметров
        /// </summary>
        public void MaxValue()
        {
            _diametrBody = _maxBodyDiametr;
            _heightBody = _maxBodyHeight;
            _diametrSocketPlatform = _maxSocketPlatformDiametr;
            _heightSocketPlatform = _maxSocketPlatformHeight;
            _diametrTube = _maxTubeDiametr;
            _heightTube = _maxTubeHeight;
        }

        /// <summary>
        /// Свойство, задающее минимальное значение для зависимых параметров
        /// </summary>
        public void MinValue()
        {
            _diametrBody = _minBodyDiametr;
            _heightBody = _minBodyHeight;
            _diametrSocketPlatform = _minSocketPlatformDiametr;
            _heightSocketPlatform = _minSocketPlatformHeight;
            _diametrTube = _minTubeDiametr;
            _heightTube = _minTubeHeight;
        }
    }
}