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

        private const int maxHeight = 200;
        private const int minHeight = 150;

        /// <summary>
        /// Свойство, задающее выстоу стойки
        /// </summary>
        public int Height
        {
            get { return _heightTube; }
            set
            {
                
                if (value <= maxHeight && value >= minHeight)
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

        private const int maxDiametr = 60;
        private const int minDiametr = 30;

        /// <summary>
        /// Свойство, задающее диамеир стойки
        /// </summary>
        public int Diametr
        {
            get { return _diametrTube; }
            set
            {
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

        public void AvgValue()
        {
            _diametrTube = (minDiametr + maxDiametr) / 2;
            _heightTube = (minHeight + maxHeight) / 2;
        }

        public void MaxValue()
        {
            _diametrTube = maxDiametr;
            _heightTube = maxHeight;
        }

        public void MinValue()
        {
            _diametrTube = minDiametr;
            _heightTube = minHeight;
        }

    }
}
