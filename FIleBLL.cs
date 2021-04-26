using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace InterfaceImplement
{
    public class FIleBLL
    {
        FileDAL fileDAL = new FileDAL();
        public void DeleteFileById(string id)
        {
            fileDAL.DeleteFileById(id);


        }


    }
}