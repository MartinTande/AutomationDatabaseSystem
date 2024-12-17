using System.Diagnostics;

namespace AutomationListLibrary.Data;

public class Test
{
	public static void TestCreateDatabase()
	{
		string sqlPackagePath = @"C:\Path\To\SqlPackage.exe";
		string publishXmlPath = @"C:\Path\To\Your.publish.xml";
		string targetDatabaseName = "YourDatabaseName";

		ProcessStartInfo startInfo = new ProcessStartInfo
		{
			FileName = sqlPackagePath,
			Arguments = $"/Action:Publish /SourceFile:{publishXmlPath} /TargetDatabaseName:{targetDatabaseName}",
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		using (Process process = new Process { StartInfo = startInfo })
		{
			process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
			process.ErrorDataReceived += (sender, e) => Console.WriteLine("ERROR: " + e.Data);

			process.Start();
			process.BeginOutputReadLine();
			process.BeginErrorReadLine();
			process.WaitForExit();
		}
	}
}
