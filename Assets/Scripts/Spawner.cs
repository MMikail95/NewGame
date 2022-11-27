using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    [SerializeField] List<Cube> _cubes;

    private void Start()
    {
        Spawn(spawnPos.position);
    }

    public void Spawn(Vector3 pos)
    {
        Cube cube = Instantiate(_cubes[Random.Range(0, 3)], pos/* + new Vector3(4, 0.75f, 0)*/, Quaternion.identity);
        cube.spawner = this;
    }
}
