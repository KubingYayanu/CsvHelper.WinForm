using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelper.WinForm.Handlers
{
    public class CsvHandler<TModelMap, TModel> where TModelMap : ClassMap<TModel>, new() where TModel : class, new()
    {
        public string FilePath { get; }

        public bool IsHeaderValid { get; private set; }

        public bool IsFieldsValid { get; private set; }

        public List<string> HeaderErrors { get; private set; }

        public List<string> FieldsErrors { get; private set; }

        public List<TModel> CsvContent { get; private set; }

        public CsvHandler(string filePath)
        {
            #region Arrange

            FilePath = filePath;
            IsHeaderValid = true;
            IsFieldsValid = true;
            HeaderErrors = new List<string>();
            FieldsErrors = new List<string>();
            CsvContent = new List<TModel>();

            #endregion

            var config = new Configuration.Configuration();
            config.RegisterClassMap<TModelMap>();
            config.HeaderValidated = HeaderValidatedCallback;

            using (var stream = new StreamReader(filePath))
            using (var reader = new CsvReader(stream, config))
            {

                #region Validate Header

                reader.Read();
                reader.ReadHeader();
                reader.ValidateHeader<TModel>();

                #endregion Validate Header

                

                if (IsHeaderValid && IsFieldsValid)
                {
                    var records = reader.GetRecords<TModel>().ToList();
                }
            }
        }

        private void HeaderValidatedCallback(bool isValid, string[] headerNames, int headerNameIndex, ReadingContext context)
        {
            if (!isValid)
            {
                IsHeaderValid = false;
                HeaderErrors.Add($"Header matching ['{string.Join("', '", headerNames)}'] names at index {headerNameIndex} was not found.");
            }
        }
    }
}
