using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Clean code = control k+ d
    //fold code = control m + o
    //unfold = control m + p 
    public float speed = 15f;
    public float jumpHeight = 1f;
    private Rigidbody rigid;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //'Call' move and jump
        Move();
        Jump();
    }

    void Move()
    {
        //Check if 'W' key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            rigid.AddForce(Vector3.forward * speed);
        }

        //Check if 'S' key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            rigid.AddForce(Vector3.back * speed);
        }

        //Check if 'A' key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            rigid.AddForce(Vector3.left * speed);
        }

        //Check if 'D' key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            rigid.AddForce(Vector3.right * speed);
        }
    }

    void Jump()
    {
        //Check if the key was pressed once
        if (Input.GetKeyDown(KeyCode.Space))

        {
            rigid.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }
}
