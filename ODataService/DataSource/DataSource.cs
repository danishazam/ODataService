using Newtonsoft.Json;
using ODataService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ODataService.DataSource
{
    public class DataSource
    {
        private static DataSource instance = null;
        public static DataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataSource();
                }
                return instance;
            }
        }
        public List<Setting> Settings { get; set; }
        private DataSource()
        {
            this.Reset();
            this.Initialize();
        }
        public void Reset()
        {
            this.Settings = new List<Setting>();
        }

        public void Initialize()
        {
            string json = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}\\Setting.json");
            this.Settings = JsonConvert.DeserializeObject<List<Setting>>(json);
        }
    }
}