using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem : object
{
    public static void SaveSlot(string path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        Debug.Log(path);
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(stream, data);
        stream.Close();

    }

    public static SaveData LoadSlot(string path)
    {
        
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;

        } else
        {
            SaveData data = new SaveData(0);
            Debug.LogError("Save file not found in " + path);
            return data;

        }
        

    }


    public static SaveData load1()
    {
        string path = Application.persistentDataPath + "/slot1.data";
        return LoadSlot(path);
    }

    public static SaveData load2()
    {
        string path = Application.persistentDataPath + "/slot2.data";
        return LoadSlot(path);
    }

    public static SaveData load3()
    {
        string path = Application.persistentDataPath + "/slot3.data";
        return LoadSlot(path);
    }

    public static void save1()
    {
        string path = Application.persistentDataPath + "/slot1.data";
        SaveSlot(path);
    }

    public static void save2()
    {
        string path = Application.persistentDataPath + "/slot2.data";
        SaveSlot(path);
    }

    public static void save3()
    {
        string path = Application.persistentDataPath + "/slot3.data";
        SaveSlot(path);
    }
}
