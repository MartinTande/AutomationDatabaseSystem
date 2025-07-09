using AutomationListLibrary.Data;
using AutomationListUI.Models;
using ClosedXML.Excel;
using System.Diagnostics;

namespace AutomationListUI.Services;

public class ExcelService
{
	private readonly IObjectService _objectService;
	private readonly ITagService _tagService;
	private readonly Dictionary<string, int> _headers;
	const int MASTER_IO_LIST_INDEX = 1;
	const int PICTURE_HIERARCHY_INDEX = 10;

	public ExcelService(IObjectService objectService, ITagService tagService)
    {
		_objectService = objectService;
		_tagService = tagService;
		_headers = new Dictionary<string, int>();
    }

	public List<DisplayObjectModel>? ReadExcelObjects(MemoryStream memoryStream)
	{
		var stopwatch = Stopwatch.StartNew();
		var timings = new Dictionary<string, long>();
		try
		{
			var workbookStart = Stopwatch.GetTimestamp();
			using var workbook = new XLWorkbook(memoryStream);
			var ioListWorksheet = workbook.Worksheets.ElementAtOrDefault(MASTER_IO_LIST_INDEX);
			var picHierarchyWorksheet = workbook.Worksheets.ElementAt(PICTURE_HIERARCHY_INDEX);
			timings["WorkbookLoad"] = Stopwatch.GetElapsedTime(workbookStart).Ticks;

			var hierarchyStart = Stopwatch.GetTimestamp();
			var picHierarchy = ReadPictureHierarchy(picHierarchyWorksheet);
			timings["HierarchyRead"] = Stopwatch.GetElapsedTime(hierarchyStart).Ticks;

			if (ioListWorksheet == null)
				return null;

			// Read headers efficiently
			var headerStart = Stopwatch.GetTimestamp();
			_headers.Clear(); // Clear existing headers
			var headerRow = ioListWorksheet.Row(1);
			var lastColumn = headerRow.LastCellUsed()?.Address.ColumnNumber ?? 0;
			_headers.EnsureCapacity(lastColumn); // Pre-allocate capacity

			for (int col = 1; col <= lastColumn; col++)
			{
				var cellValue = headerRow.Cell(col).GetString();
				if (string.IsNullOrEmpty(cellValue)) break;
				_headers.Add(cellValue, col);
			}
			timings["HeaderRead"] = Stopwatch.GetElapsedTime(headerStart).Ticks;

			var processingStart = Stopwatch.GetTimestamp();
			var rows = ioListWorksheet.RowsUsed().Skip(1);
			var estimatedObjectCount = ioListWorksheet.RowsUsed().Count() / 5; // Estimate objects
			var excelObjects = new Dictionary<string, DisplayObjectModel>(estimatedObjectCount);

			foreach (var row in rows)
			{
				string objectName = row.Cell(_headers["Object"]).GetString();
				if (string.IsNullOrEmpty(objectName))
					continue;

				DisplayTagModel tag = new DisplayTagModel()
				{
					EqSuffix = row.Cell(_headers["Eq_suffix"]).GetString(),
					Description = row.Cell(_headers["Tag_description"]).GetString(),
					IoType = row.Cell(_headers["IO_type"]).GetString(),
					SignalType = row.Cell(_headers["Signal_type"]).GetString(),
					Symbol = row.Cell(_headers["Symbol"]).GetString(),
					EngUnit = row.Cell(_headers["Eng_unit"]).GetString(),
					AlarmDelay = row.Cell(_headers["Alarm_delay"]).GetString(),
					RangeLow = int.TryParse(row.Cell(_headers["Range_min"]).GetString().AsSpan(), out int rangeLow) ? rangeLow : null,
					RangeHigh = int.TryParse(row.Cell(_headers["Range_max"]).GetString().AsSpan(), out int rangeHigh) ? rangeHigh : null,
					LowLowLimit = int.TryParse(row.Cell(_headers["AlmLL"]).GetString().AsSpan(), out int lowLowLimit) ? lowLowLimit : null,
					LowLimit = int.TryParse(row.Cell(_headers["AlmL"]).GetString().AsSpan(), out int lowLimit) ? lowLimit : null,
					HighLimit = int.TryParse(row.Cell(_headers["AlmH"]).GetString().AsSpan(), out int highLimit) ? highLimit : null,
					HighHighLimit = int.TryParse(row.Cell(_headers["AlmHH"]).GetString().AsSpan(), out int highHighLimit) ? highHighLimit : null,
					Slot = int.TryParse(row.Cell(_headers["Slot"]).GetString().AsSpan(), out int slot) ? slot : null,
					Channel = int.TryParse(row.Cell(_headers["Channel"]).GetString().AsSpan(), out int channel) ? channel : null,
					TP1 = int.TryParse(row.Cell(_headers["TP1"]).GetString().AsSpan(), out int tp1) ? tp1 : null,
					TP2 = int.TryParse(row.Cell(_headers["TP2"]).GetString().AsSpan(), out int tp2) ? tp2 : null,
					TP3 = int.TryParse(row.Cell(_headers["TP3"]).GetString().AsSpan(), out int tp3) ? tp3 : null,
					TP4 = int.TryParse(row.Cell(_headers["TP4"]).GetString().AsSpan(), out int tp4) ? tp4 : null,
					AbsoluteAddress = row.Cell(_headers["AbsoluteAddr"]).GetString(),
					SWPath = row.Cell(_headers["SW_Path"]).GetString(),
					DBName = row.Cell(_headers["DB_name"]).GetString(),
					IsE0 = row.Cell(_headers["E0_Req"]).GetString().Equals("Y", StringComparison.OrdinalIgnoreCase),
					IsVDR = row.Cell(_headers["VDR_Req"]).GetString().Equals("Y", StringComparison.OrdinalIgnoreCase),
					IOStatus = row.Cell(_headers["IO_status"]).GetString(),
					InterfaceModule = row.Cell(_headers["IM"]).GetString(),
					UserLock = row.Cell(_headers["User_Lock"]).GetString().Equals("Y", StringComparison.OrdinalIgnoreCase),
					IOLock = row.Cell(_headers["IO_LOCK"]).GetString().Equals("Y", StringComparison.OrdinalIgnoreCase),
				};

				if (excelObjects.TryGetValue(objectName, out DisplayObjectModel? value))
				{
					value.Tags.Add(tag);
				}
				else
				{
					var newObject = new DisplayObjectModel()
					{
						SfiNumber = row.Cell(_headers["SFI_no"]).GetString(),
						MainEqNumber = row.Cell(_headers["Main_eq_no"]).GetString(),
						EqNumber = row.Cell(_headers["Eq_no"]).GetString(),
						FullObjectName = objectName, // Reuse already retrieved value
						Description = row.Cell(_headers["Object_description"]).GetString(),
						Hierarchy1 = row.Cell(_headers["Hierarchy_1"]).GetString(),
						Hierarchy2 = row.Cell(_headers["Hierarchy_2"]).GetString(),
						VduGroup = row.Cell(_headers["VduGrp"]).GetString(),
						AcknowledgeAllowed = row.Cell(_headers["AcknowledgeAllowed"]).GetString(),
						AlwaysVisible = row.Cell(_headers["AlwaysVisible"]).GetString(),
						AlarmGroup = row.Cell(_headers["AlmGrp"]).GetString(),
						Node = row.Cell(_headers["Node"]).GetString(),
						Cabinet = row.Cell(_headers["Cabinet"]).GetString(),
						Otd = row.Cell(_headers["OTD"]).GetString(),
						Revision = row.Cell(_headers["Revision"]).GetString(),
						Tags = new List<DisplayTagModel> { tag } // Initialize with first tag
					};

					excelObjects.Add(objectName, newObject);
				}
			}
			timings["RowProcessing"] = Stopwatch.GetElapsedTime(processingStart).Ticks;

			// Optimized conversion - pre-allocate with exact capacity
			var conversionStart = Stopwatch.GetTimestamp();
			var objectList = new List<DisplayObjectModel>(excelObjects.Count);
			objectList.AddRange(excelObjects.Values);
			timings["ListConversion"] = Stopwatch.GetElapsedTime(conversionStart).Ticks;

			stopwatch.Stop();
			timings["Total"] = stopwatch.ElapsedTicks;

			// Log performance metrics
			var totalRows = ioListWorksheet.RowsUsed().Count();
			var totalTime = TimeSpan.FromTicks(timings["Total"]);

			Console.WriteLine("=== Performance Metrics ===");
			Console.WriteLine($"Workbook Load: {TimeSpan.FromTicks(timings["WorkbookLoad"]).TotalMilliseconds:F2}ms");
			Console.WriteLine($"Hierarchy Read: {TimeSpan.FromTicks(timings["HierarchyRead"]).TotalMilliseconds:F2}ms");
			Console.WriteLine($"Header Read: {TimeSpan.FromTicks(timings["HeaderRead"]).TotalMilliseconds:F2}ms ({_headers.Count} columns)");
			Console.WriteLine($"Row Processing: {TimeSpan.FromTicks(timings["RowProcessing"]).TotalMilliseconds:F2}ms");
			Console.WriteLine($"List Conversion: {TimeSpan.FromTicks(timings["ListConversion"]).TotalMilliseconds:F2}ms");
			Console.WriteLine($"Total Time: {totalTime.TotalMilliseconds:F2}ms");
			Console.WriteLine($"Rows Processed: {totalRows:N0}");
			Console.WriteLine($"Objects Created: {objectList.Count:N0}");
			Console.WriteLine($"Tags per Object: {(totalRows > 0 ? (double)totalRows / objectList.Count : 0):F1}");
			Console.WriteLine($"Processing Rate: {(totalTime.TotalSeconds > 0 ? totalRows / totalTime.TotalSeconds : 0):F0} rows/second");
			Console.WriteLine($"Memory Efficiency: {(excelObjects.Count > 0 ? (double)totalRows / excelObjects.Count : 0):F1}x consolidation");

			return objectList;
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Error after {stopwatch.ElapsedMilliseconds}ms: {ex}");
			throw;
		}
	}

