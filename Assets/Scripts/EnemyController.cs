using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    public bool followAlways = false;
    #endregion

    #region Health
    [SerializeField]
    private int hunterHealth;
    #endregion

    private void Awake() {
        _enemyNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        hunterHealth = 50;
    }


    void Update()
    {
        InitiateFollow();

        if(followAlways == true)
        {
             _enemyNavMeshAgent.destination = playerPos.position;
        }

        if (hunterHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("EndScene");
        }


    }

    private void InitiateFollow()
    {
        distanceA = Vector3.Distance(hunter.transform.position, player.transform.position);

        if(distanceA <= 25){

            _enemyNavMeshAgent.destination = playerPos.position;
            followAlways = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {

            hunterHealth -= 1;
            Debug.Log(hunterHealth);
        }
    }

}
