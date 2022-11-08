using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClientsControl
    {
        protected static DataBaseContext datb = new DataBaseContext();
        protected List<Client> ClientList { get; set; }
        public void SaveChanges()
        {
            datb.ClientWriter(ClientList);
            ClientList = datb.ClientReader();
        }
        public void CreateClient()
        {
            ClientList = datb.ClientReader();
            string FName = Inputs.InputFirstName();
            string LName = Inputs.InputLastName();
            string BankID = Inputs.InputBankID();
            int UserID = Inputs.InputUserID();
            if (ClientList != null)
            {
                while (ClientList.Any(item => item.UserID == UserID))
                {
                    UserID = Inputs.InputUserID(Exception.ErrorAlreadyExist());
                }
            }
            string Prefer = Inputs.InputEstateType();
            Client client = new Client(FName, LName, BankID, UserID, Prefer);  
            if (ClientList == null)
            {
                ClientList = new List<Client>();
                ClientList.Add(client);
                SaveChanges();
            }
            else
            {
                ClientList.Add(client);
                SaveChanges();
            }
        }
        public Client SearchClient()
        {
            ClientList = datb.ClientReader();
            int id = Inputs.InputUserID();
            if (ClientList != null)
            {
                foreach (var item in ClientList)
                {
                    if (item.UserID == id)
                    {
                        return item;
                    }
                }
            }
           return null;
        }
        public string DeleteClient()
        {
            //ClientList = datb.ClientReader();
            Client obj = SearchClient();
            if (obj != null)
            {
                ClientList.Remove(obj);
                SaveChanges();

                return "Deleting is successfull";

            }
            else
            {
                return Exception.ErrorID(); ;
            }
        }
        public string EditClient()
        {
            Client obj = SearchClient();

            
            if (obj != null)
            {
                string s = Inputs.InputWhatToEditCl();
                if (s == "1")
                {
                    string FName = Inputs.InputFirstName();
                    obj.Name = FName;
                }else if (s == "2")
                {
                    string LName = Inputs.InputLastName();
                    obj.Surname = LName;
                }
                else if (s == "3")
                {
                    string BankID = Inputs.InputBankID();
                    obj.BankID = BankID;
                }
                else if (s == "4")
                {
                    int UserID = Inputs.InputUserID();
                    obj.UserID = UserID;
                }
                else if (s == "5")
                {
                    string prefer = Inputs.InputEstateType();
                    obj.PreferType = prefer;
                }
                else
                {
                    return "This field is accessible only for administration! Please try again.";
                }
                SaveChanges();
                return $"Updated object: {obj.GetData()}";

            }
            else
            {
                return Exception.ErrorID(); ;
            }
        }
        public string ShowClient()
        {

            Client obj = SearchClient();
            if (obj != null)
            {
               return obj.GetData();
            }
            else 
            {
                return Exception.ErrorID(); ;
            }
        }

        public string GetClientList()
        {
            string s = "";
            ClientList = datb.ClientReader();
            if (ClientList != null)
            {
                foreach (var item in ClientList)
                {
                    s += $"{item.GetData()}  \n";
                }
                return s;
            }
            return Exception.ErrorList();
        }
        public string GetSortedList()
        {
            string s = "";
            List<Client> sorted = new List<Client>();
            ClientList = datb.ClientReader();
            string type = Inputs.InputClientSort();
            if (ClientList != null)
            {
                if (type == "1")
                {
                    sorted = ClientList.OrderBy(x => x.Name).ToList();
                }
                else if (type == "2")
                {
                    sorted = ClientList.OrderBy(x => x.Surname).ToList();
                }
                else
                {
                    sorted = ClientList.OrderBy(x => x.BankID[2]).ToList();
                }
            }
            else
            {
                return Exception.ErrorList();
            }
           
            foreach (var item in sorted)
            {
                s += $"{item.GetData()}  \n";
            }
            return s;
        }
        public List<Client> GetAll()
        {
            ClientList = datb.ClientReader();
            return ClientList;
        }
        public string SearchClByKeyword(string s)
        {
            List<Client> res = new List<Client>();
            string subst = "";
            ClientList = datb.ClientReader();
            if (ClientList == null)
            {
                return Exception.ErrorList();
            }

            foreach (var item in ClientList)
            {
                if (item.Name == s || item.Surname == s || item.BankID == s || item.UserID.ToString() == s || item.PreferType == s)
                {
                    res.Add(item);
                }
            }
            subst += "By your keyword we have found the next clients: \n";
            foreach (var key in res)
            {
                subst += key.GetData() + "\n";
            }
            return subst;
        }
    }
}
