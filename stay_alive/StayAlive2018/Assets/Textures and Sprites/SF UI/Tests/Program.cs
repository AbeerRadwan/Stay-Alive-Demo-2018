using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace nunit_test
{
    class stayAliveNameTest
    {
        static void Main(string[] args)
        {
        }
            public static bool testName(string name)
        {

            double num2;
            bool isNum2 = double.TryParse(name, out num2);
            if (isNum2 || name == "")
            {
                Console.WriteLine("please enter username");

                return false;
            }
            else
                return true;

        }
       


    }


}
