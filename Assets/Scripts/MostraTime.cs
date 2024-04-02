using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostraTime : MonoBehaviour
{
    public TextMeshProUGUI tiempoT;

    void Start()
    {
        MostrarT();
    }

    void MostrarT()
    {
        float guardadito = PlayerPrefs.GetFloat("Tiempo");

        if(guardadito != 0f)
        {
            int T = (int)guardadito;
            tiempoT.text = "Tiempo: " + T.ToString();
        }
        else
        {
            tiempoT.text = "Noai";
        }
    }
}
