using Newtonsoft.Json;
using System;
using System.IO;

namespace HanoiTower
{
    public class Configs
    {
        private string APP_PATH = AppDomain.CurrentDomain.BaseDirectory;

        public int ResolutionBoxIndex { get; set; }
        public int DiskCount { get; set; }
        public int Speed { get; set; }

        private string _fileName;

        public Configs(string fileName)
        {
            _fileName = fileName;
        }

        public void SaveFile()
        {
            string jsonString = JsonConvert.SerializeObject(this);
            File.WriteAllText($"{APP_PATH}/{_fileName}", jsonString);
        }

        public bool LoadFile()
        {
            if (File.Exists($"{APP_PATH}/{_fileName}"))
            {
                string jsonString = File.ReadAllText($"{APP_PATH}/{_fileName}");
                Configs configs = JsonConvert.DeserializeObject<Configs>(jsonString);

                if (configs != null)
                {
                    ResolutionBoxIndex = configs.ResolutionBoxIndex;
                    DiskCount = configs.DiskCount;
                    Speed = configs.Speed;
                    return true;
                }
            }

            return false;
        }
    }
}
