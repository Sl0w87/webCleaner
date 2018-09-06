using System;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using webCleaner.Options;

namespace webCleaner.Browser
{
    public abstract class AbstractBrowser : IBrowser
    {
        public readonly string CommonApplicationData;
        public readonly string ApplicationData;
        public AbstractBrowser()
        {
            CommonApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        }
        public abstract string ProcessName();
        public bool DeleteFiles(string path, string name)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                foreach(FileInfo fi in dir.GetFiles(name, SearchOption.AllDirectories))
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    DeleteFiles(di.FullName, name);
                    di.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }                
        }

        public void DeleteSqlData(string dbPath, string table)
        {
            if (!File.Exists(dbPath))
                return;
            Console.WriteLine(dbPath);
            SQLiteConnection con = new SQLiteConnection();
            con.ConnectionString = $"Data Source={dbPath}";
            con.Open();
            try
            {
                SQLiteCommand command = con.CreateCommand();
                command.CommandText = $"delete from {table}";
                command.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public bool CloseProcess()
        {            
            try
            {                
                var processName = ProcessName();
                var proc = Process.GetProcessesByName(processName);
                foreach (var item in proc)
                {
                    item.Kill();
                }   
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public void Delete(DeleteOption opt, bool force = false)
        {
            if (force)
                CloseProcess();
            switch (opt)
            {
                case DeleteOption.Cache:
                    deleteCache(force);
                    break;
                case DeleteOption.Cookies:
                    deleteCookies(force);
                    break;
                case DeleteOption.Downloads:
                    deleteDownloads(force);
                    break;
                case DeleteOption.FormData:
                    deleteFormData(force);
                    break;
                case DeleteOption.History:
                    deleteHistory(force);
                    break;
                case DeleteOption.Passwords:
                    deletePasswords(force);
                    break;
                default:
                    break;
            }
        }
        
        public abstract void deleteCache(bool force);
        public abstract void deleteDownloads(bool force);
        public abstract void deleteCookies(bool force);
        public abstract void deleteFormData(bool force);
        public abstract void deleteHistory(bool force);
        public abstract void deletePasswords(bool force);
    }      
}