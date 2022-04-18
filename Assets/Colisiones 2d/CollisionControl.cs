// COLISION 2D
// MÓNICA SOFÍA SÁNCHEZ HENAO - 1202222

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionControl : MonoBehaviour
{
    // Objetos
    public Transform Sphere_1;
    public Transform Sphere_2;
    public GameObject Parent;
    // Atributos de las esferas
    public float ang = 0.0f;
    public float vx1 = 2f, vy1 = 2f, vx2 = -0f, vy2 = -0f;
    public float px1 = 0.0f, py1 = 0.0f, px2 = 4f, py2 = 4f;
    public float m1 = 1.0f, m2 = 1.0f;
    public float e = 1.0f;
    public float radio_s = 0.5f;

    // ----------------------------------------------------------------------------------------

    void Start()
    {
        // Obtener esferas
        Sphere_1 = this.gameObject.transform.GetChild(0);
        Sphere_2 = this.gameObject.transform.GetChild(1);

        // Otorgar nuevas posiciones y velocidades a las esferas
        Sphere_1.position = new Vector3(px1, py1, 0);
        Sphere_2.position = new Vector3(px2, py2, 0);
        Sphere_1.GetComponent<Sphere>().setVelocidad(new Vector3(vx1, vy1, 0));
        Sphere_2.GetComponent<Sphere>().setVelocidad(new Vector3(vx2, vy2, 0));
    }

    // ----------------------------------------------------------------------------------------

    void Update()
    {

        // Datos para recalcular las velocidades
        float aux = 1.0f / (m1 + m2);
        float vp1, vn1, vp2, vn2;
        // distancia entre esferas
        float distancia = Vector3.Distance(Sphere_1.position, Sphere_2.position);

        // Obtener velocidad actual de las esferas
        Vector3 vel1 = Sphere_1.GetComponent<Sphere>().getVelocidad();
        Vector3 vel2 = Sphere_2.GetComponent<Sphere>().getVelocidad();

        // -------------------------------------------------------------------------

        // Recalcular velocidades
        if (distancia <= 2.0 * radio_s)
        {
            // Calcular ángulo del eje de acción al momento de la colisión
            ang = Mathf.Atan2(py1 - py2, px1 - px2);
            print("Angulo de colision: " + Mathf.Atan2(py1 - py2, px1 - px2));

            // Rotar eje de referencia

            // esfera 1
            vp1 = (vel1.x * Mathf.Cos(ang)) + (vel1.y * Mathf.Sin(ang));
            vn1 = -(vel1.x * Mathf.Sin(ang)) + (vel1.y * Mathf.Cos(ang));
            // esfera 2
            vp2 = (vel2.x * Mathf.Cos(ang)) + (vel2.y * Mathf.Sin(ang));
            vn2 = -(vel2.x * Mathf.Sin(ang)) + (vel2.y * Mathf.Cos(ang));

            // -------------------------------------------------------------------------

            // Recalcular velocidades post-colisión
            float vp1_new = ((m1 - (e * m2)) * vp1 * aux) + (((1.0f + e) * m2) * vp2 * aux);
            float vp2_new = (((1.0f + e) * m1) * vp1 * aux) + ((m2 - (e * m1)) * vp2 * aux);

            // -------------------------------------------------------------------------

            // Rotación inversa del eje de referencia
            // esfera 1
            vx1 = (vp1_new * Mathf.Cos(ang)) - (vn1 * Mathf.Sin(ang));
            vy1 = (vp1_new * Mathf.Sin(ang)) + (vn1 * Mathf.Cos(ang));
            // esfera 2
            vx2 = (vp2_new * Mathf.Cos(ang)) - (vn2 * Mathf.Sin(ang));
            vy2 = (vp2_new * Mathf.Sin(ang)) + (vn2 * Mathf.Cos(ang));

            // -------------------------------------------------------------------------

            //// Recalcular PARA CHOQUE HORIZONTAL ÚNICAMENTE
            //vx1 = (m1 - e * m2) * vel1.x * aux + (1.0f + e) * m2 * vel2.x * aux;
            //vx2 = (1.0f + e) * m1 * vel1.x * aux + (m2 - e * m1) * vel2.x * aux;
            //vy1 = (m1 - e * m2) * vel1.y * aux + (1.0f + e) * m2 * vel2.y * aux;
            //vy2 = (1.0f + e) * m1 * vel1.y * aux + (m2 - e * m1) * vel2.y * aux;


            // Otorgar nuevas velocidades
            Sphere_1.GetComponent<Sphere>().setVelocidad(new Vector3(vx1, vy1, 0));
            Sphere_2.GetComponent<Sphere>().setVelocidad(new Vector3(vx2, vy2, 0));

            // Imprimir datos
            print("D: " + distancia);
            print("V1: " + vx1 + ", " + vy1);
            print("V2: " + vx2 + ", " + vy2);
        }

        // -------------------------------------------------------------------------

        // Mover esferas

        // Recalcular posiciones
        // eje x
        px1 = px1 + Time.deltaTime * vx1;
        px2 = px2 + Time.deltaTime * vx2;
        // eje y
        py1 = py1 + Time.deltaTime * vy1;
        py2 = py2 + Time.deltaTime * vy2;

        // Otorgar nuevas posiciones
        Sphere_1.position = new Vector3(px1, py1, 0);
        Sphere_2.position = new Vector3(px2, py2, 0);
    }
}