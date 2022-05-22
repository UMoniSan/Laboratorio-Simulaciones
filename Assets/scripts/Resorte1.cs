using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte1 : MonoBehaviour
{
  public float masa, miu, k, distancia, velInicial;
  private string input;
    
  // Convertir entrada a float
  public void ReadMasa(string s)
  {
    input = s;
    Debug.Log(input);
    float.TryParse(input, out masa);
    Debug.Log(masa);
  }
  public void ReadMiu(string s)
  {
    input = s;      
    Debug.Log(input);  
    float.TryParse(input, out miu);
    Debug.Log(miu);
  }
  public void ReadK(string s)
  {
    input = s;        
    Debug.Log(input);
    float.TryParse(input, out k);
    Debug.Log(k);
  }
  public void ReadDist(string s)
  {
    input = s;
    Debug.Log(input);
    float.TryParse(input, out distancia);
    Debug.Log(distancia);
  }
  public void ReadVelIn(string s)
  {
    input = s;
    Debug.Log(input);
    float.TryParse(input, out velInicial);
    Debug.Log(velInicial);
  }

  // Update is called once per frame
  void Update()
  {
    this.transform.position = new Vector3(distancia, this.transform.position.y, this.transform.position.z);
    distancia = (velInicial * Time.deltaTime) + distancia;
    velInicial = velocidad(distancia, velInicial);
  }
  float velocidad(float x, float velocidad)
  {
    float a, b, k1, k2, k3, k4, newVelocidad;
    a = (-miu / masa);
    b = (k / masa);
    k1 = ((a * velocidad) - (b * x)) * Time.deltaTime;
    k2 = ((a * (velocidad + (k1 / 2))) - (b * x)) * Time.deltaTime;
    k3 = ((a * (velocidad + (k2 / 2))) - (b * x)) * Time.deltaTime;
    k4 = ((a * (velocidad + k3)) - (b * x)) * Time.deltaTime;
    newVelocidad = velocidad + (k1 / 6) + (k2 / 3) + (k3 / 3) + (k4 / 6);
    return newVelocidad;
  }

}
