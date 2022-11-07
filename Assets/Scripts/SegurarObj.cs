using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegurarObj : MonoBehaviour {
    public string[] Tags;
    public GameObject ObjSegurando;
    [Space(20)]
    public float DistanciaMax;
    public bool Segurando;
    public bool PodeColocar;
    public GameObject Local;
    public GameObject LocalTeste;
    public LayerMask Layoso;
	


    void OnTriggerEnter ()
    {
        if (LocalTeste.gameObject.CompareTag ("Player"))
        {
            PodeColocar = true;
        }
    }

    void OnTriggerExit ()
    {
        if (LocalTeste.gameObject.CompareTag ("Player"))
        {
            PodeColocar = false;
        }
    }




	void Update () {
        
            if (Segurando == true)
            {
                if (Input.GetMouseButtonDown(0) && PodeColocar == true)
                {
                    Segurando = false;
                    ObjSegurando.transform.parent = null;
                    ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
                    ObjSegurando.transform.position = LocalTeste.transform.position;
                    //ObjSegurando.transform.rotation = Local.transform.rotation;
                    ObjSegurando = null;
                    return;
                }
            }

            if (Segurando == false) {
                RaycastHit Hit = new RaycastHit();
                if (Physics.Raycast(transform.position, transform.forward, out Hit, DistanciaMax, Layoso, QueryTriggerInteraction.Ignore)){
                    Debug.DrawLine(transform.position, Hit.point, Color.green);

                    ObjSegurando = Hit.transform.gameObject;
                    for (int x = 0; x < Tags.Length; x++)
                    {
                        if (Hit.transform.gameObject.tag == Tags[x])
                        {
                            if (Input.GetMouseButtonDown(0)) // tambem pode ser um botão do teclado...
                            {
                                Segurando = true;
                                ObjSegurando = Hit.transform.gameObject;
                                if (ObjSegurando.GetComponent<Rigidbody>())
                                {
                                    ObjSegurando.GetComponent<Rigidbody>().isKinematic = true;
                                    ObjSegurando.transform.position = Local.transform.position;
                                    ObjSegurando.transform.rotation = Local.transform.rotation;
                                    ObjSegurando.transform.parent = Local.transform;
                                }
                                return;
                            }
                        }
                    }
                }
            }
      


	}
}