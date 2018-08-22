using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{

    public static Save[] savedGames = new Save[20];
    public static int position = 0;

    //it's static so we can call it from anywhere
    public static void save(Save item)
    {
        if(item!=null)
        {
            savedGames[position] = item;
            position = position + 1;
        }

        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, SaveLoad.savedGames);
        file.Close();
    }

    public static void load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGames = (Save[])bf.Deserialize(file);
            file.Close();
        }
    }

    public static void remove(int inx)
    {
        for (int id = inx; id < 20; id = id + 1)
        {
            if (id != 19)
                SaveLoad.savedGames[id] = SaveLoad.savedGames[id + 1];
            else
                SaveLoad.savedGames[id] = null;
        }

        SaveLoad.save(null);
    }

}