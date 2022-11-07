using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TesteInput : MonoBehaviour
{

    public Button btnClick;


    public InputField inputUser;

    // Start is called before the first frame update
    void Start()
    {
        btnClick.onClick.AddListener(GetInputOnClickHandler);
    }

    // Update is called once per frame
    void GetInputOnClickHandler()
    {
        Debug.Log("Log input");
    }
}
