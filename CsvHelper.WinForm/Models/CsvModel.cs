using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper.WinForm.Models
{
    public class CsvModel
    {
        public string ProductName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CPSerial { get; set; }
    }
}
