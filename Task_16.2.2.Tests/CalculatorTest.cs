using NUnit.Framework;
using Task_16._2._2;

namespace Task_16._2._2.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        Calculator calculator;
        [Test, Order(1)] // Порядок выполнения, сначала инициализация объекта
        public void InitializationTest()
        {
            calculator = new Calculator();
            Assert.IsNotNull(calculator);
        }

        [Test]
        public void SubtractionTest()
        {
            Assert.That(calculator.Subtraction(200, 100) == 100);
        }

        [Test]
        public void DivisionTest()
        {
            Assert.That(calculator.Division(6, 2) == 3);
        }
    }
}
