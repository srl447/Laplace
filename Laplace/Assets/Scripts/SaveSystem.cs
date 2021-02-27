using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    /*
     * TODO: Multiple Save Files
     *   probably require an int and add it to the file path
     * TODO: Implement this into Koi-Koi Scene
     *   it'd need to save score when I get there, but progress Index can be used for rounds
     */
    public static void SaveData(GameManager game)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Establishes a file path based on operating system
        string path = Application.persistentDataPath + "/player.file";

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            try
            {
                Data data = new Data(game);

                formatter.Serialize(stream, data);
            }
            catch(Exception e)
            {
                Debug.LogError("Saving Failed at " + path);
                throw e;
            }
        }
    }

    //For Loading Game Data
    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/player.file";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                try
                {
                    Data data = formatter.Deserialize(stream) as Data;

                    return data;
                }
                catch (Exception e)
                {
                    Debug.LogError("Loading Failed at " + path);
                    throw e;
                }
            }

        }
        else
        {
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }
}
