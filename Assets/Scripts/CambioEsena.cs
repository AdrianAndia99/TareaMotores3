using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEsena : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a la que quieres cambiar

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName); // Carga la escena con el nombre especificado
    }
}