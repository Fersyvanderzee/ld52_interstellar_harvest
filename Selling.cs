using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selling : MonoBehaviour
{
    public bool selling;

    public int ironPrice = 50;
    public int coalPrice = 50;
    public int quartzPrice = 50;
    public int rubyPrice = 50;
    public int diamondPrice = 50;

    private int totalAmountSold;

    private bool somethingInInv;

    void Update(){
        if(Inventory.amountIron > 0 || Inventory.amountCoal > 0 || Inventory.amountQuartz > 0 || Inventory.amountRuby > 0 || Inventory.amountDiamond > 0){
            somethingInInv = true;
        } else {
            somethingInInv = false;
        }

        if(selling){
            if(Input.GetKeyDown(KeyCode.E)){
                if(somethingInInv){
                    totalAmountSold = Inventory.amountIron * ironPrice + Inventory.amountCoal * coalPrice + 
                    Inventory.amountQuartz * quartzPrice + Inventory.amountRuby * rubyPrice + Inventory.amountDiamond * diamondPrice;
                    
                    Inventory.creditsAmount += totalAmountSold;

                    Inventory.amountIron = 0;
                    Inventory.amountCoal = 0;
                    Inventory.amountQuartz = 0;
                    Inventory.amountRuby = 0;
                    Inventory.amountDiamond = 0;

                    msgbox.UpdateMsgBox("Sold resources for " + totalAmountSold.ToString() + " credits.");
                } else {
                    msgbox.UpdateMsgBox("Nothing in inventory.");
                }

            }



            if(Input.GetKeyDown(KeyCode.Q)){
                if(Inventory.creditsAmount >= 50){
                    Inventory.amountHarvesters += 1;
                    Inventory.creditsAmount -= 50;
                    msgbox.UpdateMsgBox("Bought 1 harvester for 50 credits.");
                } else if (Inventory.creditsAmount < 50){
                    msgbox.UpdateMsgBox("Not enough credits. 1 harvester = 50 credits.");
                }
            }


        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpaceShip")){
            msgbox.UpdateMsgBox("Welcome to the marketplace! Press 'E' to sell and 'Q' to buy a harvester for 50 credits");
            selling = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("SpaceShip")){
            selling = false;
        }
    }
}
