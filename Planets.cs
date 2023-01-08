using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planets : MonoBehaviour
{

    public Sprite[] planets;
    public SpriteRenderer spriteRenderer;
    public string resourceName;
    
    public bool isSelected;

    void Start()
    {
        ChosePlanet();
    }


    void Update()
    {
        
    }

    void ChosePlanet(){
        System.Random rnd = new System.Random();
        int randPlanet = rnd.Next(0, 5);


        // Change sprite
        spriteRenderer.sprite = planets[randPlanet];

        // Change resource
        switch(randPlanet){
            case 0:
                resourceName = "Coal";
                break;
            case 1:
                resourceName = "Diamond";
                break;
            case 2:
                resourceName = "Iron";
                break;
            case 3:
                resourceName = "Quartz";
                break;
            case 4:
                resourceName = "Ruby";
                break;
        }


    }

}
