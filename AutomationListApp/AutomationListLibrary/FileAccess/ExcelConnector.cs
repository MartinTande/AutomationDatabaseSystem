using AutomationListLibrary.Data;
using ExcelDataReader;
using System.Collections.Generic;
using System.Data;

namespace AutomationListLibrary.FileAcces;

public class ExcelConnector
{
    private IEnumerable<DataTable> ReadFile(string filePath)
    {
        using (var streamVal = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(streamVal))
            {
                var configuration = new ExcelDataSetConfiguration
                {
                    FilterSheet = (tableReader, sheetIndex) => true,
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true     // excludes the header rows
                    }
                };

                var dataset = reader.AsDataSet(configuration);
                var tables = dataset.Tables.Cast<DataTable>();

                return tables;
            }
        }
    }
    private void WriteFile()
    {

    }

    public List<Otd> ReadOtdFiles(List<string> filePaths)
    {
        // OTD Excel file config
        int _otdInputSheetNumer = 1;
        int _otdOutputSheetNumer = 2;
        int nameColumn = 0;
        int suffixColumn = 1;
        int dataTypeColumn = 3;
        int isOptionalColumn = 4;

        List<Otd> Otds = new List<Otd>();

        foreach (string filePath in filePaths)
        {
            List<DataTable> dataTables = ReadFile(filePath).ToList();
            Otd newOtd = new Otd { Name = Path.GetFileNameWithoutExtension(filePath) };

            foreach (DataRow inputRow in dataTables[_otdInputSheetNumer].Rows)
            {
                newOtd.Interface.Add(new OtdInterface
                {
                    Name = inputRow[nameColumn].ToString(),
                    Suffix = inputRow[suffixColumn].ToString(),
                    DataType = inputRow[dataTypeColumn].ToString(),
                    IsOptional = inputRow[isOptionalColumn].ToString().Equals("True"),
                    InterfaceType = "Input"
                });
            }
            foreach (DataRow outputRow in dataTables[_otdOutputSheetNumer].Rows)
            {
                newOtd.Interface.Add(new OtdInterface
                {
                    Name = outputRow[nameColumn].ToString(),
                    Suffix = outputRow[suffixColumn].ToString(),
                    DataType = outputRow[dataTypeColumn].ToString(),
                    IsOptional = outputRow[isOptionalColumn].ToString().Equals("True"),
                    InterfaceType = "Output"
                });
            }
            Otds.Add(newOtd);
        }
        return Otds;
    }
}
