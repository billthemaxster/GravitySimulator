using NUnit.Framework;
using SimulatorLogic.Logic;
using SimulatorLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Tests.Logic
{
    [TestFixture]
    class VectorLogicTests
    {
        #region Add

        [Test]
        public void Add_TwoNullVectors()
        {
            Vector first = null;
            Vector second = null;
            
            Assert.Throws(typeof(NullReferenceException), () => VectorLogic.Add(first, second));
        }

        [Test]
        public void Add_ZeroToZero_ReturnsZero()
        {
            Vector firstZero = new Vector(0, 0, 0);
            Vector secondZero = new Vector(0, 0, 0);

            Vector expected = new Vector(0, 0, 0);

            Vector result = VectorLogic.Add(firstZero, secondZero);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_ZeroToOne_ReturnsOne()
        {
            Vector zero = new Vector(0, 0, 0);
            Vector one = new Vector(1, 1, 1);

            Vector expected = new Vector(1, 1, 1);

            Vector result = VectorLogic.Add(zero, one);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_ZeroToMinusOne_ReturnsMinusOne()
        {
            Vector zero = new Vector(0, 0, 0);
            Vector minusOne = new Vector(-1, -1, -1);

            Vector expected = new Vector(-1, -1, -1);

            Vector result = VectorLogic.Add(zero, minusOne);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Add_OneToMinusOne_ReturnsZero()
        {
            Vector one = new Vector(1, 1, 1);
            Vector minusOne = new Vector(-1, -1, -1);

            Vector expected = new Vector(0, 0, 0);

            Vector result = VectorLogic.Add(one, minusOne);

            Assert.That(result, Is.EqualTo(expected));
        }

        //[Test]
        ////[TestCase(new { First = new Vector(1, 2, 3), Second = new Vector(1, 2, 3), Expected = new Vector(2,4,6))]
        //public void Add_Stuff(Vector first, Vector second, Vector expected)
        //{
        //    Vector result = VectorLogic.Add(first, second);

        //    Assert.That(result, Is.EqualTo(expected));
        //}

        #endregion
    }
}
