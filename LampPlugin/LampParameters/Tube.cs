using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// Класс содержит данные об стойке
    /// </summary>
    public class Tube
    {
        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private int _heightTube;

        /// <summary>
        /// Поле, хронящее высоту стойки
        /// </summary>
        private int _diametrTube;

        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public int Height
        {
            get { return _heightTube; }
            set
            {
                const int maxHeight = 200;
                const int minHeight = 150;
                if (value <= maxHeight && minHeight >= value)
                {
                    _heightTube = value;
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
        /// Свойство, задающее диамеир стойки
        /// </summary>
        public int Diametr
        {
            get { return _diametrTube; }
            set
            {
                const int maxDiametr = 60;
                const int minDiametr = 30;
                if (value >= minDiametr && value <= maxDiametr)
                {
                    _diametrTube = value;
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
