using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCompletedProjects
{
    public class Program
    {
        static private List<string> _projectNumbers = new List<string>();
        static private string _logMessage = "Project Number,Team Leader,Phone Number,Director,Phone Number,Project Status\n";
        static private string _logPath = ConnectionDetails.LogPath;

        static void Main(string[] args)
        {
            for (int i = 2005; i <= 2016; i++)
            {
                ListProjects(@"P:\" + i);
            }

            foreach (var p in _projectNumbers)
            {
                var status = DatabaseQuery.GetStatus(p);
                if (status == null)
                {
                    Console.WriteLine("Couldn't find project status for project {0}", p);
                }
                else if (status.Equals("2"))
                {
                    var teamLeaderName = DatabaseQuery.GetTeamLeaderName(p);
                    var directorName = DatabaseQuery.GetDirectorName(p);
                    _logMessage += p + "," + teamLeaderName + "," + directorName + ",Completed\n";
                    Console.WriteLine("The project {0} is completed", p);
                }
            }

            Log(_logMessage, _logPath);
            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void ListProjects(string path)
        {
            var projects = from file in Directory.EnumerateDirectories(path, "?????_*", SearchOption.TopDirectoryOnly)
                           select new
                           {
                               File = file
                           };

            foreach (var item in projects)
            {
                var projectNumber = getProjectNumber(item.File);
                _projectNumbers.Add(projectNumber);
            }
        }

        private static string getProjectNumber(string fileName)
        {
            return fileName.Substring(8, 5);
        }

        private static void Log(string message, string path)
        {
            try
            {
                using (TextWriter w = File.CreateText(path))
                {
                    w.WriteLine(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not log the file: " + e.ToString());
            }
        }
    }
}
