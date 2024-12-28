using System;
using System.Linq;
using UnityEngine;

public class PlayerController2d : MonoBehaviour
{
    float horizontal;
    bool isFacingRight=true;
    public float speed=10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get Input
        horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);
        Vector3 direction = new Vector3(horizontal, 0, 0);        

        //Implement player flip
        if (horizontal < 0 && isFacingRight)
        {
            leftFlip();      
        }
        else if(horizontal > 0 && !isFacingRight) 
        {
            rightFlip();
        }

        //update Player position
        transform.Translate(speed * Time.deltaTime * direction);

    }
    void leftFlip()
    {
        horizontal *= -1;
        isFacingRight = false;
        transform.Rotate(0, 180, 0);
    }

    void rightFlip()
    {
        horizontal *= -1;
        isFacingRight = true;
        transform.Rotate(0, 180, 0);
    }
}
