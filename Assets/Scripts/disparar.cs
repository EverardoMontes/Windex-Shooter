using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour
{
    public GameObject disparoPrefab;
    public int velocidad;
    Vector3 targetRotation;
    Vector3 finalTarget;
    //AudioSource balaSound = GameObject.FindGameObjectWithTag("balaSonido").GetComponent<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
   
        Physics2D.IgnoreLayerCollision(9,10);
        Physics2D.IgnoreLayerCollision(10,10);
    }

    // Update is called once per frame
    void Update()
    {
        targetRotation = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(targetRotation.y, targetRotation.x) * Mathf.Rad2Deg;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Disparo();
        }
    }
    void Disparo()
    {
        var bala = Instantiate(disparoPrefab, transform.position, transform.rotation, transform.parent);
        targetRotation.z = 0;
        finalTarget = (targetRotation - transform.position).normalized;
        bala.GetComponent<Rigidbody2D>().AddForce(finalTarget * velocidad, ForceMode2D.Impulse);
    }
}
