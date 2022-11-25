using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    private Bash bash;
    private Spawn spawn;
    public int hit = 0;
    private void Awake()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        bash = collision.gameObject.GetComponent<Bash>();
        spawn = collision.gameObject.GetComponent<Spawn>();

        if (collision.gameObject.name == "Bash")
        {
            hit++;

            if (hit == 1)
            {
                Debug.Log(hit);
                bash.isHit = true;
                transform.localScale = new Vector3(2, 3, 2);
                transform.position = new Vector3(0, 1.75f, 0);
            }

            if (hit == 2)
            {
                Debug.Log(hit);
                transform.localScale = new Vector3(3, 2, 3);
                transform.position = new Vector3(0, 1.25f, 0);
            }

            if (hit == 3)
            {
                Debug.Log(hit);
                transform.localScale = new Vector3(4, 1, 4);
                transform.position = new Vector3(0, 0.75f, 0);               
            }

        }

        if (hit == 3)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.position = new Vector3(4, 0.75f, 0);
    }
}
