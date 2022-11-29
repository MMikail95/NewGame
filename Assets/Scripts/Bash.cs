using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bash : MonoBehaviour
{
    private Cube cubes;
    private Rigidbody rb;
    public bool isHit;
    public int upSpeed = 25;
    public int downSpeed = 75;
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
        cubes = collision.gameObject.GetComponent<Cube>();

        if (collision.gameObject.CompareTag("Cubes"))
        {
            isHit = true;
        }

        if (collision.gameObject.name == "Roof")
        {
            isHit = false;
        }
    }

    private void BashMove()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("deðdim");
            downSpeed += 25;
            downSpeed = Mathf.Clamp(downSpeed, 75, 450);
            upSpeed += 25;
            upSpeed = Mathf.Clamp(downSpeed, 25, 150);
        }

        else
        {
            downSpeed -= 25;
            downSpeed = Mathf.Clamp(downSpeed, 75, 450);
            upSpeed -= 25;
            upSpeed = Mathf.Clamp(downSpeed, 25, 150);
        }

        if (isHit == false)
        {
            rb.AddForce(-transform.up * downSpeed);
        }

        else
        {
            rb.AddForce(transform.up * upSpeed);
        }
    }
}
