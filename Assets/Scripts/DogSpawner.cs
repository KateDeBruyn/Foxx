using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogSpawner : MonoBehaviour
{
    #region Spawn
    public GameObject dogPrefab;
    [SerializeField]
    private Transform _spawnPos;
    [SerializeField]
    private float _spawnTime = 15f;
    #endregion

    void Start()
    {
        InvokeRepeating ("Spawn", _spawnTime, _spawnTime);
    }


    private void Spawn()
    {
        GameObject dog = GameObject.Instantiate(dogPrefab, _spawnPos.position, Quaternion.identity);
    }
}
