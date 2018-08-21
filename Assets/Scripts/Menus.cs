using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menus : MonoBehaviour {

    public GameObject Item_prefab;
    public GameObject canvas;
    public GameObject payment;

    public int index = 0;

    void Start()
    {
        if( SceneManager.GetActiveScene().name == "Items" )
            show_items();

        if (SceneManager.GetActiveScene().name == "Semanas")
        {
            load_payments();
            Transform a = canvas.transform.Find("Header");
            GameObject b = a.gameObject;
            Text c=b.GetComponentInChildren<Text>(false);

            Save[] lista = new Save[SaveLoad.savedGames.Count];
            SaveLoad.savedGames.CopyTo(lista);
            Save temp = lista[index];

            c.text = temp.desc;
        }

            
    }

    public void load_scene(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void show_items()
    {
        SaveLoad.load();
        Text[] ele;
        string pal;
        int i = 0;

        foreach (Save g in SaveLoad.savedGames)
        {
            GameObject item=Instantiate(Item_prefab);
            item.transform.SetParent(canvas.transform, false);
            item.transform.Translate(0, (float)(-i * (1.27)), 0);
            i=i+1;

            ele = item.GetComponentsInChildren<Text>(false);

            ele[0].text = g.desc;
            ele[1].text = (i).ToString();
            ele[2].text = g.mont.ToString() + "€";
            if (g.dur == 1)
                pal = " semana";
            else
                pal = " semanas";
            ele[3].text = g.dur.ToString() + pal;
        }
    }

    public void guardar_item()
    {

        Save item = new Save();

        item.desc = Entradas.descp;
        item.dur = Entradas.dur;
        item.mont = Entradas.value;
        item.Vinicial = Entradas.VALORINICIAL;

        if(item.desc != "" && item.dur!=0 && item.mont!=0)
        {
            SaveLoad.save(item);

            SceneManager.LoadScene("Items");
        }

    }

    public void remove_item(GameObject item)
    {
        Text[] ele = item.GetComponentsInChildren<Text>(false);
        int i= int.Parse(ele[1].text)-1;

        Destroy(item);

        SaveLoad.savedGames.RemoveAt(i);
        SaveLoad.save(null);
    }

    public void open_item(GameObject item)
    {
        Text[] ele = item.GetComponentsInChildren<Text>(false);
        int index = int.Parse(ele[1].text) - 1;

        SceneManager.LoadScene("Semanas");
    }

    public void load_payments()
    {
        Save[] lista = new Save[SaveLoad.savedGames.Count];
        SaveLoad.savedGames.CopyTo(lista);
        Transform panel = canvas.transform.Find("Panel");
        Save temp=lista[index];

        float valor = temp.Vinicial;
        for( int i=0; i< temp.dur; i++ )
        {
            GameObject pay = Instantiate(payment);
            pay.transform.SetParent(panel, false);
            pay.transform.Translate(0, (float)(-i * (20*0.0296)), 0);

            Text ele = pay.GetComponentInChildren<Text>();
            
            ele.text = "Semana " + (i+1) + ": " +  valor.ToString("0.0") +"€";

            valor = valor + temp.Vinicial;
        }
    }

    public void scrollbar()
    {
        Save[] lista = new Save[SaveLoad.savedGames.Count];
        SaveLoad.savedGames.CopyTo(lista);
        Save temp = lista[index];

        Transform panel = canvas.transform.Find("Panel");
        Scrollbar scroll = canvas.GetComponentInChildren<Scrollbar>(false);

        float travel = (float)(temp.dur * 20 * 0.0296 - 15*20 * 0.0296);

        panel.SetPositionAndRotation(new Vector3(0, scroll.value*travel, 0), Quaternion.identity);
    }
}
