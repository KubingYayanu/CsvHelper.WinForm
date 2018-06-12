using CsvHelper.WinForm.Maps;
using CsvHelper.WinForm.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CsvHelper.WinForm
{
    public partial class Reader : Form
    {
        public Reader()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "Csv files (*.csv)|*.csv";

            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                var config = new Configuration.Configuration();
                config.RegisterClassMap<CsvModelMap>();
                config.HeaderValidated = (isValid, headerNames, headerNameIndex, context) =>
                {
                    if (!isValid)
                    {
                        return;
                    }
                };

                using (var stream = new StreamReader(openFileDialog.FileName))
                using (var reader = new CsvReader(stream, config))
                {

                    #region Validate Header

                    reader.Read();
                    reader.ReadHeader();
                    reader.ValidateHeader<CsvModel>();

                    #endregion Validate Header

                    var records = reader.GetRecords<CsvModel>().ToList();
                }
            }
        }

        private bool IsNotExistOrRecordEmpty(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return true;
            }

            using (var sr = new StreamReader(filepath))
            using (var reader = new CsvReader(sr))
            {
                reader.Read();
                return true;
            }
        }
    }
}