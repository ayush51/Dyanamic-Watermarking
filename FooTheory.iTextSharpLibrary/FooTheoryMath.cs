using System;

namespace FooTheory.iTextSharpLibrary
{
    /// <summary>
    /// Math library 
    /// </summary>
    public static class FooTheoryMath
    {
        public static double GetHypotenuseAngleInDegreesFrom(double opposite, double adjacent)
        {
            //http://www.regentsprep.org/Regents/Math/rtritrig/LtrigA.htm
            // Tan <angle> = opposite/adjacent
            // Math.Atan2: http://msdn.microsoft.com/en-us/library/system.math.atan2(VS.80).aspx 

            double radians = Math.Atan2(opposite, adjacent); // Get Radians for Atan2
            double angle = radians*(180/Math.PI); // Change back to degrees
            return angle;
        }
    }
}