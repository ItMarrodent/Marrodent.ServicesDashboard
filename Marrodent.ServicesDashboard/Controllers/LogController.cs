using System.Text;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class LogController : ILogController
{
    //Public
    public void GetLogs(ServiceApp serviceApp)
    {
        if (!string.IsNullOrEmpty(serviceApp.CorrectLogAddress) && !string.IsNullOrEmpty(serviceApp.ErrorLogAddress))
        {
            SaveFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.CorrectLogAddress), "Correct");
        }
        else if (!string.IsNullOrEmpty(serviceApp.CorrectLogAddress))
        {
            SaveFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.CorrectLogAddress), "Log");
        }
        
        if (!string.IsNullOrEmpty(serviceApp.ErrorLogAddress))
        {
            SaveFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.ErrorLogAddress), "Error");
        }
    }
    public bool HasErrorsToday(ServiceApp serviceApp)
    {
        if (!string.IsNullOrEmpty(serviceApp.ErrorLogAddress))
        {
            return GetTodayFiles(serviceApp, serviceApp.ErrorLogAddress).Any();
        }
        if (!string.IsNullOrEmpty(serviceApp.CorrectLogAddress))
        {
            ICollection<string> files = GetTodayFiles(serviceApp, serviceApp.CorrectLogAddress);

            if (!files.Any()) return false;

            StringBuilder sb = new StringBuilder();

            foreach (var file in files)
            {
                sb.Append(File.ReadAllText(file));
            }

            return CheckErrorWords(sb.ToString().ToLower());
        }

        return false;
    }

    //Private
    private void SaveFiles(string app, ICollection<string> files, string type)
    {
        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            File.WriteAllText($@"{KnownFolders.GetPath(KnownFolder.Downloads)}\{type}_{app}_{info.Name}", File.ReadAllText(file));
        }
    }

    private ICollection<string> GetTodayFiles(ServiceApp serviceApp, string path)
    {
        if(!Directory.Exists($@"\\{serviceApp.Address}\{path.Replace(@"C:\", @"C$\")}")) return new List<string>();
        
        return Directory.GetFiles($@"\\{serviceApp.Address}\{path.Replace(@"C:\", @"C$\")}")
            .Select(x=> new FileInfo(x))
            .Where(x=>x.CreationTime >= DateTime.Today)
            .Select(x=>x.FullName)
            .ToList();
    }
    
    private bool CheckErrorWords(string arg)
    {
        return arg.Contains("error") || arg.Contains("problem") || arg.Contains("exception") || arg.Contains("warning") || arg.Contains("błąd");
    }
}