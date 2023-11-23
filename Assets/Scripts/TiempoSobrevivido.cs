using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoSobrevivido : MonoBehaviour
{
    public Text tiempoFinal;
    // Start is called before the first frame update
    void Start()
    {
        cronometro.instanciar.ActUpdate();
        cronometro.instanciar.FinTiempo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
