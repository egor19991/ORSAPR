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
        private double _heightBody;
        
        /// <summary>
        /// Поле, хронящее высоту корпуса
        /// </summary>
        private double _diametrBody;

        /// <summary>
        /// Высота выключателя
        /// </summary>
        public const double HeightSwitch = 22;

        /// <summary>
        /// Ширина выключателя
        /// </summary>
        public const double WightSwitch = 28;

        /// <summary>
        /// Ширина провода
        /// </summary>
        public const double WightCable = 6;

        /// <summary>
        /// Высота провода
        /// </summary>
        public const double HeightCable = 4;

        //нужно спросить можно ли так
        private const double maxHeight = 100;
        private const double minHeight = 50;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public double Height
        {
            get { return _heightBody;}
            set
            {
                if (value <= maxHeight  && value >= minHeight  )
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
        private const double maxDiametr = 180;
        private const double minDiametr = 90;

        /// <summary>
        /// Свойство, задающее диамеир корпуса
        /// </summary>
        public double Diametr
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
