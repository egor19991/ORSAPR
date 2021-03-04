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

        /// <summary>
        /// Свойство, задающее выстоу платформы под патрон
        /// </summary>
        public int Height
        {
            get { return _heightSocketPlatform; }
            set
            {
                const int maxHeight = 6;
                const int minHeight = 2;
                if (value <= maxHeight && minHeight >= value)
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

        /// <summary>
        /// Свойство, задающее диамеир платформы под патрон
        /// </summary>
        public int Diametr
        {
            get { return _diametrSocketPlatform; }
            set
            {
                const int maxDiametr = 100;
                const int minDiametr = 70;
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
    }
}
