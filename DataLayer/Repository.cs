using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsForms.Models;

namespace DataLayer
{
    public static class Repository
    {
        //zaspisivanje postavki u datoteku
        public static void WriteInFile(object gender, object language, string path)
        {
            CreateFile(path);

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(gender);
                    writer.WriteLine(language);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //zaspisivanje najdraze momcadi u datoteku
        public static void WriteInFileFTeam(object fTeam, string path)
        {

            CreateFile(path);

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.WriteLine(fTeam);

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //zaspisivanje tih 3 igraca u datoteku
        public static void WriteInFilePlayers(List<object> players, string path)
        {
            CreateFile(path);

            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    players.ToList().ForEach(player => writer.WriteLine(player));

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //ako ne postoje datoteke, kreiraj ih
        private static void CreateFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        //dohvacanje podataka s API
        public static Task<RestResponse<T>> GetData<T>(string path)
        {
            try
            {
                var apiClient = new RestClient(path);
                return apiClient.ExecuteAsync<T>(new RestRequest());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        //dohvacanje podataka s datoteka
        public static List<T> ReadJsonData<T>(string path)
        {
            List<T> list= new List<T>();

            if (File.Exists(path))
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    //dok god ima podatka
                    while (!reader.EndOfStream)
                    {
                        var result = reader.ReadLine();
                        list = JsonConvert.DeserializeObject<List<T>>(result);
                    }
                }
            }
            return list;
        }

        //citanje config datoteke
        public static string ReadConfig(string path)
        {
            string result = null;
            try
            {
                if (File.Exists(path))
                {
                    result = File.ReadAllText(path);

                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return result;
        }

        public static void SetLanguageCulture(string language)
        {
            var culture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            
        }
    }
}