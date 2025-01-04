using AutomationListUI.Models;
using AutomationListUI.Utils;
using ClosedXML.Excel;
using System.IO;
using System.Security.AccessControl;

namespace AutomationListUI.Services;

public class ExcelService
{
	private readonly IObjectService _objectService;
	private readonly ITagService _tagService;

    public ExcelService(IObjectService objectService, ITagService tagService)
    {
		_objectService = objectService;
		_tagService = tagService;
    }

	public Dictionary<string, DisplayObjectModel> ReadExcelObjects(MemoryStream memoryStream)
	{
		using var workbook = new XLWorkbook(memoryStream);
		var ioListWorksheet = workbook.Worksheets.ElementAtOrDefault(1);

		if (ioListWorksheet == null) return null;

		Dictionary<string, int> headers = new();

		int headerRow = 1;
		int columnNumber = 1;
		
		// get headers
		while (!string.IsNullOrEmpty(ioListWorksheet.Cell(headerRow, columnNumber).Value.ToString()))
		{
			headers.Add(ioListWorksheet.Cell(headerRow, columnNumber).Value.ToString(), columnNumber);
			columnNumber++;
		}
		var rows = ioListWorksheet.RowsUsed().Skip(1);      // skip header row

		Dictionary<string, DisplayObjectModel> excelObjects = new Dictionary<string, DisplayObjectModel>();

		foreach (var row in rows)
		{
			string objectName = row.Cell(headers["Object"]).GetString();
			if (string.IsNullOrEmpty(objectName))
			{
				continue;
			}

			DisplayTagModel tag = new DisplayTagModel()
			{
				EqSuffix = row.Cell(headers["Eq_suffix"]).GetString(),
				Description = row.Cell(headers["Tag_description"]).GetString(),
				IoType = row.Cell(headers["IO_type"]).GetString(),
				SignalType = row.Cell(headers["Signal_type"]).GetString(),
				Symbol = row.Cell(headers["Symbol"]).GetString(),
				EngUnit = row.Cell(headers["Eng_unit"]).GetString(),
				AlarmDelay = row.Cell(headers["Alarm_delay"]).GetString(),
				RangeLow = int.TryParse(row.Cell(headers["Range_min"]).GetString(), out int rangeLow) ? rangeLow : null,
				RangeHigh = int.TryParse(row.Cell(headers["Range_max"]).GetString(), out int rangeHigh) ? rangeHigh : null,
				LowLowLimit = int.TryParse(row.Cell(headers["AlmLL"]).GetString(), out int lowLowLimit) ? lowLowLimit : null,
				LowLimit = int.TryParse(row.Cell(headers["AlmL"]).GetString(), out int lowLimit) ? lowLimit : null,
				HighLimit = int.TryParse(row.Cell(headers["AlmH"]).GetString(), out int highLimit) ? highLimit : null,
				HighHighLimit = int.TryParse(row.Cell(headers["AlmHH"]).GetString(), out int highHighLimit) ? highHighLimit : null,
				Slot = int.TryParse(row.Cell(headers["Slot"]).GetString(), out int slot) ? slot : null,
				Channel = int.TryParse(row.Cell(headers["Channel"]).GetString(), out int channel) ? channel : null,
				TP1 = int.TryParse(row.Cell(headers["TP1"]).GetString(), out int tp1) ? tp1 : null,
				TP2 = int.TryParse(row.Cell(headers["TP2"]).GetString(), out int tp2) ? tp2 : null,
				TP3 = int.TryParse(row.Cell(headers["TP3"]).GetString(), out int tp3) ? tp3 : null,
				TP4 = int.TryParse(row.Cell(headers["TP4"]).GetString(), out int tp4) ? tp4 : null,
				AbsoluteAddress = row.Cell(headers["AbsoluteAddr"]).GetString(),
				SWPath = row.Cell(headers["SW_Path"]).GetString(),
				DBName = row.Cell(headers["DB_name"]).GetString(),
				IsE0 = row.Cell(headers["E0_Req"]).Value.ToString() == "Y",
				IsVDR = row.Cell(headers["VDR_Req"]).Value.ToString() == "Y",
				IOStatus = row.Cell(headers["IO_status"]).GetString(),
				InterfaceModule = row.Cell(headers["IM"]).GetString(),
				UserLock = row.Cell(headers["User_Lock"]).GetString() == "Y",
				IOLock = row.Cell(headers["IO_LOCK"]).GetString() == "Y",
			};

			if (excelObjects.ContainsKey(objectName))
			{
				excelObjects[objectName].Tags.Add(tag);
			}
			else
			{
				var newObject = new DisplayObjectModel()
				{
					SfiNumber = row.Cell(headers["SFI_no"]).GetString(),
					MainEqNumber = row.Cell(headers["Main_eq_no"]).GetString(),
					EqNumber = row.Cell(headers["Eq_no"]).GetString(),
					FullObjectName = row.Cell(headers["Object"]).GetString(),
					Description = row.Cell(headers["Object_description"]).GetString(),
					Hierarchy1 = row.Cell(headers["Hierarchy_1"]).GetString(),
					Hierarchy2 = row.Cell(headers["Hierarchy_2"]).GetString(),
					VduGroup = row.Cell(headers["VduGrp"]).GetString(),
					AcknowledgeAllowed = row.Cell(headers["AcknowledgeAllowed"]).GetString(),
					AlwaysVisible = row.Cell(headers["AlwaysVisible"]).GetString(),
					AlarmGroup = row.Cell(headers["AlmGrp"]).GetString(),
					Node = row.Cell(headers["Node"]).GetString(),
					Cabinet = row.Cell(headers["Cabinet"]).GetString(),
					Otd = row.Cell(headers["OTD"]).GetString(),
					Revision = row.Cell(headers["Revision"]).GetString(),
				};

				excelObjects.Add(objectName, newObject);
			}
		}
		return excelObjects;
	}

