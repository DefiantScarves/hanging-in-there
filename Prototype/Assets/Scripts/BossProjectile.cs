﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    public GameObject RockExplosionPrefab;

    public float Speed = 0.1f;

    private Vector3 movementVector;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = transform.forward * Speed;
        player = GameObject.Find("Player");
        if (player == null)
        {
            player = GameObject.Find("DemoPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + movementVector);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.transform.name == "DemoPlayer")
        //{
            gameObject.tag = "Untagged";
            Instantiate(RockExplosionPrefab, transform.position, Quaternion.Euler(collision.contacts[0].normal));
            player.SendMessage("RemoveMoveableObjectFromList", gameObject);
            Destroy(this.gameObject);
        //}

    }
}
