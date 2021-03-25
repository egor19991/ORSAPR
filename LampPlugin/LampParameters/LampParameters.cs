using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// Класс содержит данные лампы
    /// </summary>
    public class LampParameters
    {
        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private Parameter _heightBody;

        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private Parameter _diametrBody;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private Parameter _heightTube;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private Parameter _diametrTube;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private Parameter _heightSocketPlatform;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private Parameter _diametrSocketPlatform;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public Parameter BodyHeight
        {
            get => _heightBody;
            set
            {
                _heightBody = value;
            }
        }

        /// <summary>
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public Parameter BodyDiametr
        {
            get => _diametrBody;
            set
            {
                _diametrBody = value;
            }
        }
        
        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public Parameter TubeHeight
        {
            get => _heightTube;
            set
            {
                _heightTube = value;
            }
        }

        /// <summary>
        /// Свойство, задающее диамеир стойки
        /// </summary>
        public Parameter TubeDiametr
        {
            get => _diametrTube;
            set
            {
                _diametrTube = value;
            }
        }

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public Parameter SocketPlatformHeight
        {
            get => _heightSocketPlatform;
            set
            {
                _heightSocketPlatform = value;
            }
        }
        
        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public Parameter SocketPlatformDiametr
        {
            get => _diametrSocketPlatform;
            set
            {
                _diametrSocketPlatform = value;
            }
        }

        /// <summary>
        /// Свойство, возращающее диаметр отверстия на площадке под патрон для саморезов
        /// </summary>
        public const double DiametrHole = 3;

        /// <summary>
        /// Свойство, возращающее расстояние между отверстиями на площадке под патрон для саморезов
        /// </summary>
        public const double DistanceHole = 57;

        /// <summary>
        /// Свойство, возращающее высоту кабеля провода
        /// </summary>
        public const double HeightCable = 4;
        
        /// <summary>
        /// Свойство, возращающее ширину кнопки
        /// </summary>
        public const double WightSwitch = 28;

        /// <summary>
        /// Свойство, возращающее высоту кнопки
        /// </summary>
        public const double HeightSwitch = 22;

        /// <summary>
        /// Свойство, возращающее ширину кабеля провода
        /// </summary>
        public const double WightCable = 6;

        /// <summary>
        /// Свойство, возращающее длину отверстия в корусе, ножке, платформе
        /// </summary>
        public double HightHole
        {
            get
            {
                if (_heightBody.Value > 0 && _heightTube.Value > 0 && _heightSocketPlatform.Value >0 )
                {
                    return _heightBody.Value + _heightTube.Value + _heightSocketPlatform.Value;
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
            _diametrBody.Value = _diametrBody.Average();
            _heightBody.Value = _heightBody.Average();
            _diametrSocketPlatform.Value = _diametrSocketPlatform.Average();
            _heightSocketPlatform.Value = _heightSocketPlatform.Average();
            _diametrTube.Value = _diametrTube.Average();
            _heightTube.Value = _heightTube.Average();
        }

        /// <summary>
        /// Свойство, задающее максимальное значение для зависимых параметров
        /// </summary>
        public void MaxValue()
        {
            _diametrBody.Value = _diametrBody.MaximumValue;
            _heightBody.Value = _heightBody.MaximumValue;
            _diametrSocketPlatform.Value = _diametrSocketPlatform.MaximumValue;
            _heightSocketPlatform.Value = _heightSocketPlatform.MaximumValue;
            _diametrTube.Value = _diametrTube.MaximumValue;
            _heightTube.Value = _heightTube.MaximumValue;
        }

        /// <summary>
        /// Свойство, задающее минимальное значение для зависимых параметров
        /// </summary>
        public void MinValue()
        {
            _diametrBody.Value = _diametrBody.MinimumValue;
            _heightBody.Value = _heightBody.MinimumValue;
            _diametrSocketPlatform.Value = _diametrSocketPlatform.MinimumValue;
            _heightSocketPlatform.Value = _heightSocketPlatform.MinimumValue;
            _diametrTube.Value = _diametrTube.MinimumValue;
            _heightTube.Value = _heightTube.MinimumValue;
        }

        public LampParameters()
        {
            this._diametrBody = new Parameter(90, 180);
            this._diametrSocketPlatform = new Parameter(70, 100);
            this._diametrTube = new Parameter(30, 60);
            this._heightBody = new Parameter(50, 100);
            this._heightSocketPlatform = new Parameter(2, 6);
            this._heightTube = new Parameter(150, 200);
        }
    }
}