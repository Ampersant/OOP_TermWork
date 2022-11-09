using BLL;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    internal class EstateTest
    {
        private Estate obj;
        [SetUp]
        public void Setup()
        {
            //ARRANGE
            obj = new Estate("1-room flat", 12345, 1900.22, 22.5);
        }
        [Test]
        public void Test_Construct()
        {
            // ARRANGE
            string type = "1-room flat";
            int id = 12345;
            double cost = 1900.22;
            double sq = 21.5;

            //ACT
            Estate testObj;
            testObj = new Estate(type, id, cost, sq);
            //ASSERT
            Assert.AreNotEqual(obj, testObj);
        }
        [Test]
        public void Test_ChangeType()
        {
            // ARRANGE
            string type = "2-room flat";
            //ACT
            obj.Type = type;
            //ASSERT
            Assert.AreEqual(type, obj.Type);
        }
        [Test]
        public void Test_ChangeCost()
        {
            // ARRANGE
            double cost = 199.99;
            //ACT
            obj.Cost = cost;
            //ASSERT
            Assert.AreEqual(cost, obj.Cost);
        }
        [Test]
        public void Test_ChangeSq()
        {
            // ARRANGE
            double sq = 189.99;
            //ACT
            obj.Square = sq;
            //ASSERT
            Assert.AreEqual(sq, obj.Square);
        }
        [Test]
        public void Test_ChangeId()
        {
            // ARRANGE
            int id = 12344;
            //ACT
            obj.Id = id;
            //ASSERT
            Assert.AreEqual(id, obj.Id);
        }
        [Test]
        public void Test_ChangeAvail()
        {
            // ARRANGE
            int av = 0;
            //ACT
            obj.Availibility = av;
            //ASSERT
            Assert.AreEqual(av, obj.Availibility);
        }
        [Test]
        public void Test_Getdata()
        {
            // ARRANGE
            string s;
            //ACT
            s = $"Estate {obj.Id}: \n\tType = {obj.Type} \n\tPrice = {obj.Cost} \n\tSquare = {obj.Square} \n\tAvailible (1-yes, 0-no) = {obj.Availibility}";
            //ASSERT
            Assert.AreEqual(s, obj.GetData());
        }

    }
}
