using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int valor = 1; // puntos que da este enemigo

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala") || collision.gameObject.CompareTag("Pared"))
        {
            // Buscar el cañón y sumar puntos
            FindObjectOfType<Canon>().SumarPuntos(valor);

            // Destruir enemigo
            Destroy(gameObject);
        }
    }
}