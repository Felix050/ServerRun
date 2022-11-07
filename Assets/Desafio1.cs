using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desafio1 : MonoBehaviour
{

    public GameObject FloorDesafio;

    public bool DesafioCerto = false;

    void OnTriggerEnter (Collider _col)
    {
        if (_col.gameObject.CompareTag ("Objetos"))
        {
            DesafioCerto = true;
        }
    }

    void OnTriggerExit (Collider _col)
    {
        if (_col.gameObject.CompareTag ("Objetos"))
        {
            DesafioCerto = false;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DesafioCerto == true)
        {
            FloorDesafio.GetComponent<Renderer>().material.color = Color.green;
        }
        if (DesafioCerto == false)
        {
            FloorDesafio.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
