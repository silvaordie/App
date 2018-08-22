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

            Save temp = SaveLoad.savedGames[index];

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

        for(int i=0; i<20; i=i+1)
        {
            if(SaveLoad.savedGames[i]!= null)
            {
                GameObject item = Instantiate(Item_prefab);
                item.transform.SetParent(canvas.transform, false);
                item.transform.Translate(0, (float)(-i * (1.27)), 0);

                ele = item.GetComponentsInChildren<Text>(false);

                ele[0].text = SaveLoad.savedGames[i].desc;
                ele[1].text = (i + 1).ToString();
                ele[2].text = SaveLoad.savedGames[i].mont.ToString() + "€";
                if (SaveLoad.savedGames[i].dur == 1)
                    pal = " semana";
                else
                    pal = " semanas";
                ele[3].text = SaveLoad.savedGames[i].dur.ToString() + pal;
            }

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
        SaveLoad.remove(i);
    }

    public void open_item(GameObject item)
    {
        Text[] ele = item.GetComponentsInChildren<Text>(false);
        int index = int.Parse(ele[1].text) - 1;

        SceneManager.LoadScene("Semanas");
    }

    public void load_payments()
    {
        Transform panel = canvas.transform.Find("Panel");
        Save temp = SaveLoad.savedGames[index];

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
        Save temp = SaveLoad.savedGames[index];

        Transform panel = canvas.transform.Find("Panel");
        Scrollbar scroll = canvas.GetComponentInChildren<Scrollbar>(false);

        float travel = (float)(temp.dur * 20 * 0.0296 - 15*20 * 0.0296);

        panel.SetPositionAndRotation(new Vector3(0, scroll.value*travel, 0), Quaternion.identity);
    }
}