    public async Task<bool> ImportObjects(Dictionary<string,DisplayObjectModel> excelObjects)
	{
		try
		{
			foreach (KeyValuePair<string, DisplayObjectModel> excelObject in excelObjects)
			{
				_objectService.InsertObjectAsync(excelObject.Value).Wait();
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

		// Headers
		Dictionary<string, int> headers = ExcelListHeaders.GetIOListHeaders();
		foreach (var header in headers)
		{
			worksheet.Cell(1, header.Value).Value = header.Key;
		}

		int i = 0;
		foreach (var obj in objects)
		{
			if (obj.Tags != null) continue;

			foreach (var tag in obj.Tags)
			{
				worksheet.Cell(i + 2, headers["Sfi_no"]).Value = obj.SfiNumber;
				worksheet.Cell(i + 2, headers["Main_eq_no"]).Value = obj.MainEqNumber;
				worksheet.Cell(i + 2, headers["Eq_no"]).Value = obj.EqNumber;
				worksheet.Cell(i + 2, headers["Eq_suffix"]).Value = tag.EqSuffix;
				worksheet.Cell(i + 2, headers["Tag_number"]).Value = tag.TagNumber;
				worksheet.Cell(i + 2, headers["Tag_description"]).Value = tag.Description;
				worksheet.Cell(i + 2, headers["Main_eq_desc"]).Value = obj.Description;
				worksheet.Cell(i + 2, headers["VduGrp"]).Value = obj.VduGroup;
				worksheet.Cell(i + 2, headers["Symbol"]).Value = tag.Symbol;
				worksheet.Cell(i + 2, headers["IO_type"]).Value = tag.IoType;
				worksheet.Cell(i + 2, headers["Signal_type"]).Value = tag.SignalType;
				worksheet.Cell(i + 2, headers["Range_min"]).Value = tag.RangeLow;
				worksheet.Cell(i + 2, headers["Range_max"]).Value = tag.RangeHigh;
				worksheet.Cell(i + 2, headers["Eng_unit"]).Value = tag.EngUnit;
				worksheet.Cell(i + 2, headers["Alarm_delay"]).Value = tag.AlarmDelay;
				worksheet.Cell(i + 2, headers["AlmHH"]).Value = tag.HighHighLimit;
				worksheet.Cell(i + 2, headers["AlmH"]).Value = tag.HighLimit;
				worksheet.Cell(i + 2, headers["AlmL"]).Value = tag.LowLimit;
				worksheet.Cell(i + 2, headers["AlmLL"]).Value = tag.LowLowLimit;
				worksheet.Cell(i + 2, headers["AlmGrp"]).Value = obj.AlarmGroup;
				worksheet.Cell(i + 2, headers["AcknowledgeAllowed"]).Value = obj.AcknowledgeAllowed;
				worksheet.Cell(i + 2, headers["AlwaysVisible"]).Value = obj.AlwaysVisible;
				worksheet.Cell(i + 2, headers["E0_Req"]).Value = tag.IsE0 ? 'Y' : string.Empty;
				worksheet.Cell(i + 2, headers["VDR_Req"]).Value = tag.IsVDR ? 'Y' : string.Empty;
				worksheet.Cell(i + 2, headers["Node"]).Value = obj.Node;
				worksheet.Cell(i + 2, headers["Cabinet"]).Value = obj.Cabinet;
				worksheet.Cell(i + 2, headers["Revision"]).Value = obj.Revision;
				worksheet.Cell(i + 2, headers["IM"]).Value = tag.InterfaceModule;
				worksheet.Cell(i + 2, headers["Slot"]).Value = tag.Slot;
				worksheet.Cell(i + 2, headers["Channel"]).Value = tag.Channel;
				worksheet.Cell(i + 2, headers["TP1"]).Value = tag.TP1;
				worksheet.Cell(i + 2, headers["TP2"]).Value = tag.TP2;
				worksheet.Cell(i + 2, headers["TP3"]).Value = tag.TP3;
				worksheet.Cell(i + 2, headers["TP4"]).Value = tag.TP4;
				worksheet.Cell(i + 2, headers["AbsoluteAddr"]).Value = tag.AbsoluteAddress;
				worksheet.Cell(i + 2, headers["User_Lock"]).Value = tag.UserLock;
				worksheet.Cell(i + 2, headers["Object"]).Value = obj.FullObjectName;
				worksheet.Cell(i + 2, headers["Object_description"]).Value = obj.Description;
				worksheet.Cell(i + 2, headers["OTD"]).Value = obj.Otd;
				worksheet.Cell(i + 2, headers["Hierarchy_1"]).Value = obj.Hierarchy1;
				worksheet.Cell(i + 2, headers["Hierarchy_2"]).Value = obj.Hierarchy2;
				worksheet.Cell(i + 2, headers["DB_name"]).Value = tag.DBName;
				worksheet.Cell(i + 2, headers["SW_Path"]).Value = tag.SWPath;
				worksheet.Cell(i + 2, headers["CSF"]).Value = tag.CSF;

				i++;
			}

		}

		using var stream = new MemoryStream();
		workbook.SaveAs(stream);
		return stream.ToArray();
	}
}
