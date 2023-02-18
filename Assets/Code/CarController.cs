using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    GameObject[] wheels = new GameObject[2];

    const byte leftWheel = 0;
    const byte rightWheel = 1;

    [SerializeField]
    private float horsePower = 450;
    [SerializeField]
    private float mass = 1500;
    [SerializeField]
    private float maxSpeed = 205;

    float inputVertical;
    float inputHorizontal;

    public float move = 0;
    float _break = 0;
    float rotation;

    float racingCoefficient;

    float rotationSpeed = 1;

    private Rigidbody2D rb;

    enum Rotate
    { 
        Left = -1,
        Right = 1
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = mass / 1000;

        racingCoefficient = mass / horsePower;

        wheels[leftWheel] = GameObject.Find("Left Forward Wheel");
        wheels[rightWheel] = GameObject.Find("Right Forward Wheel");
    }

    void Update()
    {
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        

        if (inputVertical > 0 && move < maxSpeed )
        {
            move += inputVertical * racingCoefficient * Time.deltaTime;
        }

        else if (inputVertical == 0 && move > 0)
        {
            move -= racingCoefficient * Time.deltaTime * 0.5f;
        }

        if (move < 0)
            move = 0;

        
        rotation = inputHorizontal * -rotationSpeed;
        
    }

    void FixedUpdate()
    {
        transform.Translate(0f,move,0f);
        if (move > 0)
        {
            transform.Rotate(0f, 0f, rotation);
        }
    }
}
