using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject Item_prefab;
    public List<Save> lista = SaveLoad.savedGames;
    public void novo_item()
    {
        SceneManager.LoadScene("Criar");
        lista = SaveLoad.savedGames;
    }

    public void menu_items()
    {
        SceneManager.LoadScene("Items");
        SaveLoad.load();

        SaveLoad.savedGames.ForEach(show_item);
    }

    public void guardar_item()
    {
        Save.current = new Save();

        Save.current.desc = Entradas.descp;
        Save.current.dur = Entradas.dur;
        Save.current.mont = Entradas.value;
        Save.current.Vinicial = Entradas.VALORINICIAL;
        SaveLoad.save();

        SceneManager.LoadScene("Items");
    }

    public void show_item(Save _item)
    {
        Instantiate(Item_prefab);      
    }
}
