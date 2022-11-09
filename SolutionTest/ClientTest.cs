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
    internal class ClientTest
    {
        private Client obj;
        [SetUp]
        public void Setup()
        {
            //ARRANGE
            obj = new Client("Adam", "Green", "AD12345678", 12345, "2-room flat");
        }
        [Test]
        public void Test_Construct()
        {
            // ARRANGE
            string name = "Adam";
            string surname = "Gave";
            string bankID = "AD12345677";
            int id = 12344;
            string prefer = "1-room flat";

            //ACT
            Client testObj;
            testObj = new Client(name, surname, bankID, id, prefer);
            //ASSERT
            Assert.AreNotEqual(obj, testObj);
        }
        [Test]
        public void Test_ChangName()
        {
            // ARRANGE
            string name = "Colins";
            //ACT
            obj.Name = name;
            //ASSERT
            Assert.AreEqual(name, obj.Name);
        }
        [Test]
        public void Test_ChangeSurName()
        {
            // ARRANGE
            string surname = "Garl";
            //ACT
            obj.Surname = surname;
            //ASSERT
            Assert.AreEqual(surname, obj.Surname);
        }
        [Test]
        public void Test_ChangeBankID()
        {
            // ARRANGE
            string bankID = "KC22333456"; 
            //ACT
            obj.BankID = bankID;
            //ASSERT
            Assert.AreEqual(bankID, obj.BankID);
        }
        [Test]
        public void Test_ChangeUserID()
        {
            // ARRANGE
            int id = 12344;
            //ACT
            obj.UserID = id;
            //ASSERT
            Assert.AreEqual(id, obj.UserID);
        }
        [Test]
        public void Test_ChangePrefer()
        {
            // ARRANGE
            string type = "Mansion";
            //ACT
            obj.PreferType = type;
            //ASSERT
            Assert.AreEqual(type, obj.PreferType);
        }
        [Test]
        public void Test_ChangeLikes()
        {
            // ARRANGE
            int like = 1;
            //ACT
            obj.LikeEstates = like;
            //ASSERT
            Assert.AreEqual(like, obj.LikeEstates);
        }
        [Test]
        public void Test_Getdata()
        {
            // ARRANGE
            string s;
            //ACT
            s = $"Client: \n\tName = {obj.Name} \n\tSurname = {obj.Surname} \n\tBank ID = {obj.BankID}  \n\tUser ID = {obj.UserID}, \n\tPreference = {obj.PreferType}";
            //ASSERT
            Assert.AreEqual(s, obj.GetData());
        }
    }
}
