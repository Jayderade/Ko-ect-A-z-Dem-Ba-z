﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float movementSpeed = 5;
    public float acceleration = 50f;
    public float deceleration = .1f;
    public Text countText;

    private Rigidbody2D rigid;
    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
        rigid = GetComponent<Rigidbody2D>();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        // If user presses D
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            // Move right
            rigid.AddForce(transform.right * acceleration);
        }
        //If user presses A
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            // Move left
            rigid.AddForce(-transform.right * acceleration);
        }

        //Deceleration
        rigid.velocity += -rigid.velocity * deceleration;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Balls"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }


    }

    void SetCountText()
    {
        countText.text = "Score:" + count.ToString();

    }
}
