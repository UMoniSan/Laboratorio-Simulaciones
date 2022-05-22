using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour
{
  // bool gameIsPaused = true;
  // public float masa2, miu2, k2, distancia2, velInicial2;
  // float masa,miu,k,distancia,velInicial;
  // private string input;
    
  // // Convertir entrada a float
  // public void ReadMasa(string s)
  // {
  //   input = s;
  //   Debug.Log(input);
  //   float.TryParse(input, out masa2);
  //   Debug.Log(masa2);
  // }
  // public void ReadMiu(string s)
  // {
  //   input = s;      
  //   Debug.Log(input);  
  //   float.TryParse(input, out miu2);
  //   Debug.Log(miu2);
  // }
  // public void ReadK(string s)
  // {
  //   input = s;        
  //   Debug.Log(input);
  //   float.TryParse(input, out k2);
  //   Debug.Log(k2);
  // }
  // public void ReadDist(string s)
  // {
  //   input = s;
  //   Debug.Log(input);
  //   float.TryParse(input, out distancia2);
  //   Debug.Log(distancia2);
  // }
  // public void ReadVelIn(string s)
  // {
  //   input = s;
  //   Debug.Log(input);
  //   float.TryParse(input, out velInicial2);
  //   Debug.Log(velInicial2);
  // }

  // public void a()
  // {
  //   gameIsPaused = false;
  // }

  // // Update is called once per frame
  // void Update()
  // {
  //   Debug.Log(gameIsPaused);
  //   if (gameIsPaused == false)
  //   {
  //     Debug.Log("a");
  //     this.transform.position = new Vector3(distancia, this.transform.position.y, this.transform.position.z);
  //     distancia = (velInicial * Time.deltaTime) + distancia;
  //     velInicial = velocidad(distancia, velInicial);
  //   }    
  // }

  // float velocidad(float x, float velocidad)
  // {
  //   float a, b, k1, k2, k3, k4, newVelocidad;
  //   a = (-miu / masa);
  //   b = (k / masa);
  //   k1 = ((a * velocidad) - (b * x)) * Time.deltaTime;
  //   k2 = ((a * (velocidad + (k1 / 2))) - (b * x)) * Time.deltaTime;
  //   k3 = ((a * (velocidad + (k2 / 2))) - (b * x)) * Time.deltaTime;
  //   k4 = ((a * (velocidad + k3)) - (b * x)) * Time.deltaTime;
  //   newVelocidad = velocidad + (k1 / 6) + (k2 / 3) + (k3 / 3) + (k4 / 6);
  //   return newVelocidad;
  // }

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
