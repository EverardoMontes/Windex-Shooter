using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class controladorBotiquin : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private Transform[] items;
    [SerializeField] private float tiempoSpawn;
    [SerializeField] private int enemigosMaximos;
    public int cantidadEnemigos;
    public float contador;
    public float segundosParaDividirSpawn;
    public static controladorBotiquin instance;


    private float tiempoSiguienteEnemigo;
    public void Awake()
    {
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        segundosParaDividirSpawn = 20;
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (contador >= segundosParaDividirSpawn)
        {
            contador = 0;
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
        int numeroEnemigo = Random.Range(0, items.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(items[numeroEnemigo], posicionAleatoria, Quaternion.identity);
    }
    public void Destruir()
    {
        Destroy(gameObject);
    }
}
