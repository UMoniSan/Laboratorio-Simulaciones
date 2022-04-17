using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resorte : MonoBehaviour
{
  public float masa;
  public float miu;
  public float k;
  public float distancia;
  public float velInicial;
  // Start is called before the first frame update
  void Start()
  {

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