	private static List<Hierarchy1> ReadPictureHierarchy(IXLWorksheet worksheet)
	{
		if (worksheet == null) return [];

		int headerRow = 1;
		int columnNumber = 1;

		List<Hierarchy1>? pictureHierarchy = new();

		while (!string.IsNullOrEmpty(worksheet.Cell(headerRow, columnNumber).GetString()))
		{
			var item = worksheet.Cell(headerRow, columnNumber).GetString();
			Hierarchy1 newMainPic = new() { Name = item };

			int subRow = 2;
			while (!worksheet.Cell(subRow, columnNumber).GetString().Contains("PICT") && !string.IsNullOrEmpty(worksheet.Cell(subRow, columnNumber).GetString()))
			{
				string subItem = worksheet.Cell(subRow,columnNumber).GetString();
				Hierarchy2 subPic = new() { Name = subItem };
				newMainPic.SubPictures.Add(subPic);
				subRow++;
			}

			pictureHierarchy.Add(newMainPic);
			columnNumber++;
		}

		return pictureHierarchy;
	}

	public async Task<bool> ImportObjects(List<DisplayObjectModel> excelObjects)
	{
		try
		{
			foreach (DisplayObjectModel excelObject in excelObjects)
			{
				_objectService.InsertObjectAsync(excelObject).Wait();
			}

			// ADd bulk insert method from dapper
			//await _objectDataManager.InsertObjectAsync(toDB);
			return true;
		}
		catch (Exception ex)
		{
			throw;
		}
	}

