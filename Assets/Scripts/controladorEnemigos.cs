using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class controladorEnemigos : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private Transform[] enemigos;
    [SerializeField] private float tiempoSpawn;
    [SerializeField] private int enemigosMaximos;
    public int cantidadEnemigos;
    public float contador;
    public float segundosParaDividirSpawn;
    public static controladorEnemigos instance;


    private float tiempoSiguienteEnemigo;
    public void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        cronometro.instanciar.iniciarTiempo();
        contador = 0;
        segundosParaDividirSpawn = 35;
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(contador >= segundosParaDividirSpawn)
        {
            contador = 0;
            tiempoSpawn /= 2;
        }
        if (cantidadEnemigos <= enemigosMaximos)
        {
             tiempoSiguienteEnemigo += Time.deltaTime;
            if (tiempoSiguienteEnemigo > tiempoSpawn)
            {
                tiempoSiguienteEnemigo = 0;
                cantidadEnemigos += 1;
                CrearEnemigo();
                // crear enmemigo
            }
        }
        else
        {
            cantidadEnemigos = 0;
        }
        contador += Time.deltaTime;
    }

    private void CrearEnemigo()
    {
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
        Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }
}
