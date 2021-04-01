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
        private Parameter _diameterBody;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private Parameter _heightTube;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private Parameter _diameterTube;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private Parameter _heightSocketPlatform;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private Parameter _diameterSocketPlatform;

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
        public Parameter BodyDiameter
        {
            get => _diameterBody;
            set
            {
                _diameterBody = value;
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
        public Parameter TubeDiameter
        {
            get => _diameterTube;
            set
            {
                _diameterTube = value;
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
        public Parameter SocketPlatformDiameter
        {
            get => _diameterSocketPlatform;
            set
            {
                _diameterSocketPlatform = value;
            }
        }

        /// <summary>
        /// Свойство, возращающее диаметр отверстия на площадке под патрон для саморезов
        /// </summary>
        public const double DiameterHole = 3;

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
        /// Свойство, возращающее глубина отверстия в корусе, ножке, платформе
        /// </summary>
        public double DepthHole
        {
            get
            {
                if (_heightBody.Value > 0 && _heightTube.Value > 0 && _heightSocketPlatform.Value >0 )
                {
                    return _heightBody.Value + _heightTube.Value + _heightSocketPlatform.Value;
                }
                else
                {
                    throw new ArgumentException("Not set BodyHeight or TubeHeight or SocketPlatformHeight");
                }
            }
        }

        /// <summary>
        /// Свойство, задающее среднее значение для зависимых параметров
        /// </summary>
        public void DefaultValue()
        {
            _diameterBody.Value = _diameterBody.DefaultValue;
            _heightBody.Value = _heightBody.DefaultValue;
            _diameterSocketPlatform.Value = _diameterSocketPlatform.DefaultValue;
            _heightSocketPlatform.Value = _heightSocketPlatform.DefaultValue;
            _diameterTube.Value = _diameterTube.DefaultValue;
            _heightTube.Value = _heightTube.DefaultValue;
        }

        /// <summary>
        /// Свойство, задающее максимальное значение для зависимых параметров
        /// </summary>
        public void MaxValue()
        {
            _diameterBody.Value = _diameterBody.MaximumValue;
            _heightBody.Value = _heightBody.MaximumValue;
            _diameterSocketPlatform.Value = _diameterSocketPlatform.MaximumValue;
            _heightSocketPlatform.Value = _heightSocketPlatform.MaximumValue;
            _diameterTube.Value = _diameterTube.MaximumValue;
            _heightTube.Value = _heightTube.MaximumValue;
        }

        /// <summary>
        /// Свойство, задающее минимальное значение для зависимых параметров
        /// </summary>
        public void MinValue()
        {
            _diameterBody.Value = _diameterBody.MinimumValue;
            _heightBody.Value = _heightBody.MinimumValue;
            _diameterSocketPlatform.Value = _diameterSocketPlatform.MinimumValue;
            _heightSocketPlatform.Value = _heightSocketPlatform.MinimumValue;
            _diameterTube.Value = _diameterTube.MinimumValue;
            _heightTube.Value = _heightTube.MinimumValue;
        }

        public LampParameters()
        {
            this._diameterBody = new Parameter("Body Diameter",90, 180, 150);
            this._diameterSocketPlatform = new Parameter("Socket Platform Diameter", 70, 100, 100);
            this._diameterTube = new Parameter("Tube Diameter ", 30, 60, 60);
            this._heightBody = new Parameter("Body Height",50, 100,100);
            this._heightSocketPlatform = new Parameter("SocketPlatform Height", 2,6, 4);
            this._heightTube = new Parameter("Tube Height", 150, 200, 200);
        }
    }
}