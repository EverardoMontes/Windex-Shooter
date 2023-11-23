using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puntaje : MonoBehaviour
{
    public static puntaje instanciar;
    public Text puntos;
    private float points;
    // Start is called before the first frame update

    public void Awake()
    {
        points = 0;
        instanciar = this;
        puntos = GameObject.Find("Puntos").GetComponent<Text>();
    }
    void Start()
    {
        puntos.text = "Puntos: 0";
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = "Puntos: " + points.ToString();
    }

    public void sumarPuntosEnemigo()
    {
        points += 5;
    }
}
