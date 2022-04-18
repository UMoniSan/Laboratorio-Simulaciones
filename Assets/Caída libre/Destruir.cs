using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    public float vida = 8.0f;
	
	void Update () 
    {
		if(vida > 0) 
        {
			vida -= Time.deltaTime;
			if(vida <= 0) 
            {
				Destruccion();
			}
		}
		if(this.transform.position.y <= -20) 
        {
			Destruccion();
		}
	}

	void Destruccion()
    {
		Destroy(this.gameObject);
	}
}
