using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReiniciarNuestroJuego()
    {
        cronometro.instanciar.destruir();
        SceneManager.LoadScene("Nivel de prueba");
    }

    // Update is called once per frame
    public void Salir()
    {
        Application.Quit();
    }
}
