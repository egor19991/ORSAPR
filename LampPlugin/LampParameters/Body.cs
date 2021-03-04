using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    /// <summary>
    /// Класс содержит данные об корпусе
    /// </summary>
    public class Body
    {
        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private int _heightBody;

        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private int _diametrBody;

        /// <summary>
        /// Высота выключателя
        /// </summary>
        public const int HeightSwitch = 22;

        /// <summary>
        /// Ширина выключателя
        /// </summary>
        public const int WightSwitch = 28;

        /// <summary>
        /// Ширина провода
        /// </summary>
        public const int WightCable = 6;

        /// <summary>
        /// Высота провода
        /// </summary>
        public const int HeightCable = 4;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public int Height
        {
            get { return _heightBody;}
            set
            {
                const int maxHeight = 100;
                const int minHeight = 50;
                if (value <= maxHeight  && minHeight >= value)
                {
                    _heightBody = value;
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
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public int Diametr
        {
            get { return _diametrBody; }
            set
            {
                const int maxDiametr = 180;
                const int minDiametr = 90;
                if ( value >= minDiametr && value <= maxDiametr  )
                {
                    _diametrBody = value;
                }
                else
                {
                    throw new ArgumentException($"Parametr Body Diametr " +
                                                $"should be more then {minDiametr} " +
                                                $"and less then {maxDiametr}");
                }
            }
        }

        //public Body () { }

    }
}
