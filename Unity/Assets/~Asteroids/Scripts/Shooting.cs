using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Aesteroids
{
    public class Shooting : MonoBehaviour
    {
        public GameObject bulletPrefab; //Prefab of bullet to spawn
        public float bulletSpeed = 20f; //Speed that the bullet travels
        public float shootRate = 0.2f; //Rate of fire (in seconds)

        private float shootTimer = 0f; //Timer to count to shoot rate 
    

    void Shoot()
    {
        //Create a new bullet clone
        GameObject clone = Instaniate(bulletPrefab, Transform position, Transform.rotation);
        //Grab rigidbody from clone
        Rigidbody2D rigid = clone.GetComponent<Rigidbody2D>();
        //Add a force to the bullet (using bulletSpeed)
        rigid.AddForce(Transform.up * bulletspeed, ForceMode2D.Impulse);
    }
    //Update is called once per frame
    void Update()
    {
        //Set shootTimer = shootTimer
    }
        }
}


