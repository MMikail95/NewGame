using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : MonoBehaviour
{
    private Rigidbody rb;
    public bool isHit;
    public GameManager manager;
    public GameObject cube;
    void Start()
    {
        isHit = false;
        rb = GetComponent<Rigidbody>();
        CubeSpawn();
    }
    void Update()
    {
        BashMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Platform")
        {
            Debug.Log("WE HIT AN OBSTACLE");
            isHit = true;
        }

        if (collision.gameObject.name == "Roof")
        {
            isHit = false;
        }
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

    private void CubeSpawn()
    {
        Instantiate(cube, Vector3.zero, Quaternion.identity);
    }
}
