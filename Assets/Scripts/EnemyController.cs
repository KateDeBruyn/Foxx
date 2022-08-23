using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemy (hunter) controller script by Katie
    #region Nav Mesh
    private NavMeshAgent _enemyNavMeshAgent;
    #endregion

    #region Initiate Follow
    public GameObject hunter, player;
    public Transform playerPos;
    public float distanceA;
    private bool _followAlways = false;
    #endregion

    private void Awake() {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }


    void Update()
    {
        InitiateFollow();

        if(_followAlways == true)
        {
             _enemyNavMeshAgent.destination = playerPos.position;
        }
    }

    private void InitiateFollow()
    {
        distanceA = Vector3.Distance(hunter.transform.position, player.transform.position);

        if(distanceA <= 25){

            _enemyNavMeshAgent.destination = playerPos.position;
            _followAlways = true;
        }
    }

}
