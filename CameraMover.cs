using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public int moveSpeed = 1;
    private Vector2 motion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        motion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        transform.Translate(motion * moveSpeed * Time.deltaTime);
    }
}
