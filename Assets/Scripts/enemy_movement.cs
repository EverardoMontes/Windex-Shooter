using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class enemy_movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Transform objetivo;
    private GameObject personaje;
    private NavMeshAgent navMeshAgent;
    private float velocidadNormal;
    public int vida;
    public Color colorDaño;
    private SpriteRenderer render;
    public AudioClip dañoSound;
    public AudioClip muerteSound;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        objetivo = GameObject.Find("Personaje").transform;
        personaje = GameObject.Find("Personaje");
        navMeshAgent.enabled = true;
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.speed = speed;
        velocidadNormal = navMeshAgent.speed;
        render = GetComponent<SpriteRenderer>();
        vida = 50;

    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            puntaje.instanciar.sumarPuntosEnemigo();
            //audio.PlayOneShot(muerteSound);
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        navMeshAgent.SetDestination(objetivo.position);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            navMeshAgent.speed = velocidadNormal;
            return;
        }
        else if (collision.gameObject.CompareTag("Player")) {
            navMeshAgent.speed = 0f;
            Invoke("reAvanzar", 1);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balas"))
        {
            
            render.color = colorDaño;
            Debug.Log("se golpeó un enemigo");
            vida -= 25;
            GetComponent<AudioSource>().PlayOneShot(dañoSound);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balas"))
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

    //private void OnCollisionExit2D(Collision2D collision)
    //{   
    //    if(collision.gameObject.CompareTag("Enemigo")) {
    //        Debug.Log("choqué con un enemigo");
    //        reAvanzar();
    //    }
    //    else
    //    {
    //    Invoke("reAvanzar", 1);
    //    }

    //}
    private void reAvanzar()
    {
        navMeshAgent.speed = velocidadNormal;

    }
    // MOMENTO QUE SOY LENTO, EL DAÑO QUE LE HACE AL JUGADOR VA EN UN SCRIPT DIFERENTE AL DE MOVIMIENTO
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    GameObject playerRb = collision.player;
    //    if (Collision2D.ReferenceEquals(enemyRb, playerRb))
    //    { 
    //        Collision2D.refer
    //    colorPlayer.color = new Color(250,00,00);
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{

    //    colorPlayer.color = new Color(00, 00, 00);
    //}

}
