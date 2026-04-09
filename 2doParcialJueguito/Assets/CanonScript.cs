using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Canon : MonoBehaviour
{
    public GameObject balaPrefab;
    public Transform puntoSalida;
    public float velocidadRotacion = 50f;
    public float fuerzaBala = 10f;
    public float incremento = 2f;

    public TextMeshProUGUI textoFuerza;
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoTiros;

    public int tirosMaximos = 5;
    private int tirosRestantes;
    private int puntaje = 0;

    public int puntajeVictoria = 50; 
    void Start()
    {
        textoFuerza.text = "Fuerza aplicada: " + fuerzaBala;
        textoPuntaje.text = "Puntos: " + puntaje;

        tirosRestantes = tirosMaximos;
        textoTiros.text = "Tiros restantes: " + tirosRestantes;

    }

    void Update()
    {
      
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Rotate(Vector3.forward * velocidadRotacion * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Rotate(Vector3.back * velocidadRotacion * Time.deltaTime);

       
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fuerzaBala += incremento;
            textoFuerza.text = "Fuerza aplicada: " + fuerzaBala;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fuerzaBala -= incremento;
            if (fuerzaBala < 0) fuerzaBala = 0;
            textoFuerza.text = "Fuerza aplicada: " + fuerzaBala;
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && tirosRestantes > 0)
        {
            Disparar();
            tirosRestantes--;
            textoTiros.text = "Tiros restantes: " + tirosRestantes;

            if (tirosRestantes == 0)
            {
                Invoke("ReiniciarJuego", 2f);
            }
        }
    }

    void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoSalida.position, puntoSalida.rotation);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(puntoSalida.up * fuerzaBala, ForceMode2D.Impulse);
    }

    public void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
        textoPuntaje.text = "Puntos: " + puntaje;

      
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}