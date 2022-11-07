using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class Password : MonoBehaviour
{
    public GameObject cubo;

    [Header("Background")]
    [Space(5)]
    [Header("Numeric KeyBoard")]
    public Sprite imageBackground;
    public Color backgroundColor = Color.gray;
    
    [Header("Buttons")]
    [Space(5)]
    public Sprite imageButtons;
    public Color buttonColor = Color.red;
    public Font font;
    public int fontSize = 48;
    public Color colorText = Color.white;
    private Button[] numbersButtons = new Button[12];

    [Header("Input Field")]
    [Space(5)]
    public Sprite imageInput;
    public Color inputColor = Color.white;
    public Font inputFont;
    public int inputFontSize = 48;
    public string placeholderText = "...";
    public Color inputColorText = Color.black;
    public bool bold = false;
    bool enterCode, drawPressE = false;
    int quantify = 0;
    string code;
    int spaceBtns = 123;
    void Start()
    {
        font = font == null ? Resources.GetBuiltinResource<Font>("Arial.ttf") : font;
        inputFont = inputFont == null ? Resources.GetBuiltinResource<Font>("Arial.ttf") : inputFont;
        for(int i =0;i<5;i++)
        {
            code += Random.Range(0,10);
        }
        Debug.Log($"<color=green>{code}</color>");
    }

    void Update()
    {
        if(enterCode && Input.GetKeyDown(KeyCode.E))
        {
            ShowNumericKeyboard();
        }
        else if(enterCode == false){
            quantify = 0;
            DestroyImmediate(GameObject.Find("Canvas"));
        }
    }

    //CRIA O CANVAS
    public GameObject GenerateCanvas()
    {
        GameObject newCanvas = new GameObject("Canvas");
        Canvas c = newCanvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        newCanvas.AddComponent<CanvasScaler>();
        newCanvas.AddComponent<GraphicRaycaster>();
        
        return newCanvas;
    }

    void ShowNumericKeyboard()
    {
        if(GameObject.FindObjectOfType<Canvas>())
        {
            quantify++;
        }
        
        if(quantify <= 0)
        {
            drawPressE = false;
            Cursor.lockState = CursorLockMode.None;
            InterfaceUINumericKeyboard();
        }
    }

    void InterfaceUINumericKeyboard()
    {
        // GET CANVAS
        GameObject canvas = GenerateCanvas();

        // BACKGROUND
        GameObject numericKeyboard = new GameObject("NumericKeyboard");
        numericKeyboard.AddComponent<CanvasRenderer>();
        Image img = numericKeyboard.AddComponent<Image>();
        img.color = backgroundColor;
        img.sprite = imageBackground ?? null;
        img.type = Image.Type.Sliced;
        img.rectTransform.sizeDelta = new Vector2(518,677);
        numericKeyboard.transform.SetParent(canvas.transform, false);

        //INPUT
        GameObject inputField = new GameObject("EnterCode");
        inputField.transform.position = new Vector2(0,235);
        inputField.AddComponent<CanvasRenderer>();

        Image imgInpt = inputField.AddComponent<Image>();
        imgInpt.color = inputColor;
        imgInpt.rectTransform.sizeDelta = new Vector2(350,100);
        imgInpt.sprite = imageInput ?? null;
        imgInpt.type = Image.Type.Sliced;

        GameObject placeHolder = new GameObject("Placeholder");
        placeHolder.transform.SetParent(inputField.transform,false);
        Text inputPlaceholder = placeHolder.AddComponent<Text>();
        inputPlaceholder.color = Color.gray;
        inputPlaceholder.font = inputFont;
        inputPlaceholder.fontSize = inputFontSize;
        inputPlaceholder.fontStyle = FontStyle.Italic;
        inputPlaceholder.alignment = TextAnchor.MiddleRight;
        inputPlaceholder.rectTransform.sizeDelta = imgInpt.rectTransform.sizeDelta;
        inputPlaceholder.text = placeholderText;;

        GameObject textCode = new GameObject("Text");
        textCode.transform.SetParent(inputField.transform,false);
        textCode.AddComponent<CanvasRenderer>();
        Text textInput = textCode.AddComponent<Text>();
        textInput.font = inputFont;
        textInput.fontSize = inputFontSize;
        textInput.color = inputColorText;
        textInput.alignment = TextAnchor.MiddleRight;
        textInput.supportRichText = false;
        textInput.fontStyle = bold ? FontStyle.Bold : FontStyle.Normal;
        textInput.rectTransform.sizeDelta = imgInpt.rectTransform.sizeDelta;

        InputField enterCode = inputField.AddComponent<InputField>();
        enterCode.textComponent = textInput;
        enterCode.readOnly = true;
        enterCode.placeholder = inputPlaceholder;
        enterCode.characterLimit = code.Length;
        inputField.transform.SetParent(numericKeyboard.transform,false);

        // BUTTONS
        for(int i =0;i<numbersButtons.Length;i++)
        {
            GameObject numberBtn = new GameObject("Number "+(i));
            numberBtn.transform.position = new Vector2(-spaceBtns,100);
            numberBtn.AddComponent<CanvasRenderer>();

            Image imgBtn = numberBtn.AddComponent<Image>();
            imgBtn.color = buttonColor;
            imgBtn.sprite = imageButtons ?? null;
            imgBtn.type = Image.Type.Sliced;

            GameObject textNumber = new GameObject("Text");
            textNumber.transform.SetParent(numberBtn.transform,false);
            textNumber.AddComponent<CanvasRenderer>();
            Text textBtn =  textNumber.AddComponent<Text>();
            textBtn.text = i.ToString();
            textBtn.color = colorText;
            textBtn.font = font;
            textBtn.fontSize = fontSize;
            textBtn.alignment = TextAnchor.MiddleCenter;

            Button btn = numberBtn.AddComponent<Button>();
            imgBtn.rectTransform.sizeDelta = new Vector2(85,85);
            numbersButtons[i] = btn;
            int index = i;
            btn.onClick = new Button.ButtonClickedEvent();
            btn.onClick.AddListener(() => EnterCode(index,enterCode));
            numberBtn.transform.SetParent(numericKeyboard.transform,false);
        }

        for(int x = 2; x<4;x++)
        {
            if(numbersButtons[x] != null)
            {
                Vector2 pos = numbersButtons[x-1].transform.position;
                pos.x += spaceBtns;
                numbersButtons[x].transform.position = pos;
            }
        }
        for(int x = 4; x<7;x++)
        {
            if(numbersButtons[x] != null)
            {
                Vector2 pos = numbersButtons[x-1].transform.position;
                pos.x = numbersButtons[x-3].transform.position.x;
                pos.x -= spaceBtns;
                pos.y = numbersButtons[x-3].transform.position.y;
                pos.y -= spaceBtns;
                pos.x += spaceBtns;
                numbersButtons[x].transform.position = pos;
            }
        } 
        for(int x = 7; x<10;x++)
        {
            if(numbersButtons[x] != null)
            {
                Vector2 pos = numbersButtons[x-1].transform.position;
                pos.x = numbersButtons[x-3].transform.position.x;
                pos.x -= spaceBtns;
                pos.y = numbersButtons[x-3].transform.position.y;
                pos.y -= spaceBtns;
                pos.x += spaceBtns;
                numbersButtons[x].transform.position = pos;
            }
        }
        for(int x = 10; x<12;x++)
        {
            if(numbersButtons[x] != null)
            {
                Vector2 pos = numbersButtons[x-1].transform.position;
                pos.x = numbersButtons[x-3].transform.position.x;
                pos.x -= spaceBtns;
                pos.y = numbersButtons[x-3].transform.position.y;
                pos.y -= spaceBtns;
                pos.x += spaceBtns*2;
                numbersButtons[x].transform.position = pos;
            }
        }
        numbersButtons[0].transform.position = numbersButtons[10].transform.position;
        Vector2 p = numbersButtons[0].transform.position;
        p.x -= spaceBtns;
        numbersButtons[10].transform.position = p;
        cancelAndConfirmButton(numbersButtons[10],numbersButtons[11], enterCode);

    }

    void EnterCode(int index,InputField inputField)
    {
        inputField.text += numbersButtons[index].transform.GetChild(0).GetComponent<Text>().text;
    }

    void cancelAndConfirmButton(Button cancel, Button confirm, InputField inputField)
    {
        // CANCEL BUTTON
        cancel.image.color = Color.red;
        cancel.transform.GetChild(0).GetComponent<Text>().text = "X";
        cancel.onClick = new Button.ButtonClickedEvent();
        cancel.onClick.AddListener(() => Cancel(inputField));

        // CONFIRM BUTTON
        confirm.image.color = Color.green;
        confirm.transform.GetChild(0).GetComponent<Text>().text = "\u2714";
        confirm.onClick = new Button.ButtonClickedEvent();
        confirm.onClick.AddListener(() => Verify(inputField));
    }

    public void Cancel(InputField inputField)
    {
        inputField.text = "";
        ColorBlock cb = inputField.colors;
        cb.normalColor = Color.white;
        inputField.colors = cb;
    }
    public void Verify(InputField inputField)
    {
        bool correct = inputField.text == code ? true:false;
        if(correct)
        {
            ColorBlock cb = inputField.colors;
            cb.normalColor = Color.green;
            inputField.colors = cb;
            Destroy(GameObject.Find("Canvas"),2);
            OpenDoor();
            Destroy(GetComponent<Password>());
        }
        else{
            ColorBlock cb = inputField.colors;
            cb.normalColor = Color.red;
            inputField.colors = cb;
        }
    }

    void OpenDoor()
    {
        //CRIA DA SUA FORMA COMO A PORTA ABRIRÁ EU CRIEI UMA ANIMAÇÃO
        cubo.GetComponent<Renderer>().material.color = Color.green;
    }
    void OnTriggerEnter(Collider other) 
    {
        enterCode = true;
        drawPressE = true;
    }
    void OnTriggerExit(Collider other) {
        enterCode = false;
        drawPressE = false;
    }
    void OnGUI()
    {
        if(drawPressE){
            GUIStyle style = new GUIStyle();
            style.fontSize = 24;
            style.normal.textColor = Color.white;
            GUI.Label(new Rect(Screen.width/2 - Screen.width/8 ,Screen.height/2,500,60),"Press 'E' to Enter Code",style);
        }
    }
}
