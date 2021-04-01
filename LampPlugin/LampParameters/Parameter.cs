using System;

namespace LampParameters
{
    public class Parameter
    {
        /// <summary>
        /// Поле, хранящее значение параметра
        /// </summary>
        private double _value;
 
        /// <summary>
        /// Поле, хранящее максимально допустимое значение параметра
        /// </summary>
        private double _maxValue;

        /// <summary>
        ///  Поле, хранящее Минимально допустимое значение параметра
        /// </summary>
        private double _minValue;

        /// <summary>
        ///  Поле, хранящее значение по умолчанию для параметра
        /// </summary>
        private double _defaultValue;

        /// <summary>
        ///  Поле, хранящее название параметра
        /// </summary>
        private string _nameParameter;

        /// <summary>
        /// Свойство, хранящее значения параметра
        /// </summary>
        public double Value
        {
            get => _value; 
            set
            {
                if (String.IsNullOrEmpty(_nameParameter))
                {
                    throw new ArgumentException("Parameter name not specified");
                }
                if (_maxValue > 0 && _minValue > 0)
                {
                    if (value <= _maxValue && value >= _minValue)
                    {
                        _value = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Parameter {_nameParameter} " +
                                                    $"should be more then {_maxValue} " +
                                                    $"and less then {_minValue}");
                    }
                }
                else
                {
                    throw new ArgumentException("The minimum value or maximum value of the" +
                                                " parameter is not specified");
                }
            }
        }

        /// <summary>
        /// Поле, хранящее максимальное допустимое значение параметра
        /// </summary>
        public double MaximumValue
        {
            get => _maxValue;
            set
            {
                if (_minValue > 0)
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

        /// <summary>
        /// Свойство, хранящее минимально допустимое значение параметра
        /// </summary>
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
                    if (value > 0)
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

        /// <summary>
        /// Свойство, хранящее название параметра
        /// </summary>
        public string NameParameter
        {
            get { return _nameParameter; }
            set { _nameParameter = value; }
        }

        /// <summary>
        /// Свойство, хранящее параметер по умолчанию
        /// </summary>
        public double DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (_maxValue > 0 && _minValue > 0)
                {
                    if (value <= _maxValue && value >= _minValue)
                    {
                        _defaultValue = value;
                    }
                    else
                    {
                        throw new ArgumentException($"Parameter {_nameParameter} " +
                                                    $"should be more then {_maxValue} " +
                                                    $"and less then {_minValue}");
                    }
                }
                else
                {
                    throw new ArgumentException("The minimum value or maximum value of the" +
                                                " parameter is not specified");
                }
            }
        }
        //TODO:
        public Parameter() : this("", 1, 2, 1) {}
        //TODO:
        public Parameter(string name, double min, double max, double defaultValue)
        {
            this.MinimumValue = min;
            this.MaximumValue = max;
            this.NameParameter = name;
            this.DefaultValue = defaultValue;
        }

    }
}
