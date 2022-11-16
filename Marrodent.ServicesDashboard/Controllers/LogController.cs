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
        return !string.IsNullOrEmpty(serviceApp.ErrorLogAddress) && GetTodayFiles(serviceApp, serviceApp.ErrorLogAddress).Any();
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
        if(!Directory.Exists($@"\\{serviceApp.Address}\{path.Replace(@"C:\", string.Empty)}")) return new List<string>();
        
        return Directory.GetFiles($@"\\{serviceApp.Address}\{path.Replace(@"C:\", string.Empty)}")
            .Select(x=> new FileInfo(x))
            .Where(x=>x.CreationTime >= DateTime.Today)
            .Select(x=>x.FullName)
            .ToList();
    }
}