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
    class VectorTests
    {
        #region AddInstance
        [Test]
        public void AddInstance_ZeroToZero_StillZero()
        {
            Vector firstZero = new Vector(0, 0, 0);
            Vector secondZero = new Vector(0, 0, 0);
            Vector expected = new Vector(0, 0, 0);

            firstZero.Add(secondZero);

            Assert.That(firstZero, Is.EqualTo(secondZero));
        }

        [Test]
        public void AddInstance_OneToZero_EqualsOne()
        {
            Vector underTest = new Vector(0, 0, 0);
            Vector addition = new Vector(1, 1, 1);
            Vector expected = new Vector(1, 1, 1);

            underTest.Add(addition);

            Assert.That(underTest, Is.EqualTo(expected));
        }

        [Test]
        public void AddInstance_100_023_Equals123()
        {
            Vector underTest = new Vector(1, 0, 0);
            Vector addition = new Vector(0, 2, 3);
            Vector expected = new Vector(1, 2, 3);

            underTest.Add(addition);

            Assert.That(underTest, Is.EqualTo(expected));
        }

        #endregion

        #region AddStatic

        [Test]
        public void AddStatic_TwoNullVectors()
        {
            Vector first = null;
            Vector second = null;
            
            Assert.Throws(typeof(NullReferenceException), () => Vector.Add(first, second));
        }

        [Test]
        public void AddStatic_ZeroToZero_ReturnsZero()
        {
            Vector firstZero = new Vector(0, 0, 0);
            Vector secondZero = new Vector(0, 0, 0);

            Vector expected = new Vector(0, 0, 0);

            Vector result = Vector.Add(firstZero, secondZero);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddStatic_ZeroToOne_ReturnsOne()
        {
            Vector zero = new Vector(0, 0, 0);
            Vector one = new Vector(1, 1, 1);

            Vector expected = new Vector(1, 1, 1);

            Vector result = Vector.Add(zero, one);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddStatic_ZeroToMinusOne_ReturnsMinusOne()
        {
            Vector zero = new Vector(0, 0, 0);
            Vector minusOne = new Vector(-1, -1, -1);

            Vector expected = new Vector(-1, -1, -1);

            Vector result = Vector.Add(zero, minusOne);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void AddStatic_OneToMinusOne_ReturnsZero()
        {
            Vector one = new Vector(1, 1, 1);
            Vector minusOne = new Vector(-1, -1, -1);

            Vector expected = new Vector(0, 0, 0);

            Vector result = Vector.Add(one, minusOne);

            Assert.That(result, Is.EqualTo(expected));
        }

        //[Test]
        ////[TestCase(new { First = new Vector(1, 2, 3), Second = new Vector(1, 2, 3), Expected = new Vector(2,4,6))]
        //public void Add_Stuff(Vector first, Vector second, Vector expected)
        //{
        //    Vector result = Vector.Add(first, second);

        //    Assert.That(result, Is.EqualTo(expected));
        //}

        #endregion

        #region Equals
        [Test]
        public void Equals_Null_ReturnsFalse()
        {
            Vector one = new Vector();
            Vector two = null;
            bool expected = false;
            
            bool result = one.Equals(two);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_Blank_ReturnsTrue()
        {
            Vector one = new Vector();
            Vector two = new Vector();
            bool expected = true;

            bool result = one.Equals(two);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_123_ReturnsTrue()
        {
            Vector one = new Vector(1, 2, 3);
            Vector two = new Vector(1, 2, 3);
            bool expected = true;

            bool result = one.Equals(two);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_123_321_ReturnsFalse()
        {
            Vector one = new Vector(1, 2, 3);
            Vector two = new Vector(3, 2, 1);
            bool expected = false;

            bool result = one.Equals(two);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Equals_Vector_Other_ReturnsFalse()
        {
            Vector one = new Vector();
            string two = string.Empty;
            bool expected = false;

            bool result = one.Equals(two);

            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion

        #region GetHashCode
        [Test]
        public void GetHashCode_000_NoErrors()
        {
            Vector test = new Vector();

            int hashCode = test.GetHashCode();
        }

        [Test]
        public void GetHashCode_000_000_Same()
        {
            Vector one = new Vector();
            Vector two = new Vector();
            bool expected = true;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCode_100_100_Same()
        {
            Vector one = new Vector();
            Vector two = new Vector();
            bool expected = true;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCode_100_010_Different()
        {
            Vector one = new Vector(1, 0, 0);
            Vector two = new Vector(0, 1, 0);
            bool expected = false;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCode_100_001_Different()
        {
            Vector one = new Vector(1, 0, 0);
            Vector two = new Vector(0, 0, 1);
            bool expected = false;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }
        
        [Test]
        public void GetHashCode_123_123_Same()
        {
            Vector one = new Vector(1, 2, 3);
            Vector two = new Vector(1, 2, 3);
            bool expected = true;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetHashCode_123_321_Different()
        {
            Vector one = new Vector(1, 2, 3);
            Vector two = new Vector(3, 2, 1);
            bool expected = false;

            bool result = one.GetHashCode() == two.GetHashCode();

            Assert.That(result, Is.EqualTo(expected));
        }
        #endregion
    }
}
