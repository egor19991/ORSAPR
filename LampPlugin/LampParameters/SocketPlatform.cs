using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// Класс содержит данные об платформе под патрон
    /// </summary>
    public class SocketPlatform
    {
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

        private const double maxHeight = 6;
        private const double minHeight = 2;

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public double Height
        {
            get { return _heightSocketPlatform; }
            set
            {
                if (value <= maxHeight && value >= minHeight)
                {
                    _heightSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Height" +
                                                $"should be more then {minHeight}" +
                                                $"and less then {maxHeight}");
                }
            }
        }

        private const double maxDiametr = 100;
        private const double minDiametr = 70;

        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public double Diametr
        {
            get { return _diametrSocketPlatform; }
            set
            {
                if (value >= minDiametr && value <= maxDiametr)
                {
                    _diametrSocketPlatform = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {minDiametr} " +
                                                $"and less then {maxDiametr}");
                }
            }
        }

        public void AvgValue()
        {
            _diametrSocketPlatform = (minDiametr + maxDiametr) / 2;
            _heightSocketPlatform = (minHeight + maxHeight) / 2;
        }

        public void MaxValue()
        {
            _diametrSocketPlatform = maxDiametr;
            _heightSocketPlatform = maxHeight;
        }

        public void MinValue()
        {
            _diametrSocketPlatform = minDiametr;
            _heightSocketPlatform = minHeight;
        }

    }
}
