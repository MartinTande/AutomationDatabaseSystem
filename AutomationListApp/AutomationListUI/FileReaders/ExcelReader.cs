using ExcelDataReader;
using System.Data;

namespace AutomationListUI.Readers;

public class ExcelReader
{
    public IEnumerable<DataTable> ReadFile(string filePath)
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
}
