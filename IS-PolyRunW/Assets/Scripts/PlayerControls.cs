﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //Jumping power for the player object
    [Header("Default Jumping Power")]
    public float jumpPower = 6f;
    //True or false if the object
    //is on the ground
    [Header("Boolean isGrounded")]
    public bool isGrounded = false;
    //Posistion of the object
    float posX = 0.0f;
    //Rigidbody2D of the object 
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //Variable rb equals to Rigidbody2D
        //component
        rb = transform.GetComponent<Rigidbody2D>();
        //Variable posX equals to position
        //of the object on the x axis
        posX = transform.position.x;
    }

    void FixedUpdate()
    {
        //If the Spacebar is pressed and 
        //object is on the ground and
        //the game is playing
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            //Adds force to the object
            //to jump upwards based on 
            //jumppower, mass, and
            //gravity
            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));

            //if the player position is less than 
            //the original position of the player
            if(transform.position.x < posX)
            {
                //Execute GameOver function
                GameOver();
            }

        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    { 
        //If colliders tag equals ground
        if (collision.collider.tag == "Ground")
        {
            //isGrounded equals true
            isGrounded = true;
        }
        //If colliders tag equals enemy
        if(collision.collider.tag == "Enemy")
        {
            //Game Over function is called
            GameOver();
        }
    }


    void OnCollisionStay2D(Collision2D collision)
    {
        //If colliders tag equals ground
        if (collision.collider.tag == "Ground")
        {
            //isGrounded equals true
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //If colliders tag equals ground
        if (collision.collider.tag == "Ground")
        {
            //isGrounded equals true
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void GameOver()
    {
        //Game Over function is called from the game manager
        GameObject.Find("GameController").GetComponent<GameController>().GameOver();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //If triggers tag equals coin
        if (collision.tag == "Coin")
        {
            //Call IncrementScore from
            //Game Controller
            GameObject.Find("GameController").GetComponent<GameController>().IncrementScore();
            //Destroy object
            Destroy(collision.gameObject);
        }
    }
}
