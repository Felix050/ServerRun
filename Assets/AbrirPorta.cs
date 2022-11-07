using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPorta : MonoBehaviour
{

    public GameObject mao;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E)){
            mao.GetComponent<Animator>().SetBool("MaoAbrindoPorta", true);
        }

    }
}
