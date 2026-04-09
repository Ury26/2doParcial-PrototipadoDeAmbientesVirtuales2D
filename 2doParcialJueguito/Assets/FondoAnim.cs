using UnityEngine;
using System.Collections;

public class FondoLoopSprites : MonoBehaviour
{
    public SpriteRenderer fondoRenderer; // El SpriteRenderer del objeto de fondo
    public Sprite[] fondos;              // Array con tus 3 sprites
    public float tiempoCambio = 3f;      // Cada cuántos segundos cambia

    private int indiceActual = 0;

    void Start()
    {
        StartCoroutine(CambiarFondos());
    }

    IEnumerator CambiarFondos()
    {
        while (true)
        {
            // Cambiar el sprite del fondo
            fondoRenderer.sprite = fondos[indiceActual];

            // Avanzar al siguiente
            indiceActual++;
            if (indiceActual >= fondos.Length)
                indiceActual = 0;

            // Esperar antes de cambiar otra vez
            yield return new WaitForSeconds(tiempoCambio);
        }
    }
}