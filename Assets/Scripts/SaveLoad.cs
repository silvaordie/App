﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad
{

    public static List<Save> savedGames = new List<Save>();

    //it's static so we can call it from anywhere
    public static void save()
    {
        SaveLoad.savedGames.Add(Save.current);
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
            SaveLoad.savedGames = (List<Save>)bf.Deserialize(file);
            file.Close();
        }
    }
}