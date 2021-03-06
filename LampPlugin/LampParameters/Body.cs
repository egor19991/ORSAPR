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

        //нужно спросить можно ли так
        private const int maxHeight = 100;
        private const int minHeight = 50;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public int Height
        {
            get { return _heightBody;}
            set
            {
                
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

        //нужно спросить можно ли так
        private const int maxDiametr = 180;
        private const int minDiametr = 90;

        /// <summary>
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public int Diametr
        {
            get { return _diametrBody; }
            set
            {
                
                if  (value >= minDiametr   && value <= maxDiametr  )
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

        
        public Body() { }

        public void AvgValue()
        {
            _diametrBody = (minDiametr + maxDiametr) / 2;
            _heightBody = (minHeight + maxHeight) / 2;
        }

        public void MaxValue()
        {
            _diametrBody =  maxDiametr;
            _heightBody =  maxHeight;
        }

        public void MinValue()
        {
            _diametrBody = minDiametr;
            _heightBody = minHeight;
        }

    }
}
