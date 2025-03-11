using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HanoiTower
{
    [Serializable]
    public class SerializedObject
    {
        private string APP_PATH = AppDomain.CurrentDomain.BaseDirectory;

        private Dictionary<string, object> _values;

        public SerializedObject AddValue(string name, object value)
        {
            if (_values == null)
            {
                _values = new Dictionary<string, object>();
            }

            _values.Add(name, value);
            return this;
        }

        public T GetValue<T>(string name)
        {
            if (HasKey(name) == true)
            {
                return (T)_values[name];
            }
            return default;
        }

        public bool HasKey(string name)
        {
            return _values != null ? _values.ContainsKey(name) : false;
        }

        public bool Corrupted()
        {
            return _values == null || HasKey("Error");
        }

        public void SaveFile(string fileName)
        {
            if (Directory.Exists($"{APP_PATH}/Save/") == false)
            {
                Directory.CreateDirectory($"{APP_PATH}/Save/");
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create($"{APP_PATH}/Save/{fileName}");
            formatter.Serialize(file, this);
            file.Close();
        }

        public void LoadFile(string fileName)
        {
            if (File.Exists($"{APP_PATH}/Save/{fileName}") == false)
            {
                AddValue("Error", 0);
                return;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.OpenRead($"{APP_PATH}/Save/{fileName}");
            SerializedObject serializedObject = (SerializedObject)formatter.Deserialize(file);
            file.Close();

            _values = serializedObject._values;

            if (_values == null)
            {
                _values = new Dictionary<string, object>();
            }
        }
    }
}
