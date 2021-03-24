using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampParameters
{
    public class Parameter
    {
        private double _value;
 
        private double _maxValue;

        private double _minValue;

        /// <summary>
        /// Свойство, задающее выстоу корпуса
        /// </summary>
        public double Value
        {
            get => _value; 
            set
            {
                if (_maxValue > 0 && _minValue >= 0)
                {
                    if (value <= _maxValue && value >= _minValue)
                    {
                        _value = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Parametr Body Height" +
                                                    $"should be more then {_maxValue} " +
                                                    $"and less then {_minValue}");
                    }
                }
                else
                {
                    if (_maxValue > 0)
                    {
                        throw new ArgumentException("The minimum value of the" +
                                                    " parameter is not specified");
                    }
                    else
                    {
                        throw new ArgumentException("The maximum value of the" +
                                                    " parameter is not specified");
                    }
                }
            }
        }

        public double MaximumValue
        {
            get => _maxValue;
            set
            {
                if (_minValue >= 0)
                {
                    if (value > _minValue)
                    {
                        _maxValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Maximum parameter must be more " +
                                                    $" Minimum parameter = {_minValue}");
                    }
                }
                else
                {
                    if (value > 0)
                    {
                        _maxValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Maximum parameter must be more 0");
                    }
                }
            }
        }

        public double MinimumValue
        {
            get => _minValue;
            set
            {
                if (_maxValue > 0)
                {
                    if (value < _maxValue)
                    {
                        _minValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Minimum parameter must be less Maximum parameter = {_maxValue}");
                    }
                }
                else
                {
                    if (value >= 0)
                    {
                        _minValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Minimum parameter must be more or less 0");
                    }

                }
            }
        }

        public double Average()
        {
            if (_maxValue > 0 && _minValue >= 0)
            {
                return (_minValue + _maxValue) / 2;
            }
            else
            {
                if (_maxValue > 0)
                {
                    throw new ArgumentException("The minimum value of the" +
                                                " parameter is not specified");
                }
                else
                {
                    throw new ArgumentException("The maximum value of the" +
                                                " parameter is not specified");
                }
            }
        }

        public Parameter() {}

        public Parameter(double min, double max)
        {
            this.MinimumValue = min;
            this.MaximumValue = max;
        }

    }
}
