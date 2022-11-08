/*using BLL;
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
    internal class AllControlTest
    {

        private Client client;
        private List<Estate> _list;
        [SetUp]
        public void Setup()
        {

            client = new Client("Adam", "Green", "AD12345678", 12345, "1-room flat");
            _list = new List<Estate>();
        }

        [Test]
        public void Test_WorkWithClient_Delete()
        {
            // ARRANGE
            string one = "";
            string two = "Deleting is successfull";
            string three = "Object with such ID doesn't exist";
            // ARRANGE
            string s = "Create successfull";
            var stringReader = new StringReader();
            //ACT
            Console.SetIn(stringReader); 
            var line1 = AllControl.WorkWithClient();
            //ASSERT
            Assert.AreEqual(s, line1);


            //ACT
            string s = "";

            //ASSERT

            Assert.Equals(s, AllControl.Clientwork.DeleteClient());




        }


    }
}
*/