using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta2simples : MonoBehaviour {

	//public Animator _animator;

	public GameObject porta2;


	private bool entrou = false;
	private bool primer = false;
	private bool _estanaporta = false;
	private bool _naoestaporta = false;
 
	


	void OnTriggerEnter (Collider _col)
    {
        if (_col.gameObject.CompareTag ("Player"))
        {
            _estanaporta = true;
        }
    }

    void OnTriggerExit (Collider _col)
    {
        if (_col.gameObject.CompareTag ("Player"))
        {
            _estanaporta = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

        //Botao para subir
        //se não está descendo
        if (_naoestaporta == false)
        {
            //pode apertar e apertar a tecla E executa o codigo
            if (_estanaporta && Input.GetKey(KeyCode.E))
            {  
                porta2.GetComponent<Animator>().SetBool("AbrirPorta2", true);
                //inicia o tempo de subida
                StartCoroutine(Temp());

                entrou =  true; 
                primer = true;
            }
        }

    
        //Botao para descer
        //Se feito o primeiro uso
        if (primer)
        {
            // se não esta subindo
            if(entrou == false)
            {
                //pode apertar e apertar a tecla E executa o codigo
                if (_estanaporta && Input.GetKey(KeyCode.E))
                {
                    porta2.GetComponent<Animator>().SetBool("AbrirPorta2", false);
        
                    //inicia o tempo de descida
                    StartCoroutine(Temp2());
                }
            }
            
        }
    }


    IEnumerator Temp()
    {
        yield return new WaitForSeconds(2f);
        entrou = false;
        _naoestaporta = true;
    }

    IEnumerator Temp2()
    {
        yield return new WaitForSeconds(2f);
        _naoestaporta = false;
    }

}

