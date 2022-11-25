using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bash : MonoBehaviour
{
    private Cubes cubes;
    private Rigidbody rb;
    public bool isHit;
    void Start()
    {
        isHit = false;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        BashMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        cubes = collision.gameObject.GetComponent<Cubes>();
        if (collision.gameObject.CompareTag("Cubes"))
        {
            isHit = true;
        }

        if (collision.gameObject.name == "Roof")
        {
            isHit = false;
            //Debug.Log(cubes.hit);
        }
        //if (cubes.hit == 3 & collision.gameObject.name == ("Roof"))
        //{
        //    Debug.Log(cubes.hit);
        //}
    }

    private void BashMove()
    {
        if (isHit == false)
        {
            rb.AddForce(-transform.up * 75);
        }

        else
        {
            rb.AddForce(transform.up * 25);
        }
    }
}
