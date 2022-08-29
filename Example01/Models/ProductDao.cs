using Example01.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Example01.Models
{
    public class ProductDao
    {
        objqlbhEntities objqlbhEntities = new objqlbhEntities();
        public List<Product> SearchByKey(string key)
        {
            return objqlbhEntities.Products.SqlQuery("Select * From Product Where Name like N'%" + key + "%'").ToList();
        }
    }
}