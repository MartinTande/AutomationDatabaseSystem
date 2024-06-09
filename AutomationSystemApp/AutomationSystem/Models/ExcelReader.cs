using AutomationSystem.Models.Data.Categories;
using Microsoft.Office.Interop.Excel;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;


namespace AutomationSystem.Models;

public class ExcelReader
{
    Excel.Application _excelReader = new Excel.Application();
    string _path = "";
    string[] _paths = [];
    Workbook _workbook;
    Worksheet _worksheet;

    public ExcelReader(string path, int sheet)
    {
        _path = path;
        _workbook = _excelReader.Workbooks.Open(path);
        _worksheet = _workbook.Worksheets[sheet];
    }

    public ExcelReader(string path)
    {
        _path = path;
        _workbook = _excelReader.Workbooks.Open(path);
    }

    public ExcelReader()
    {
    }

    private string ReadCell(int i, int j)
    {
        // the excel reader starts at index 1 instead of 0

        if (_worksheet.Cells[i, j].Value2 != null) 
        { 
            return _worksheet.Cells[i, j].Value2.ToString();
        }
        else
        {
            return "";
        }
    }

    public List<Otd> ReadOtds(string[] paths)
    {
        List<Otd> _otds = new List<Otd>();

        foreach(string path in paths)
        {
            _workbook = _excelReader.Workbooks.Open(path);
            
            // Find Otd type
            _worksheet = _workbook.Worksheets["Metadata"];

            string boType = ReadCell(2, 2);

            Otd otd = new Otd { Name = boType };
            
            // Get inputs
            _worksheet = _workbook.Worksheets["Inputs"];

            int i = 2;
            do
            {
                string _name = ReadCell(i, 1);

                if (!string.IsNullOrEmpty(_name))
                {
                    otd.Interface.Add(new OtdInterface
                    {
                        Name = _name,
                        Suffix = ReadCell(i, 2),
                        DataType = ReadCell(i, 4),
                        InterfaceType = "Input",
                        IsOptional = ReadCell(i, 5).Equals("True")
                    });
                }
                i++;
            } while (!ReadCell(i, 1).Equals(""));

            // Get outputs
            _worksheet = _workbook.Worksheets["Outputs"];

            int j = 2;
            do
            {
                string _name = ReadCell(j, 1);

                if (!string.IsNullOrEmpty(_name))
                {
                    otd.Interface.Add(new OtdInterface
                    {
                        Name = _name,
                        Suffix = ReadCell(j, 2),
                        DataType = ReadCell(j, 4),
                        InterfaceType = "Output",
                        IsOptional = ReadCell(j, 5).Equals("True")
                    });
                }
            } while (!ReadCell(i, 1).Equals(""));

            _otds.Add(otd);
        }

        return _otds;
    }
}
