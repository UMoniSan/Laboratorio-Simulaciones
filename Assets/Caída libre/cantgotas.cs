using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cantgotas : MonoBehaviour
{
    int cgotas;
    public GameObject objeto; // Referencia a objeto de juego gota de lluvia
    private string input; // Almacena lo que escriba el usuario
    
    // Convertir entrada a int
    public void ReadStringInput(string s)
    {
        input = s;        
        int.TryParse(input, out cgotas);   
        StartCoroutine("CreateObjects");
    }

    // Crear gotas segun cantidad
    IEnumerator CreateObjects()
    {
        int masgotas = cgotas*3000;
        for (int i = 0; i < masgotas; i++)
        {
            float x = Random.Range(-16,16);
            float z = Random.Range(-5,14);
            Instantiate(objeto, new Vector3 (x,15.0f,z), Quaternion.identity); // spawn
            yield return new WaitForSeconds(1/2);
        }
    }
}