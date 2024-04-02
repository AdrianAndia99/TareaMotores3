using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MostrarPuntaje : MonoBehaviour
{
    public SistemaPuntos punto;
    public TextMeshProUGUI textoPuntaje;

    void Start()
    {
        SistemaPuntos.OnPuntajeActualizado += ActualizarTextoPuntaje;

        ActualizarTextoPuntaje(punto.puntaje);
    }

    void ActualizarTextoPuntaje(int nuevoPuntaje)
    {
        // Actualizar el texto con el nuevo puntaje
        textoPuntaje.text = "Puntaje: " + nuevoPuntaje.ToString();
    }

    void OnDestroy()
    {
        SistemaPuntos.OnPuntajeActualizado -= ActualizarTextoPuntaje;
    }
}