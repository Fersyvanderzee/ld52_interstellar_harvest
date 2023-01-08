using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameObject objectIsClicked;
    
    void Start()
    {
        msgbox.UpdateMsgBox("Welcome. Your objective is to earn 2500 credits. Use the mouse and W, A, S, D.");
    }

    
    void Update()
    {
        if(Inventory.creditsAmount >= 2500){
            SceneManager.LoadScene(3);
        }
    }

}
