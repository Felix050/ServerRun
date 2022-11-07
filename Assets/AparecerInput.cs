using UnityEngine;
using System.Collections;

public class AparecerInput : MonoBehaviour {

    public GameObject cubo;

    //private bool drawPressE = false;

    public string senha;
    private string senhaTXT;
    private  GUIStyle style;

    private bool abrirGUI = false;
    [Range(0.1f,10.0f)]public float distancia = 3;
    private GameObject jogador;

   void Start(){
      senhaTXT = string.Empty;
      style = new GUIStyle();
      abrirGUI = false;
      jogador = GameObject.FindWithTag ("Player");
   }

void Update()
    {
        if (Vector3.Distance (jogador.transform.position, transform.position) < distancia && Input.GetKeyDown ("e"))
        {
            abrirGUI = true;
        }
        else if (Vector3.Distance (jogador.transform.position, transform.position) > distancia)
        {
            Cursor.lockState = CursorLockMode.Locked;
            abrirGUI = false;
        }
        if (Input.GetKeyDown ("c") && abrirGUI == true)
        {
            abrirGUI = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }



   void OnGUI(){
        if (abrirGUI == true){
                //Desfixar o Mouse para poder clicar nos números
                Cursor.lockState = CursorLockMode.None;
            //numeros da senha
                GUI.Box(new Rect(Screen.width / 2.61f, Screen.height / 8, Screen.width / 4.3f, Screen.height / 8), senhaTXT);
            // 1 - 2 - 3
                if (GUI.Button (new Rect (Screen.width / 2.61f, Screen.height / 3, Screen.width / 14, Screen.height / 8), "1")) {
                    senhaTXT = senhaTXT + "1";
                }
                if (GUI.Button (new Rect (Screen.width / 2.16f, Screen.height / 3, Screen.width / 14, Screen.height / 8), "2")) {
                    senhaTXT = senhaTXT + "2";
                }
                if (GUI.Button (new Rect (Screen.width / 1.835f, Screen.height / 3, Screen.width / 14, Screen.height / 8), "3")) {
                    senhaTXT = senhaTXT + "3";
                }
            // 4 - 5 - 6
                if (GUI.Button (new Rect (Screen.width / 2.61f, Screen.height / 2.1f, Screen.width / 14, Screen.height / 8), "4")) {
                    senhaTXT = senhaTXT + "4";
                }
                if (GUI.Button (new Rect (Screen.width / 2.16f, Screen.height / 2.1f, Screen.width / 14, Screen.height / 8), "5")) {
                    senhaTXT = senhaTXT + "5";
                }
                if (GUI.Button (new Rect (Screen.width / 1.835f, Screen.height / 2.1f, Screen.width / 14, Screen.height / 8), "6")) {
                    senhaTXT = senhaTXT + "6";
                }
            // 7 - 8 - 9
                if (GUI.Button (new Rect (Screen.width / 2.61f, Screen.height / 1.6f, Screen.width / 14, Screen.height / 8), "7")) {
                    senhaTXT = senhaTXT + "7";
                }
                if (GUI.Button (new Rect (Screen.width / 2.16f, Screen.height / 1.6f, Screen.width / 14, Screen.height / 8), "8")) {
                    senhaTXT = senhaTXT + "8";
                }
                if (GUI.Button (new Rect (Screen.width / 1.835f, Screen.height / 1.6f, Screen.width / 14, Screen.height / 8), "9")) {
                    senhaTXT = senhaTXT + "9";
                }
            // * - 0 - #
                if (GUI.Button (new Rect (Screen.width / 2.61f, Screen.height / 1.3f, Screen.width / 14, Screen.height / 8), "*")) {
                    senhaTXT = senhaTXT + "*";
                }
                if (GUI.Button (new Rect (Screen.width / 2.16f, Screen.height / 1.3f, Screen.width / 14, Screen.height / 8), "0")) {
                    senhaTXT = senhaTXT + "0";
                }
                if (GUI.Button (new Rect (Screen.width / 1.835f, Screen.height / 1.3f, Screen.width / 14, Screen.height / 8), "#")) {
                    senhaTXT = senhaTXT + "#";
                }
            // RESSETAR OU CONFIRMAR
            if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 1.7f, Screen.width / 5, Screen.height / 8), "RESSETAR")) {
                senhaTXT = string.Empty;
            }
            if (GUI.Button (new Rect (Screen.width / 1.5f, Screen.height / 2.5f, Screen.width / 5, Screen.height / 8), "CONFIRMAR")) {
                if(senhaTXT == senha){
                    senhaTXT = "Código correto!";
                    cubo.GetComponent<Renderer>().material.color = Color.green;
                }else{
                    senhaTXT = "Código incorreto!";
                }
            }
        }
    }
}
