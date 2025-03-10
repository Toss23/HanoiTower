using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public struct SerializedObject
{
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
        return HasKey("Error");
    }

    public void SaveFile(string fileName)
    {
        if (Directory.Exists($"{Application.persistentDataPath}/Save/") == false)
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/Save/");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create($"{Application.persistentDataPath}/Save/{fileName}");
        formatter.Serialize(file, this);
        file.Close();
    }

    public void LoadFile(string fileName)
    {
        if (File.Exists($"{Application.persistentDataPath}/Save/{fileName}") == false)
        {
            AddValue("Error", 0);
            return;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.OpenRead($"{Application.persistentDataPath}/Save/{fileName}");
        SerializedObject serializedObject = (SerializedObject)formatter.Deserialize(file);
        file.Close();

        _values = serializedObject._values;

        if (_values == null)
        {
            _values = new Dictionary<string, object>();
        }

        if (CheckHashSum() == false)
        {
            AddValue("Error", 0);
        }
    }

    public bool CheckHashSum()
    {
        return true;
    }
}