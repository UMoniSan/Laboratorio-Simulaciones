using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caida_Lluvia : MonoBehaviour
{
    public float h = 15.0f; // altura
    public float v = 0.0f; // velocidad
    public float g = 70.0f; // gravedad

    
    public bool inWindZone = false;  // booleano para verificar si está en la zona de viento
    public GameObject windZone; // zona de viento (objeto de juego)

    Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        v = v - g * Time.deltaTime; // VELOCIDAD
        //Debug.Log("velocidad: " + v);
        h = h + v * Time.deltaTime; // ALTURA
        //Debug.Log("altura: " + h);
        transform.position = new Vector3(transform.position.x, h, 0);
    }
    
    // Si se encuentra con el area de viento, cambia el bool a true
    // y le afecta la fuerza

    private void FixedUpdate()
    {
       if(inWindZone) {
           rb.AddForce(windZone.GetComponent<Viento>().direccion * windZone.GetComponent<Viento>().fuerza);
       }
    }

    void OnTriggerEnter(Collider coll) {
       if(coll.gameObject.tag == "windArea") {
           windZone = coll.gameObject;
           inWindZone = true;
       }
    }

    void OnTriggerExit(Collider coll) {
       if(coll.gameObject.tag == "windArea") {
           inWindZone = false;
       }
    }

    
}
