using System;
using System.Collections.Generic;
using System.Text;
using FooTheory.iTextSharpLibrary;
using NUnit.Framework;

namespace FooTheory.iTextSharpTests
{
    [TestFixture]
    public class FooTheoryPdfTests
    {
        
        [Test]
        public void GetHypotenuse_Angle_Should_return_Valid_angle()
        {
            double adjacent = 8.5;
            double opposite = 11;
            double angle = FooTheoryMath.GetHypotenuseAngleInDegreesFrom(opposite, adjacent); 
            Assert.AreEqual(52.305759533310827, angle);
        }
    }
}
