using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica2.Tests;

namespace Practica2.Tests
{
    [TestClass()]
    public class CalculadoraTests
    {
        [TestMethod()]
        public void DividirDosValoresTest()
        {
            //Arrange
            double dividendo = 10;
            double divisor = 2;
            double resultado = 5;
            //Act

            double resValido = Calculadora.DividirDosValores(dividendo, divisor);

            //Assert
            Assert.AreEqual(resultado, resValido);
        }

        [TestMethod()]
        public void DividirTest()
        {
            //Arrange
            double dividendo = 10;
            double divValido = 2;
            double divInvalido = 0;
            
            //Act
            double resValido = Calculadora.Dividir(dividendo, divValido);

            //Assert
            Assert.AreEqual(resValido, 5);
            Assert.ThrowsException<DivideByZeroException>(() =>
            {
                Calculadora.Dividir(dividendo, divInvalido);
            });
        }
    }
}