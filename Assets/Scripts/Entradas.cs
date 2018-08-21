using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Entradas : MonoBehaviour {

    public InputField descricao;
    public InputField montante;
    public InputField duracao;

    public Text VINICIAL;
    public Text VFINAL;

    static public string descp ;
    static public float value ;
    static public float dur;
    static public float VALORINICIAL = 0;

    private void Start()
    {
        VINICIAL.text = "";
        VFINAL.text = "";
        descp = "";
        value = 0;
        dur = 0;
        VALORINICIAL = 0;
    }


    public void calc_values()
    {
        float VALORFINAL=0;

        descp = descricao.text;
        value = float.Parse(montante.text);
        dur = float.Parse(duracao.text);

        VALORINICIAL = (value * 2) / (dur * (dur + 1));
        VALORFINAL = VALORINICIAL * dur;

        VINICIAL.text = VALORINICIAL.ToString("0.0") + "€";
        VFINAL.text = VALORFINAL.ToString("0.0") + "€";
    }

}
