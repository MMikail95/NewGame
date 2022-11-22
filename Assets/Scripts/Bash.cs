using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Bash : MonoBehaviour
{
    private Rigidbody rb;
    public bool isHit;
    [SerializeField] List<GameObject> _cubes;
    void Start()
    {
        isHit = false;
        rb = GetComponent<Rigidbody>();
        Spawn();
    }
    void Update()
    {
        BashMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        int vurma = 0;

        if (vurma ==0 & collision.gameObject.tag == ("Cubes"))
        {
            vurma=1;
            Debug.Log("WE HIT AN OBSTACLE");
            isHit = true;
            collision.gameObject.transform.localScale = new Vector3(2, 2, 2);
            if (vurma >= 1)
            {
                isHit = true;
                collision.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }

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

    private void Spawn()
    {

        Instantiate(_cubes[Random.Range(0, 3)], new Vector3(0f, 1f, 0f), Quaternion.identity);

        //Instantiate(cube, new Vector3(-2f, 1f, 0f), Quaternion.identity);

        //Instantiate(cube, new Vector3(-4f, 1f, 0f), Quaternion.identity);


        //cubeList.Add((GameObject)Instantiate(Bash.cubeList, new Vector3(0, 1f, 0f), Quaternion.identity));
    }
}
