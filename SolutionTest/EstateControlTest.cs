using BLL;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    internal class EstateControlTest
    {

        [Test]
        public void Test_InputFirstName()
        {
            // ARRANGE
            string s = "Adam";
            var stringReader = new StringReader(s);
            //ACT
            Console.SetIn(stringReader);
            var line1 = Inputs.InputFirstName();
            //ASSERT
            Assert.AreEqual(s, line1);
        }
    }
}