	public async Task<Byte[]> ExportToExcel()
	{
		var objects = await _objectService.GetObjectsAsync();
		foreach (var obj in objects)
		{
			obj.Tags = await _tagService.GetTagsByObjectIdAsync(obj.Id);
		}

		using var workbook = new XLWorkbook();

		var worksheet = workbook.Worksheets.Add("Object");

		// _headers
		foreach (var header in _headers)
		{
			worksheet.Cell(1, header.Value).Value = header.Key;
		}

		int i = 0;
		foreach (var obj in objects)
		{
			if (obj.Tags != null) continue;

			foreach (var tag in obj.Tags)
			{
				worksheet.Cell(i + 2, _headers["Sfi_no"]).Value = obj.SfiNumber;
				worksheet.Cell(i + 2, _headers["Main_eq_no"]).Value = obj.MainEqNumber;
				worksheet.Cell(i + 2, _headers["Eq_no"]).Value = obj.EqNumber;
				worksheet.Cell(i + 2, _headers["Eq_suffix"]).Value = tag.EqSuffix;
				worksheet.Cell(i + 2, _headers["Tag_number"]).Value = tag.TagNumber;
				worksheet.Cell(i + 2, _headers["Tag_description"]).Value = tag.Description;
				worksheet.Cell(i + 2, _headers["Main_eq_desc"]).Value = obj.Description;
				worksheet.Cell(i + 2, _headers["VduGrp"]).Value = obj.VduGroup;
				worksheet.Cell(i + 2, _headers["Symbol"]).Value = tag.Symbol;
				worksheet.Cell(i + 2, _headers["IO_type"]).Value = tag.IoType;
				worksheet.Cell(i + 2, _headers["Signal_type"]).Value = tag.SignalType;
				worksheet.Cell(i + 2, _headers["Range_min"]).Value = tag.RangeLow;
				worksheet.Cell(i + 2, _headers["Range_max"]).Value = tag.RangeHigh;
				worksheet.Cell(i + 2, _headers["Eng_unit"]).Value = tag.EngUnit;
				worksheet.Cell(i + 2, _headers["Alarm_delay"]).Value = tag.AlarmDelay;
				worksheet.Cell(i + 2, _headers["AlmHH"]).Value = tag.HighHighLimit;
				worksheet.Cell(i + 2, _headers["AlmH"]).Value = tag.HighLimit;
				worksheet.Cell(i + 2, _headers["AlmL"]).Value = tag.LowLimit;
				worksheet.Cell(i + 2, _headers["AlmLL"]).Value = tag.LowLowLimit;
				worksheet.Cell(i + 2, _headers["AlmGrp"]).Value = obj.AlarmGroup;
				worksheet.Cell(i + 2, _headers["AcknowledgeAllowed"]).Value = obj.AcknowledgeAllowed;
				worksheet.Cell(i + 2, _headers["AlwaysVisible"]).Value = obj.AlwaysVisible;
				worksheet.Cell(i + 2, _headers["E0_Req"]).Value = tag.IsE0 ? 'Y' : string.Empty;
				worksheet.Cell(i + 2, _headers["VDR_Req"]).Value = tag.IsVDR ? 'Y' : string.Empty;
				worksheet.Cell(i + 2, _headers["Node"]).Value = obj.Node;
				worksheet.Cell(i + 2, _headers["Cabinet"]).Value = obj.Cabinet;
				worksheet.Cell(i + 2, _headers["Revision"]).Value = obj.Revision;
				worksheet.Cell(i + 2, _headers["IM"]).Value = tag.InterfaceModule;
				worksheet.Cell(i + 2, _headers["Slot"]).Value = tag.Slot;
				worksheet.Cell(i + 2, _headers["Channel"]).Value = tag.Channel;
				worksheet.Cell(i + 2, _headers["TP1"]).Value = tag.TP1;
				worksheet.Cell(i + 2, _headers["TP2"]).Value = tag.TP2;
				worksheet.Cell(i + 2, _headers["TP3"]).Value = tag.TP3;
				worksheet.Cell(i + 2, _headers["TP4"]).Value = tag.TP4;
				worksheet.Cell(i + 2, _headers["AbsoluteAddr"]).Value = tag.AbsoluteAddress;
				worksheet.Cell(i + 2, _headers["User_Lock"]).Value = tag.UserLock ? 'Y' : string.Empty;
				worksheet.Cell(i + 2, _headers["Object"]).Value = obj.FullObjectName;
				worksheet.Cell(i + 2, _headers["Object_description"]).Value = obj.Description;
				worksheet.Cell(i + 2, _headers["OTD"]).Value = obj.Otd;
				worksheet.Cell(i + 2, _headers["Hierarchy_1"]).Value = obj.Hierarchy1;
				worksheet.Cell(i + 2, _headers["Hierarchy_2"]).Value = obj.Hierarchy2;
				worksheet.Cell(i + 2, _headers["DB_name"]).Value = tag.DBName;
				worksheet.Cell(i + 2, _headers["SW_Path"]).Value = tag.SWPath;
				worksheet.Cell(i + 2, _headers["CSF"]).Value = tag.CSF;

				i++;
			}
		}

		using var stream = new MemoryStream();
		workbook.SaveAs(stream);
		return stream.ToArray();
	}
}
