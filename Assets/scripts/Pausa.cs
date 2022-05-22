using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{

    void Awake()
    {
        Time.timeScale = 0f;
        Debug.Log("Pausado");
    }

    public void Inicio()
    {
        Time.timeScale = 1f;
        Debug.Log("Despausado");
    }

    public void InicioColision()
    {        
        CollisionControl collision;
        collision = GameObject.Find("Colision").GetComponent<CollisionControl>();
        collision.InicioLab();
    }
    
    public void InicioResorte()
    {        
        Resorte res;
        res = GameObject.Find("Cube").GetComponent<Resorte>();
        //res.a();
    }
}
