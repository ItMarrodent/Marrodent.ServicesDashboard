using System.Text;
using Marrodent.ServicesDashboard.Interfaces;
using Marrodent.ServicesDashboard.Models.Abstracts;

namespace Marrodent.ServicesDashboard.Controllers;

public sealed class LogController : ILogController
{
    //Public
    public ICollection<string> GetLogs(ServiceApp serviceApp)
    {
        List<string> result = new List<string>();

        if (!string.IsNullOrEmpty(serviceApp.CorrectLogAddress) && !string.IsNullOrEmpty(serviceApp.ErrorLogAddress))
        {
            ICollection<string> temp = GetFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.CorrectLogAddress), "Correct");
            if (temp.Any()) result.AddRange(temp);
            temp = GetFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.ErrorLogAddress), "Error");
            if (temp.Any()) result.AddRange(temp);
        }

        else if (!string.IsNullOrEmpty(serviceApp.CorrectLogAddress))
        {
            ICollection<string> temp = GetFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.CorrectLogAddress), "Log");
            if (temp.Any()) result.AddRange(temp);
        }

        else if (!string.IsNullOrEmpty(serviceApp.ErrorLogAddress))
        {
            ICollection<string> temp = GetFiles(serviceApp.ServiceName, GetTodayFiles(serviceApp, serviceApp.ErrorLogAddress), "Error");
            if (temp.Any()) result.AddRange(temp);
        }

        return result;
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
    private ICollection<string> GetFiles(string app, ICollection<string> files, string type)
    {
        ICollection<string> result = new List<string>();
        
        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            string path = $@"{Path.GetTempPath()}{type}_{app}_{info.Name}";
            File.WriteAllText(path, File.ReadAllText(file));
            result.Add(path);
        }

        return result;
    }

    private ICollection<string> GetTodayFiles(ServiceApp serviceApp, string path)
    {
        if(!Directory.Exists($@"\\{serviceApp.Address}\{path.Replace(@"C:\", @"C$\")}")) return new List<string>();

        return Directory.GetFiles($@"\\{serviceApp.Address}\{path.Replace(@"C:\", @"C$\")}")
            .Select(x=> new FileInfo(x))
            .Where(x=>x.LastWriteTime.Date >= DateTime.Today)
            .Select(x=>x.FullName)
            .ToList();
    }
    
    private bool CheckErrorWords(string arg)
    {
        return arg.Contains("error") || arg.Contains("problem") || arg.Contains("exception") || arg.Contains("warning") || arg.Contains("błąd");
    }
}