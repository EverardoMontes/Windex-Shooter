using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SistemaVidaPersonaje : MonoBehaviour
{
    [SerializeField] public float salud;
    [SerializeField] private float saludMaxima;
    [SerializeField] public barraDeVida barraDeVida;
    public Color colorDaño;
    private SpriteRenderer render;
    private GameObject reiniciar;
    private TextMeshProUGUI gameOver;
    private GameObject salir;
    public static SistemaVidaPersonaje instance;
    // Start is called before the first frame update
    void Start()
    {
        
        gameOver = GameObject.Find("Moriste").GetComponent<TextMeshProUGUI>();
        gameOver.enabled = false;
        reiniciar = GameObject.Find("Reiniciar");
        reiniciar.gameObject.SetActive(false);
        reiniciar.gameObject.CompareTag("tiempo");
        salir = GameObject.Find("Salir");
        salir.gameObject.SetActive(false);
        render = GetComponent<SpriteRenderer>();
        salud = saludMaxima;
        barraDeVida.InicializarBarraDeVida(salud);
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.CambiarVidaActual(salud);

        if (salud == 0)
        {
            Muerte();
            
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (salud < 0)
        {
            Muerte();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void Muerte()
    {
        cronometro.instanciar.FinTiempo();
        gameOver.enabled = true;
        reiniciar.gameObject.SetActive(true);
        salir.gameObject.SetActive(true);
        controladorEnemigos.instance.Destruir();
        controladorBotiquin.instance.Destruir();
        //Debug.Log("morido");
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (salud != 0)
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                salud -= 25;
                barraDeVida.CambiarVidaActual(salud);
                return;
            }
            if (collision.gameObject.CompareTag("botiquin"))
            {
                salud += 20;
                barraDeVida.CambiarVidaActual(salud);
                //Destroy(gameObject);
                return;
            }
        }
        else
        {
            Debug.Log("que");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("me ha hecho daño");
            salud -= (25 * Time.deltaTime);
            barraDeVida.CambiarVidaActual(salud);
            
            render.color = colorDaño;
            return;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Invoke("regresarColor", 1);
            return;
        }
    }
    private void regresarColor()
    {
        render.color = new Color(255, 255, 255);
        return;
    }
}
