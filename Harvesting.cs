using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Harvesting : MonoBehaviour
{
    public bool IsHarvesting = false;
    public bool HarvestComplete = false;
    public bool canBeHarvested = false;
    public bool shipDocked = false;

    public float harvestSpeed = 0.005f;
    public int amountResources;
    public string resourceName;
    
    public GameObject harvestSymbol;
    public GameObject progBarSymbol;
    public GameObject planetScript;
    
    public SpriteRenderer progBar;
    
    public float harvestLevel = 0f;

    private float maxHarvest = 100f;

    private Color inProg = new Color(0.9f, 0.2f, 0.15f, 1f);
    private Color progDone = new Color(0.6f, 0.9f, 0.3f, 1f);

    void Start()
    {
        System.Random rnd = new System.Random();
        amountResources = rnd.Next(1, 6);

        resourceName = planetScript.GetComponent<Planets>().resourceName;
    }

    
    void Update()
    {     
        if(shipDocked && !IsHarvesting && !HarvestComplete){
            if(Inventory.amountHarvesters > 0){
                msgbox.UpdateMsgBox("Docked! Place a harvester with 'E'.");
            } else {
                msgbox.UpdateMsgBox("No harvesters left! Go to the marketplace to get new ones.");
            }
            

            if(Input.GetKeyDown(KeyCode.E)){
                if(Inventory.amountHarvesters > 0){
                    IsHarvesting = true;
                    Inventory.amountHarvesters -= 1;
                    msgbox.UpdateMsgBox("Harvesters placed! Left: " + Inventory.amountHarvesters);
                } else if(Inventory.amountHarvesters <= 0){
                    msgbox.UpdateMsgBox("No harvesters left! Go to the marketplace to get new ones.");
                }
                
            }
        }

        if(IsHarvesting){
            harvestSymbol.SetActive(true);
            progBarSymbol.SetActive(true);
        } else {
            harvestSymbol.SetActive(false);
            progBarSymbol.SetActive(false);
        }
        
        if(IsHarvesting && !HarvestComplete){
            if(harvestLevel < maxHarvest){
                harvestLevel += harvestSpeed * Time.deltaTime;
                HarvestComplete = false;
                progBar.color = inProg;
                progBarSymbol.transform.localScale = new Vector3(harvestLevel / 100 * 0.2f, 0.01f, 1f);
            } else {
                HarvestComplete = true;
            }
        } else if (IsHarvesting && HarvestComplete){
            progBar.color = progDone;
            canBeHarvested = true;
        }

        if(shipDocked && canBeHarvested){
            if(Input.GetKeyDown(KeyCode.E)){
                convertToResources(resourceName, amountResources);

                IsHarvesting = false;
                HarvestComplete = false;
                canBeHarvested = false;
                harvestLevel = 0;

                this.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpaceShip")){
            shipDocked = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("SpaceShip")){
            shipDocked = false;
        }
    }

    void convertToResources(string resourceName, int resourceAmount){
        switch(resourceName){
            case "Iron":
                Inventory.amountIron += resourceAmount;
                break;

            case "Coal":
                Inventory.amountCoal += resourceAmount;
                break;

            case "Quartz":
                Inventory.amountQuartz += resourceAmount;
                break;
                
            case "Ruby":
                Inventory.amountRuby += resourceAmount;
                break;
                
            case "Diamond":
                Inventory.amountDiamond += resourceAmount;
                break;
        }
    }
}
