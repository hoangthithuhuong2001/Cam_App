using System;
using System.Collections.Generic;
using System.Text;

namespace Cam_App
{
    public class User
    {
       private string userName;
       private string passWord;
       private bool accountType; //phân loại tài khoản
       public string UserName { get => userName; set => userName = value; }
       public string PassWord { get => passWord; set => passWord = value; }
        public bool AccountType { get => accountType; set => accountType = value; }

        public User(string userName, string passWord, bool accountType)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.AccountType = accountType;
        }
    }
}
