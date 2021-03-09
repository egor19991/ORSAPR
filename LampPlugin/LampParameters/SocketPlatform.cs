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
        private int _heightSocketPlatform;

        /// <summary>
        /// Поле, хронящее высоту платформы под патрон
        /// </summary>
        private int _diametrSocketPlatform;

        /// <summary>
        /// Расстояние между отверстиями
        /// </summary>
        public const int DistanceHole = 57;

        /// <summary>
        /// Диаметр отверстия
        /// </summary>
        public const int DiametrHole = 3;

        private const int maxHeight = 6;
        private const int minHeight = 2;

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public int Height
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

        private const int maxDiametr = 100;
        private const int minDiametr = 70;

        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public int Diametr
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
