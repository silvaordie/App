using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public GameObject Item_prefab;
    public GameObject canvas;

    public List<Save> lista = null;
    void Update()
    {
        lista = SaveLoad.savedGames;
    }

    public void novo_item()
    {
        SceneManager.LoadScene("Criar");
    }

    public void menu_items()
    {
        SceneManager.LoadScene("Items");
        //SaveLoad.load();
    }


    public void show_items()
    {
        SaveLoad.load();
        foreach (Save g in SaveLoad.savedGames)
        {
            GameObject item=Instantiate(Item_prefab);
            item.transform.SetParent(canvas.transform, false);
        }
    }
}
