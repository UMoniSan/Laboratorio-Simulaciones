using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoEnPantalla : MonoBehaviour
{
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        this.GetComponent<UnityEngine.UI.Text>().text = timer.ToString();
    }
}
