using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySelector : MonoBehaviour
{
    public Image img;

    void OnMouseEnter(){
        img.color = new Color(1f, 1f, 1f, 0.4f);
        Debug.Log("Mousing over");
    }

    void OnMouseExit(){
        img.color = new Color(1f, 1f, 1f, 1f);
    }
}
