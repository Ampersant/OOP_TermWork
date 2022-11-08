﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Schema;

namespace DAL
{
    [DataContract]
    public class Client //: IComparable
    {
        [DataMember]
        protected string name;
        [DataMember]
        protected string surname;
        [DataMember]
        protected string bankID;
        [DataMember]
        protected int userID;
        [DataMember]
        protected string preferType;
        [DataMember]
        protected int likeEstates;


        public string Name 
        { 
            get { return name; }
            set { name = value; }
        }
        public string Surname 
        {
            get { return surname; }
            set { surname = value; }
        }
        public string BankID
        {
            get { return bankID; }
            set { bankID = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string PreferType
        {
            get { return preferType; }
            set { preferType = value; }
        }
        public int LikeEstates 
        {
            get { return likeEstates; }
            set { likeEstates = value; } 
        }
        public Client(string name, string surname, string bankID, int userID, string preferType)
        {
            Name = name;
            Surname = surname;
            BankID = bankID;
            UserID = userID;
            PreferType = preferType;
            likeEstates = 0;
        }
        public string GetData()
        {
            string s = $"Client: \n\tName = {this.Name} \n\tSurname = {this.Surname} \n\tBank ID = {this.BankID}  \n\tUser ID = {this.UserID}, \n\tPreference = {this.PreferType}";
            return s;
        }
       public int sortByName(object obj)
        {
            Client temp = obj as Client;
            if (temp != null)
            {
                //Порівняння здійснюється за номером студентського квитка
                string id1 = this.Name;
                string id2 = temp.Name;
                if (id1.First() > id2.First())
                    return 1;
                if (id1.First() < id2.First())
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parametr is not a Student");
        }
        public int SortBySurname(object obj)
        {
            Client temp = obj as Client;
            if (temp != null)
            {
                //Порівняння здійснюється за номером студентського квитка
                string id1 = this.Surname;
                string id2 = temp.Surname;
                if (id1.First() > id2.First())
                    return 1;
                if (id1.First() < id2.First())
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parameter is not a Client");
        }
        public int SortByBank(object obj)
        {
            Client temp = obj as Client;
            if (temp != null)
            {
                //Порівняння здійснюється за номером студентського квитка
                char id1 = this.BankID[2];
                char id2 = temp.BankID[2];
                if (id1 > id2)
                    return 1;
                if (id1 < id2)
                    return -1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Parameter is not a Client");
        }
    }
}
