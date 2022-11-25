using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private Bash bash;
    private Cubes cubes;
    [SerializeField] Transform spawnPos;
    [SerializeField] List<Cubes> _cubes;

    private void Start()
    {
        Instantiate(_cubes[Random.Range(0, 3)], spawnPos.position, Quaternion.identity);
    }
    private void Update()
    {
        NewSpawn();
    }
    private void OnCollisionEnter(Collision collision)
    {
        cubes = collision.gameObject.GetComponent<Cubes>();
        bash = collision.gameObject.GetComponent<Bash>();
    }
    public void NewSpawn()
    {
        if (cubes.hit == 3)
        {
            Instantiate(_cubes[Random.Range(0, 3)], spawnPos.position + new Vector3(4, 0.75f, 0), Quaternion.identity);
        }

        else if (cubes.hit >= 4)
        {
            Instantiate(_cubes[Random.Range(0, 3)], spawnPos.position + new Vector3(4, 0.75f, 0), Quaternion.identity);
        }
    }
}
