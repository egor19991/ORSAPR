using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NUnit.Framework;
using LampParameters;


namespace UnitTestLampParameters
{
    [TestFixture]
    public class ParameterTests
    {
        //TODO: добавить тестнэймы
        [Test]
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

        //TODO убрать дублирование через тесткейзы
        [Test]
        public void Value_GoodValue_ReturnsSameValue()
        {
            // Setup
            var parameter = new Parameter("Width", 10,60,50);
            var sourceValue = 50.5;
            var expectedValue = sourceValue;

            // Act
            parameter.Value = sourceValue;
            var actualValue = parameter.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Value_ValueMoreMaximumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceValue = 60.5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [Test]
        public void Value_ValueLessMinimumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceValue = 9.5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [Test]
        public void Value_EmptyMaximumAndMinimumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter{NameParameter = "width"};
            var sourceValue = 50;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [Test]
        public void Value_EmptyNameParameter_ThrowsException()
        {
            // Setup
            var parameter = new Parameter{};
            var sourceValue = 50;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.Value = sourceValue;
                }
            );
        }

        [Test]
        public void MaximumValue_GoodMaximumValue_ReturnsSameMaximumValue()
        {
            // Setup
            var parameter = new Parameter();
            var sourceMaximumValue = 50.5;
            var expectedMaximumValue = sourceMaximumValue;

            // Act
            parameter.MaximumValue = sourceMaximumValue;
            var actualMaximumValue = parameter.MaximumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMaximumValue, actualMaximumValue);
        }

        [Test]
        public void MaximumValue_GoodMaximumValueMinimumParemeterMoreZero_ReturnsSameMaximumValue()
        {
            // Setup
            var parameter = new Parameter{MinimumValue = 20};
            var sourceMaximumValue = 50.5;
            var expectedMaximumValue = sourceMaximumValue;

            // Act
            parameter.MaximumValue = sourceMaximumValue;
            var actualMaximumValue = parameter.MaximumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMaximumValue, actualMaximumValue);
        }

        [Test]
        public void MaximumValue_MaximumValueLessMinimumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter {MinimumValue = 60};
            var sourceMaximumValue = 50;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MaximumValue = sourceMaximumValue;
                }
            );
        }

        [Test]
        public void MaximumValue_MaximumValueLessZero_ThrowsException()
        {
            // Setup
            var parameter = new Parameter { };
            var sourceMaximumValue = -1;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MaximumValue = sourceMaximumValue;
                }
            );
        }

        [Test]
        public void MinimumValue_GoodMinimumValue_ReturnsSameMinimumValue()
        {
            // Setup
            var parameter = new Parameter();
            var sourceMinimumValue = 20.5;
            var expectedMinimumValue = sourceMinimumValue;

            // Act
            parameter.MinimumValue = sourceMinimumValue;
            var actualMinimumValue = parameter.MinimumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMinimumValue, actualMinimumValue);
        }

        [Test]
        public void MinimumValue_GoodMinimumValueMaximumValueMoreZero_ReturnsSameMinimumValue()
        {
            // Setup
            var parameter = new Parameter{MaximumValue = 50};
            var sourceMinimumValue = 20.5;
            var expectedMinimumValue = sourceMinimumValue;

            // Act
            parameter.MinimumValue = sourceMinimumValue;
            var actualMinimumValue = parameter.MinimumValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedMinimumValue, actualMinimumValue);
        }

        [Test]
        public void MinimumValue_MinimumValueLessMaximumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter { MaximumValue = 20 };
            var sourceMinimumValue = 50;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MinimumValue = sourceMinimumValue;
                }
            );
        }

        [Test]
        public void MinimumValue_MinimumValueLessZero_ThrowsException()
        {
            // Setup
            var parameter = new Parameter {};
            var sourceMinimumValue = -5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    parameter.MinimumValue = sourceMinimumValue;
                }
            );
        }

        [Test]
        public void DefaultValue_GoodValue_ReturnsSameValue()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceDefaultValue = 50.5;
            var expectedDefaultValue = sourceDefaultValue;

            // Act
            parameter.DefaultValue = sourceDefaultValue;
            var actualValue = parameter.DefaultValue;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDefaultValue, actualValue);
        }

        [Test]
        public void DefaultValue_DefaultValueMoreMaximumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceDefaultValue = 60.5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [Test]
        public void DefaultValue_DefaultValueLessMinimumtValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter("Width", 10, 60, 50);
            var sourceDefaultValue = 9.5;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }

        [Test]
        public void DefaultValue_EmptyMaximumAndMinimumValue_ThrowsException()
        {
            // Setup
            var parameter = new Parameter { NameParameter = "width" };
            var sourceDefaultValue = 50;

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
            {
                // Act
                parameter.DefaultValue = sourceDefaultValue;
            }
            );
        }
    }
}
