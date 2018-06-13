using CsvHelper.WinForm;
using CsvHelper.WinForm.Handlers;
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
                var hander = new CsvHandler<CsvModelMap, CsvModel>(openFileDialog.FileName);
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