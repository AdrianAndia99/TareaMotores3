using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int puntosGanados = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Obtener el componente del sistema de puntos
            SistemaPuntos sistemaPuntos = collision.gameObject.GetComponent<SistemaPuntos>();
            if (sistemaPuntos != null)
            {
                // Aumentar el puntaje cuando el jugador colisiona con la moneda
                sistemaPuntos.AumentarPuntaje(puntosGanados);
            }

            // Destruir la moneda después de ser recogida
            Destroy(gameObject);
        }
    }
}