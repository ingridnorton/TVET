using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Movement : MonoBehaviour
    {
        public float speed = 20f; //Units to travel
        public float rotationSpeed = 360f; //Amount of rotation per second


        private Rigidbody2D rigid; // Refrence to attached RigidBody2D

        // Use this for initialization
        void Start()
        {

            //Tried to add force in the transform's up direction via speed
            // rigid.AddForce(transform.up * speed); this code does not work

            //Grab refrence to rigidbody2d component
            //Note: It gets this from the GameObject thus script is attached to
            rigid = GetComponent<Rigidbody2D>();


        }

        // Update is called once per frame
        void Update()
        {
            //Check if the A key is pressed
            if (Input.GetKey(KeyCode.A))
            {
                //Rotate Left
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
            }
            //Check if the D key is pressed
            if (Input.GetKey(KeyCode.D))
            {
                //Rotate right
                transform.Rotate(-Vector3.forward, rotationSpeed* Time.deltaTime);
            }

            //Check if the 'W' key is pressed
            if (Input.GetKey(KeyCode.W))
            {
                rigid.AddForce(transform.up * speed);
            }
            //Check if the S key is pressed
            if (Input.GetKey(KeyCode.S))
            {
                rigid.AddForce (-transform.up * speed);
            }


        }
    }
}
