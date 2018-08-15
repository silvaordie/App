using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Entradas : MonoBehaviour {

    public InputField descricao;
    public InputField montante;
    public InputField duracao;

    public Text VINICIAL;
    public Text VFINAL;

    static public string descp;
    static public float value;
    static public float dur;

    static public float VALORINICIAL;
    public float VALORFINAL;

    private void Start()
    {
        VINICIAL.text = "";
        VFINAL.text = "";
        dur = 0;
        value = 0;
        descp = "";
    }

    // Update is called once per frame
    public void get_entradas() {

        descp = descricao.text;

        value = float.Parse(montante.text);
        dur = float.Parse(duracao.text);

    }

    public void calc_values()
    {

        VALORINICIAL = (value * 2) / (dur * (dur + 1));
        VALORFINAL = VALORINICIAL * dur;

        VINICIAL.text = VALORINICIAL.ToString("0.0") + "€";
        VFINAL.text = VALORFINAL.ToString("0.0") + "€";
    }


}
