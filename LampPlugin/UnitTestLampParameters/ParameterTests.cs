using System;
using NUnit.Framework;
using ModelParameters;


namespace UnitTestLampParameters
{
    [TestFixture]
    public class ParameterTests
    {
        [TestCase(TestName = "Позитивный тест на присваивание и считывание названия параметра")]
        public void NameParameter_GoodName_ReturnsSameName()
        {
            // Setup
            var parameter = new Parameter();
            var sourceName = "Body Diameter";
            var expectedName = sourceName;

            // Act
            parameter.NameParameter = sourceName;
            var actualName = parameter.NameParameter;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedName, actualName);
        }

        [TestCase(TestName = "Позитивный тест на присваивание и считывание значения параметра")]
        public void Value_GoodValue_ReturnsSameValue()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceValue = 50.5;
            var expectedValue = sourceValue;

            // Act
            parameter.Value = sourceValue;
            var actualValue = parameter.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(9.5, TestName = "Негативный тест на проверку минимальной границы значения параметра")]
        [TestCase(60.5, TestName = "Негативный тест на проверку максимальной границы значения параметра")]
        public void Value_BadValue_ThrowsException(double sourceValue)
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [TestCase("", TestName = "Негативный тест на присваивание значения параметра при" +
                                 "незаданом названии параметра")]
        [TestCase("width", TestName = "Негативный тест на присваивание значения параметра при" +
                                      " незаданных ограничениях")]
        public void Value_EmptyNameParameter_ThrowsException(string sourceName)
        {
            // Setup
            var parameter = new Parameter(sourceName);
            var sourceValue = 5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [TestCase( TestName = "Негативный тест на присваивание значения параметра при" +
                                      " незаданном минимальном ограничении")]
        public void Value_EmptyMaxParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Test Parameter");
            var sourceValue = 5;
            parameter.MinimumValue = 2;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [TestCase(TestName = "Негативный тест на присваивание значения параметра при" +
                             " незаданном минимальном ограничении")]
        public void Value_EmptyMinParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Test Parameter");
            var sourceValue = 5;
            parameter.MaximumValue = 10;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [TestCase(0, 50, TestName = "Позитивный тест, для присваивания " +
                                    "и получения максимально значения, когда минимальный параметер " +
                                    "не определен ")]
        [TestCase(4, 50, TestName = "Позитивный тест, для присваивания " +
                                    "и получения максимально значения, когда минимальный параметер " +
                                    "определен")]
        public void MaximumValue_GoodMaximumValue_ReturnsSameMaximumValue(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter("width");
            if (sourceMinimumValue > 0)
            {
                parameter.MinimumValue = sourceMinimumValue;
            }
            var expectedMaximumValue = sourceMaximumValue;

            // Act
            parameter.MaximumValue = sourceMaximumValue;
            var actualMaximumValue = parameter.MaximumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMaximumValue, actualMaximumValue);
        }

        [TestCase(100, 50, TestName = "Негативный тест, для максимального" +
                                      " значения, когда минимальный параметер определен и больше чем " +
                                      "максимальный параметер ")]
        [TestCase(0, -1, TestName = "Негативный тест, для максимального " +
                                    "значения, когда минимальный параметер не определен и присваивается " +
                                    "отрицательное значенние для максимального параметра")]
        public void MaximumValue_MaximumValueBad_ThrowsException(double sourceMinimumValue, 
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter("width");
            if (sourceMinimumValue > 0)
            {
                parameter.MinimumValue = sourceMinimumValue;
            }

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MaximumValue = sourceMaximumValue;
                }
            );
        }

        [TestCase(50, 0, TestName = "Позитивный тест, для присваивания и" +
                                    " получения минимального значения, когда максимальный параметер " +
                                    "не определен ")]
        [TestCase(20, 50, TestName = "Позитивный тест, для присваивания " +
                                     "и получения минимального значения, когда максимальный параметер" +
                                     " определен")]
        public void MinimumValue_GoodMinimumValue_ReturnsSameMinimumValue(double sourceMinimumValue,
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter("width");
            if (sourceMaximumValue > 0)
            {
                parameter.MaximumValue = sourceMaximumValue;
            }
            var expectedMinimumValue = sourceMinimumValue;

            // Act
            parameter.MinimumValue = sourceMinimumValue;
            var actualMinimumValue = parameter.MinimumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMinimumValue, actualMinimumValue);
        }

        [TestCase(100, 50, TestName = "Негативный тест, для минимального " +
                                      "значения, когда максимальный параметер определен и больше чем " +
                                      "минимальный параметер ")]
        [TestCase(-1, 0, TestName = "Негативный тест, для максимально" +
                                    " значения, когда максимальный параметер не определен и присваивается" +
                                    " отрицательное значенние для минимального параметра")]
        public void MinimumValue_MinimumValueBad_ThrowsException(double sourceMinimumValue, 
            double sourceMaximumValue)
        {
            // Setup
            var parameter = new Parameter("width");
            if (sourceMaximumValue > 0)
            {
                parameter.MaximumValue = sourceMaximumValue;
            }

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MinimumValue = sourceMinimumValue;
                }
            );
        }


        [TestCase(TestName = "Позитивный тест, когда значение по умолчанию, передается в метод и " +
                             "считывается")]
        public void DefaultValue_GoodValue_ReturnsSameValue()
        {
            // Setup
            var parameter = new Parameter();
            var sourceDefaultValue = 10;
            var expectedDefaultValue = sourceDefaultValue;

            // Act
            parameter.DefaultValue = sourceDefaultValue;
            var actualValue = parameter.DefaultValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDefaultValue, actualValue);
        }

        [TestCase(20,TestName = "Негативный тест, когда значение по умолчанию больше чем максимум")]
        [TestCase(0.5, TestName = "Негативный тест, когда значение по умолчанию больше чем максимум")]
        public void DefaultValue_BadDefaultValue_ThrowsException(double sourceDefaultValue)
        {
            // Setup
            var parameter = new Parameter();

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [TestCase(TestName = "Негативный тест, для значение по умолчанию, когда не задан минимальный " +
                             "и максимальный параметер")]
        public void DefaultValue_EmptyMaximumAndMinimumValue_ThrowsException()
        {
            var parameter = new Parameter("Width");
            var sourceDefaultValue = 5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [TestCase(TestName = "Негативный тест на присваивание значения  параметрапо умолчанию" +
                             " при незаданном минимальном ограничении")]
        public void DefaultValue_EmptyMaxParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Test Parameter");
            var sourceValue = 5;
            parameter.MinimumValue = 2;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.DefaultValue = sourceValue;
                }
            );
        }

        [TestCase(TestName = "Негативный тест на присваивание значения параметра по умолчанию" +
                             " при незаданном минимальном ограничении")]
        public void DefaultValue_EmptyMinParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Test Parameter");
            var sourceValue = 5;
            parameter.MaximumValue = 10;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.DefaultValue = sourceValue;
                }
            );
        }
    }
}
