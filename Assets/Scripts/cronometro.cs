using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class cronometro : MonoBehaviour
{
    public static cronometro instanciar;
    public Text timer;
    private TimeSpan tiempoCrono;
    private bool timerBool;
    private float tiempoTrans;
    private float tiempoFinal;

    public void Awake()
    {
        instanciar = this;
        timer = GameObject.Find("Tiempo").GetComponent<Text>();
    }

    private void Start()
    {
        timer.text = "Tiempo: 00:00:00";
        timerBool = false;
    }

    public void iniciarTiempo()
    {
        //Debug.Log("inició el cronometro");
        timerBool = true;
        tiempoTrans = 0F;
        StartCoroutine(ActUpdate());
    }
    public void FinTiempo()
    {
        //Debug.Log("terminó el cronometro");
        timerBool = false;

    }

    public IEnumerator ActUpdate()
    {
        while (timerBool)
        {
            tiempoTrans += Time.deltaTime;
            tiempoCrono = TimeSpan.FromSeconds(tiempoTrans);
            string tiempoCronoStr = "Tiempo: " + tiempoCrono.ToString("mm':'ss':'ff");
            timer.text = tiempoCronoStr;
            //Debug.Log("cambió el cronometro");



            yield return null;
        }
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

    //public Text texto;
    //private int contador = 0;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //private void Awake()
    //{
    //    InvokeRepeating("crono", 0f, 1f);
    //}
    //// Update is called once per frame
    //private void crono()
    //{
    //    contador++;
    //    texto.text = contador.ToString();
    //}
}
