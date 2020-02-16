using DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DEMO.Services
{
    public class BaseSQL
    {
        protected static DEMO.Models.DEMOEntities Db = new DEMOEntities(); 
    }
}