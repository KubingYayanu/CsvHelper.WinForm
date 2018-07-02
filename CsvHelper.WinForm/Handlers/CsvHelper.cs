using CsvHelper.Configuration;
using CsvHelper.WinForm.Models;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CsvHelper.WinForm
{
    public class CsvHelper
    {
        public Encoding Encoding { get; set; } = Encoding.GetEncoding("BIG5");

        public byte[] Composer<T, TMapper>(IEnumerable<T> records) where T : class, new() where TMapper : ClassMap<T>
        {
            byte[] result;

            var config = new Configuration.Configuration();
            config.RegisterClassMap<TMapper>();

            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms, Encoding))
                using (var writer = new CsvWriter(sw, config))
                {
                    writer.WriteRecords<T>(records);
                }

                result = ms.ToArray();
            }

            return result;
        }

        public List<CsvModel> GetDummy()
        {
            var dummy = new List<CsvModel>
            {
                new CsvModel
                {
                    ProductName = "Product1",
                    Email = "marcrowell1@gmail.com",
                    Phone = "0912000001",
                    CPSerial = "AB00001"
                },
                new CsvModel
                {
                    ProductName = "Product2",
                    Email = "marcrowell2@gmail.com",
                    Phone = "0912000002",
                    CPSerial = "AB00002"
                },
                new CsvModel
                {
                    ProductName = "Product3",
                    Email = "marcrowell3@gmail.com",
                    Phone = "0912000003",
                    CPSerial = "AB00003"
                },
                new CsvModel
                {
                    ProductName = "Product4",
                    Email = "marcrowell4@gmail.com",
                    Phone = "0912000004",
                    CPSerial = "AB00004"
                },
                new CsvModel
                {
                    ProductName = "Product5",
                    Email = "marcrowell5@gmail.com",
                    Phone = "0912000005",
                    CPSerial = "AB00005"
                },
                new CsvModel
                {
                    ProductName = "Product6",
                    Email = "marcrowell6@gmail.com",
                    Phone = "0912000006",
                    CPSerial = "AB00006"
                },
                new CsvModel
                {
                    ProductName = "Product7",
                    Email = "marcrowell7@gmail.com",
                    Phone = "0912000007",
                    CPSerial = "AB00007"
                },
                new CsvModel
                {
                    ProductName = "Product8",
                    Email = "marcrowell8@gmail.com",
                    Phone = "0912000008",
                    CPSerial = "AB00008"
                }
            };

            return dummy;
        }
    }
}