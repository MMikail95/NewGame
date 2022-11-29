using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Spawner spawner;
    private Bash bash;
    public int hit = 0;
    public float destroySpeed = 2.5f;
    private bool moveTimer;
    private float moveTimerCounter;
    private float _move = 6f;
    [SerializeField] private float moveTimerDuration;
    private Vector3 moveEndPos;
    private Vector3 moveStartPos;

    private void Update()
    {
        Movement();
    }
    private void OnCollisionEnter(Collision collision)
    {
        bash = collision.gameObject.GetComponent<Bash>();

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
            if (hit > 3)
            {
                spawner.Spawn(spawner.spawnPos.position);
                Move();
            }
        }
    }

    public void Move()
    {
        Vector3 targetPos = transform.position + Vector3.right * _move;
        transform.position = new Vector3(6, 0.75f, 0);
        SetMove(targetPos);

        if (transform.position == new Vector3(6, 0.75f, 0))
        {
            Debug.Log("Cubes");
            if (bash.upSpeed >= 150)
            {
                destroySpeed = 1;
                Destroy(gameObject, destroySpeed);
            }

            Destroy(gameObject, 2.5f);
        }
    }

    private void Movement()
    {
        if (moveTimerCounter < moveTimerDuration)
        {
            moveTimerCounter += Time.deltaTime;
            spawner.transform.position = Vector3.Lerp(moveStartPos, moveEndPos, moveTimerCounter / moveTimerDuration);
        }

        else
        {
            moveTimer = false;
            moveTimerCounter = 0;
            spawner.transform.position = moveEndPos;
        }
    }

    private void SetMove(Vector3 endPos)
    {
        moveStartPos = transform.position;
        moveEndPos = endPos;
        moveTimer = true;
    }
}
