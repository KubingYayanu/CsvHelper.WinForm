using CsvHelper.WinForm.Handlers;
using CsvHelper.WinForm.Maps;
using CsvHelper.WinForm.Models;
using System;
using System.IO;
using System.Windows.Forms;

namespace CsvHelper.WinForm
{
    public partial class CsvForm : Form
    {
        public CsvForm()
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
            // Test result.
            if (result == DialogResult.OK)
            {
                var hander = new CsvHandler<CsvModelMap, CsvModel>(openFileDialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Csv files (*.csv)|*.csv";
            saveFileDialog.Title = "Save a Csv File";

            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                var helper = new CsvHelper();

                var byteArray = helper.Composer<CsvModel, CsvModelMap>(helper.GetDummy());

                using (var fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
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