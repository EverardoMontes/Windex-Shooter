using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voltearAVerMira : MonoBehaviour
{
    private Vector2 objetivo;
    private Transform mira;
    private Vector2 puntoMenosX;
    private Vector2 puntoX;
    private float distanciaMenosX;
    private float distanciaX;
    private Transform personaje;
    private Transform puntoReferencia1;
    private Transform puntoReferencia2;
    [SerializeField] private Camera camara;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.Find("Personaje").transform;
        puntoReferencia1 = GameObject.Find("puntoReferenciaMira1").transform;
        puntoReferencia2 = GameObject.Find("puntoReferenciaMira2").transform;
        puntoX = GameObject.Find("puntoReferenciaMira1").transform.position;
        puntoMenosX = GameObject.Find("puntoReferenciaMira2").transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        objetivo = GameObject.Find("Mira").transform.position;
        distanciaMenosX = Vector2.Distance(puntoMenosX, objetivo);
        //Debug.Log("La distancia de la reticula con el punto izquierdo es "+distanciaMenosX);
        distanciaX = Vector2.Distance(puntoX,objetivo);
        //Debug.Log("La distancia de la reticula con el punto derecho es " + distanciaX);
        if (distanciaMenosX > distanciaX)
        {
            puntoReferencia1.localScale = new Vector2(1, 1);
            puntoReferencia2.localScale = new Vector2(1, 1);
            personaje.localScale = new Vector2(1, 1);
        }
        else if (distanciaMenosX < distanciaX)
        {
            puntoReferencia1.localScale = new Vector2(-1, 1);
            puntoReferencia2.localScale = new Vector2(-1, 1);
            personaje.localScale = new Vector2(-1, 1);

        }
    }
    void medirDistancia()
    {

    }

}
