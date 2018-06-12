using CsvHelper.Configuration;
using CsvHelper.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper.WinForm.Maps
{
    public class CsvModelMap : ClassMap<CsvModel>
    {
        public CsvModelMap()
        {
            Map(m => m.ProductName).Name("ProductName").Index(0).Validate(field => 
            {
                //TODO: validate field format
                return true;
            });
            Map(m => m.Email).Name("Email").Index(1);
            Map(m => m.Phone).Name("Phone").Index(2);
            Map(m => m.CPSerial).Name("CPSerial").Index(3);
        }
    }
}
