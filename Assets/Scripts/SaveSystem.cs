using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string path = Application.persistentDataPath + "/game.data";
    
    public static void SaveGameData (GameManager GM)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(GM);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGame ()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }   
}
