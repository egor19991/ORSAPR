using System;
using System.Collections.Generic;
using NUnit.Framework;
using ModelParameters;

namespace UnitTestLampParameters
{
    [TestFixture]
    class LampParametersTests
    {
        //private List<Parameter> _parameters = new List<Parameter>();
        //private LampParameters _lamp = new LampParameters();

        [TestCase(TestName = "Позитивный метод для BodyDiameter, производится ввод и " +
                             "считывание параметров")]
        [Test]
        public void BodyDiameter_GoodBodyDiameter_ReturnsSameBodyDiameter()
        {
            // Setup
            var lamp = new LampParameters { };

            var sourceParameter = new Parameter 
                { NameParameter = "Body Diameter", MaximumValue = 180, MinimumValue = 90,
                    DefaultValue = 150, Value = 100 };
            var expectedParameter = sourceParameter;

            // Act
            lamp.BodyDiameter = sourceParameter;
            var actualParameter = lamp.BodyDiameter;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для SocketPlatformDiameter, производится " +
                             "ввод и считывание параметров")]
        [Test]
        public void SocketPlatformDiameter_GoodSocketPlatformDiameter_ReturnsSameSocketPlatformDiameter()
        {
            // Setup
            var lamp = new LampParameters { };

            var sourceParameter = new Parameter 
                { NameParameter = "Socket Platform Diameter", MaximumValue = 100, MinimumValue = 70,
                    DefaultValue = 100, Value = 80 };
            var expectedParameter = sourceParameter;

            // Act
            lamp.SocketPlatformDiameter = sourceParameter;
            var actualParameter = lamp.SocketPlatformDiameter;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для TubeDiameter, производится ввод и считывание " +
                             "параметров")]
        [Test]
        public void TubeDiameter_GoodTubeDiameter_ReturnsSameTubeDiameter()
        {
            // Setup
            var lamp = new LampParameters { };

            var sourceParameter = new Parameter
                {NameParameter = "Tube Diameter", MaximumValue = 60, MinimumValue = 30, 
                    DefaultValue = 60, Value = 45};
            var expectedParameter = sourceParameter;

            // Act
            lamp.TubeDiameter = sourceParameter;
            var actualParameter = lamp.TubeDiameter;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для BodyHeight, производится ввод и считывание " +
                             "параметров")]
        [Test]
        public void BodyHeight_GoodBodyHeight_ReturnsSameBodyHeight()
        {
            // Setup
            var lamp = new LampParameters { };

            var sourceParameter = new Parameter 
                { NameParameter = "Body Height", MaximumValue = 100, MinimumValue = 50, 
                    DefaultValue = 100, Value = 56 };
            var expectedParameter = sourceParameter;

            // Act
            lamp.BodyHeight = sourceParameter;
            var actualParameter = lamp.BodyHeight;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для SocketPlatformHeight, производится ввод и " +
                             "считывание параметров")]
        [Test]
        public void SocketPlatformHeight_GoodSocketPlatformHeight_ReturnsSameSocketPlatformHeight()
        {
            // Setup
            var lamp = new LampParameters { };

            var sourceParameter = new Parameter
                { NameParameter = "SocketPlatform Height", MaximumValue = 6, MinimumValue = 2, 
                    DefaultValue = 4, Value = 3.5 };
            var expectedParameter = sourceParameter;

            // Act
            lamp.SocketPlatformHeight = sourceParameter;
            var actualParameter = lamp.SocketPlatformHeight;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для TubeHeight, производится ввод и считывание" +
                             " параметров")]
        [Test]
        public void TubeHeight_GoodTubeHeightReturnsSameTubeHeight()
        {
            // Setup
            var lamp = new LampParameters{ };

            var sourceParameter = new Parameter
                { NameParameter = "Tube Height", MaximumValue = 6, MinimumValue = 2,
                    DefaultValue = 4, Value = 3.5 };
            var expectedParameter = sourceParameter;

            // Act
            lamp.TubeHeight = sourceParameter;
            var actualParameter = lamp.TubeHeight;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedParameter, actualParameter);
        }

        [TestCase(TestName = "Позитивный метод для MinValue, производится ввод и " +
                             "считывание параметров")]
        [Test]
        public void MinValue_GoodLampParameters_MinimumValueEqualValue()
        {
            // Setup
            var lamp = new LampParameters();
            var expectedBodyDiameterMinValue = lamp.BodyDiameter.MinimumValue;
            var expectedSocketPlatformDiameterMinValue = lamp.SocketPlatformDiameter.MinimumValue;
            var expectedTubeDiameterMinValue = lamp.TubeDiameter.MinimumValue;
            var expectedBodyHeightMinValue = lamp.BodyHeight.MinimumValue;
            var expectedSocketPlatformHeightMinValue = lamp.SocketPlatformHeight.MinimumValue;
            var expectedTubeHeightMinValue = lamp.TubeHeight.MinimumValue;

            // Act
            lamp.MinValue();
            var actualBodyDiameterValue = lamp.BodyDiameter.Value;
            var actualSocketPlatformDiameterValue = lamp.SocketPlatformDiameter.Value;
            var actualTubeDiameterValue = lamp.TubeDiameter.Value;
            var actualBodyHeightValue = lamp.BodyHeight.Value;
            var actualSocketPlatformHeightValue = lamp.SocketPlatformHeight.Value;
            var actualTubeHeightValue = lamp.TubeHeight.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedBodyDiameterMinValue, actualBodyDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformDiameterMinValue, 
                actualSocketPlatformDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeDiameterMinValue, actualTubeDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedBodyHeightMinValue, actualBodyHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformHeightMinValue, 
                actualSocketPlatformHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeHeightMinValue, actualTubeHeightValue);
        }

        [TestCase(TestName = "Позитивный метод для MaxValue, производится ввод и считывание п" +
                             "араметров")]
        [Test]
        public void MaxValue_GoodLampParameters_MaximumValueEqualValue()
        {
            // Setup
            var lamp = new LampParameters();

            // Act
            var expectedBodyDiameterMaxValue = lamp.BodyDiameter.MaximumValue;
            var expectedSocketPlatformDiameterMaxValue = lamp.SocketPlatformDiameter.
                MaximumValue;
            var expectedTubeDiameterMaxValue = lamp.TubeDiameter.MaximumValue;
            var expectedBodyHeightMaxValue = lamp.BodyHeight.MaximumValue;
            var expectedSocketPlatformHeightMaxValue = lamp.SocketPlatformHeight.MaximumValue;
            var expectedTubeHeightMaxValue = lamp.TubeHeight.MaximumValue;
            lamp.MaxValue();
            var actualBodyDiameterValue = lamp.BodyDiameter.Value;
            var actualSocketPlatformDiameterValue = lamp.SocketPlatformDiameter.Value;
            var actualTubeDiameterValue = lamp.TubeDiameter.Value;
            var actualBodyHeightValue = lamp.BodyHeight.Value;
            var actualSocketPlatformHeightValue = lamp.SocketPlatformHeight.Value;
            var actualTubeHeightValue = lamp.TubeHeight.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedBodyDiameterMaxValue, actualBodyDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformDiameterMaxValue,
                actualSocketPlatformDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeDiameterMaxValue, actualTubeDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedBodyHeightMaxValue, actualBodyHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformHeightMaxValue, 
                actualSocketPlatformHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeHeightMaxValue, actualTubeHeightValue);
        }

        [TestCase(TestName = "Позитивный метод для DefaultValue, производится ввод и " +
                             "считывание параметров")]
        [Test]
        public void DefaultValue_GoodLampParameters_DefaultValueEqualValue()
        {
            // Setup
            var lamp = new LampParameters();
            var expectedBodyDiameterDefaultValue = lamp.BodyDiameter.DefaultValue;
            var expectedSocketPlatformDiameterDefaultValue = lamp.SocketPlatformDiameter.
                DefaultValue;
            var expectedTubeDiameterDefaultValue = lamp.TubeDiameter.DefaultValue;
            var expectedBodyHeightDefaultValue = lamp.BodyHeight.DefaultValue;
            var expectedSocketPlatformHeightDefaultValue = lamp.SocketPlatformHeight.
                DefaultValue;
            var expectedTubeHeightDefaultValue = lamp.TubeHeight.DefaultValue;

            // Act
            lamp.DefaultValue();
            var actualBodyDiameterValue = lamp.BodyDiameter.Value;
            var actualSocketPlatformDiameterValue = lamp.SocketPlatformDiameter.Value;
            var actualTubeDiameterValue = lamp.TubeDiameter.Value;
            var actualBodyHeightValue = lamp.BodyHeight.Value;
            var actualSocketPlatformHeightValue = lamp.SocketPlatformHeight.Value;
            var actualTubeHeightValue = lamp.TubeHeight.Value;

            // Assert
            NUnit.Framework.Assert.AreEqual(expectedBodyDiameterDefaultValue, actualBodyDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformDiameterDefaultValue, 
                actualSocketPlatformDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeDiameterDefaultValue, actualTubeDiameterValue);
            NUnit.Framework.Assert.AreEqual(expectedBodyHeightDefaultValue, actualBodyHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedSocketPlatformHeightDefaultValue, 
                actualSocketPlatformHeightValue);
            NUnit.Framework.Assert.AreEqual(expectedTubeHeightDefaultValue, actualTubeHeightValue);
        }

        [TestCase(TestName = "Позитивный метод для DepthHole, производится сложение 3 " +
                             "параметров и считывание")]
        [Test]
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
        [Test]
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
