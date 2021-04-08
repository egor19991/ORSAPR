using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ModelParameters;

namespace UnitTestLampParameters
{
     //TODO: RSDN
    [TestFixture]
    class LampParametersTests
    {
        /// <summary>
        /// Словарь для хранения сведения о параметров лампы
        /// </summary>
        private Dictionary<string, Parameter> TestingParameter
        {
            get
            {
                var lamp = new LampParameters {};
                return new Dictionary<string, Parameter>
                {
                    {nameof(lamp.BodyDiameter), lamp.BodyDiameter},
                    {nameof(lamp.BodyHeight), lamp.BodyHeight},
                    {nameof(lamp.SocketPlatformDiameter), lamp.SocketPlatformDiameter},
                    {nameof(lamp.SocketPlatformHeight), lamp.SocketPlatformHeight},
                    {nameof(lamp.TubeDiameter), lamp.TubeDiameter},
                    {nameof(lamp.TubeHeight), lamp.TubeHeight},
                };
            }
        }

        /// <summary>
        /// Лист с назаванием параметров
        /// </summary>
        /// <param name="lamp">Экземпляр класса LampParameters</param>
        /// <returns></returns>
        private List<Parameter> InitializeParameters(LampParameters lamp)
        {
            var parameters = new List<Parameter>
            {
                lamp.BodyDiameter,
                lamp.BodyHeight,
                lamp.TubeDiameter,
                lamp.TubeHeight,
                lamp.SocketPlatformDiameter,
                lamp.SocketPlatformHeight
            };
            return parameters;
        }

        [TestCase("BodyDiameter", TestName = "Позитивный метод для BodyDiameter, производится ввод и " +
                                             "считывание параметров")]
        [TestCase("BodyHeight",TestName = "Позитивный метод для BodyHeight, производится ввод и " +
                                          "считывание параметров")]
        [TestCase("SocketPlatformDiameter", TestName = "Позитивный метод для SocketPlatformDiameter," +
                                                       " производится ввод и считывание параметров")]
        [TestCase("SocketPlatformHeight", TestName = "Позитивный метод для SocketPlatformHeight, " +
                                                     "производится ввод и считывание параметров")]
        [TestCase("TubeDiameter", TestName = "Позитивный метод для TubeDiameter, производится ввод и" +
                                             " считывание параметров")]
        [TestCase("TubeHeight", TestName = "Позитивный метод для TubeHeight, производится ввод и" +
                                           " считывание параметров")]
        public void Test_GoodParameter_ReternSameParameter(string nameParameter)
        {
            // Setup
            Parameter myParameter;
            if (TestingParameter.TryGetValue(nameParameter, out myParameter))
            {
                Parameter sourceParameter = new Parameter(
                    "Testing Parameter",
                    20, 
                    150,
                    80 );
                var expectedParameter = sourceParameter;

                // Act
                myParameter = sourceParameter;
                var actualParameter = myParameter;

                //Assert
                NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
            }
            else
            {
                throw new ArgumentException("Name parameter not found");
            }
        }

        [TestCase(TestName = "Позитивный метод для MinValue, производится ввод и " +
                             "считывание параметров")]
        public void MinValue_GoodLampParameters_MinimumValueEqualValue()
        {
            var lamp = new LampParameters();
            var parameters = InitializeParameters(lamp);
            lamp.MinValue();
            foreach (var currentParameter in parameters)
            {
                // Setup
                var expectedValue = currentParameter.MinimumValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestCase(TestName = "Позитивный метод для MaxValue, производится ввод и считывание п" +
                             "араметров")]
        public void MaxValue_GoodLampParameters_MaximumValueEqualValue()
        {
            // Setup
            var lamp = new LampParameters();
            var parameters = InitializeParameters(lamp);
            lamp.MaxValue();
            foreach (var currentParameter in parameters)
            {

                var expectedValue = currentParameter.MaximumValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, производится ввод и " +
                             "считывание параметров")]
        public void DefaultValue_GoodLampParameters_DefaultValueEqualValue()
        {
            // Setup
            var lamp = new LampParameters();
            var parameters = InitializeParameters(lamp);
            lamp.DefaultValue();
            foreach (var currentParameter in parameters)
            {

                var expectedValue = currentParameter.DefaultValue;

                // Act
                var actualValue = currentParameter.Value;

                // Assert
                NUnit.Framework.Assert.AreEqual(expectedValue, actualValue);
            }
        }

        [TestCase(TestName = "Позитивный метод для DepthHole, производится сложение 3 " +
                             "параметров и считывание")]
        public void DepthHole_GoodLampParameters_ReturnSameDepthHole()
        {
            // Setup
            var lamp = new LampParameters();
            lamp.BodyHeight.Value = 75;
            lamp.TubeHeight.Value = 150;
            lamp.SocketPlatformHeight.Value = 3.5;
            var expectedDepthHole = lamp.BodyHeight.Value + lamp.TubeHeight.Value +
                                    lamp.SocketPlatformHeight.Value;

            // Act
            var actualDepthHole = lamp.DepthHole;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedDepthHole, actualDepthHole);

        }

        [TestCase(TestName = "Негативный метод для DepthHole, производится вызов метода при пустых " +
                             "исходных параметрах")]
        public void DepthHole_NotSetBodyHeightTubeHeightSocketPlatformHeight_ThrowsException()
        {
            // Setup
            var lamp = new LampParameters();

            // Assert
            NUnit.Framework.Assert.Throws<ArgumentException>
            (() =>
                {
                    // Act
                    var actualDepthHole = lamp.DepthHole;
                }
            );
        }
    }
}
