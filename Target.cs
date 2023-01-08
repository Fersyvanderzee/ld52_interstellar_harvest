using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Target : MonoBehaviour
{
    public AIDestinationSetter dest;
    private SpriteRenderer spr;
    void Start(){
        spr = GetComponent<SpriteRenderer>();
    }


    void OnMouseEnter(){
        spr.enabled = true;
    }

    void OnMouseExit(){
        spr.enabled = false;
    }

    void OnMouseDown(){
        dest.target = this.gameObject.transform;
    }
}
