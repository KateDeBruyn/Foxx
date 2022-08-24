using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterBullets : MonoBehaviour
{
    #region Spawn
    public GameObject hunterBulletPrefab;
    [SerializeField]
    private Transform _spawnPosHunterBullet;
    [SerializeField]
    private float _spawnTime = 4f;
    public GameObject hunter;
    private EnemyController enemyController;
    private bool _followingHB;
    #endregion

    private void Awake() {
        enemyController = hunter.GetComponent<EnemyController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _followingHB = enemyController.followAlways;

    }

    private void InvokeSpawn(){
        if(_followingHB == true){
            InvokeRepeating ("Spawn", _spawnTime, _spawnTime);
            Debug.Log("spawned bullet");
        }
    }

    private void Spawn()
    {
        GameObject hunterBullet = GameObject.Instantiate(hunterBulletPrefab, _spawnPosHunterBullet.position, Quaternion.identity);
    }
}
