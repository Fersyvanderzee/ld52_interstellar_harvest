using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool showInv = false;
    public int startHarvesters;

    public static int creditsAmount;
    public static int amountHarvesters;

    public static int amountIron;
    public static int amountCoal;
    public static int amountQuartz;
    public static int amountRuby;
    public static int amountDiamond;

    public GameObject canvas;
    public TextMeshProUGUI[] amountTexts;
    public Image[] invImages;
    public TextMeshProUGUI creditsAmountText;
    public TextMeshProUGUI harvAmountText;


    void Start(){
        amountHarvesters = startHarvesters;
        foreach(TextMeshProUGUI txt in amountTexts){
            txt.text = "0";
        }

        creditsAmount = 0;

        creditsAmountText.text = "Credits: " + creditsAmount.ToString();
    }


    void Update(){
        if(Input.GetKeyDown("tab") && !showInv){
            canvas.SetActive(true);
            showInv = true;
        } else if(Input.GetKeyDown("tab") && showInv){
            canvas.SetActive(false);
            showInv = false;
        }

        amountTexts[0].text = amountIron.ToString();
        amountTexts[1].text = amountCoal.ToString();
        amountTexts[2].text = amountQuartz.ToString();
        amountTexts[3].text = amountRuby.ToString();
        amountTexts[4].text = amountDiamond.ToString();


        creditsAmountText.text = "Credits: " + creditsAmount.ToString();
        harvAmountText.text = amountHarvesters.ToString();
    }

}
