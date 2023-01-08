using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class msgbox : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public static string updateText;
    public GameObject exclam;
       
    void Start(){
        
    }
    
    void Update()
    {
        txt.text = updateText;
    }

    public static void UpdateMsgBox(string msg){
        updateText = msg;
    }
}
