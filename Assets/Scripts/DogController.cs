using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogController : MonoBehaviour
{
    //Enemy (dog) controller script by Katie
    #region Nav Mesh
    private NavMeshAgent dogNavMeshAgent;
    public Transform playerPosition;
    #endregion

    #region Speed
    public Transform dogPos;
    public float dogSpeedMax = 10f;
    public float dogSpeedMin = 7.5f;
    //public Collider dogCollider;
    #endregion

    #region Health
    [SerializeField]
    private int dogHealth;

    //Player's health and damage
    [SerializeField]
    private int dogDamage;
    public GameObject GM;
    private GameManager gameManager;
    #endregion


    private void Awake() {
        dogNavMeshAgent = GetComponent<NavMeshAgent>();
        //dogCollider = GetComponent<Collider>();

        gameManager = GM.GetComponent<GameManager>();
    }

    void Start()
    {
        dogHealth = 3;
        dogDamage = 3;
    }


    void Update()
    {

        dogNavMeshAgent.destination = playerPosition.position;

        this.GetComponent<NavMeshAgent>().speed = dogSpeedMax;

        if(dogHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    /*private void Speed(){

        Vector3 direction = new Vector3(dogPos.position.x, 0, dogPos.position.y);
        dogNavMeshAgent.Move(direction * Time.deltaTime * dogSpeed);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player"){

            this.gameObject.GetComponent<NavMeshAgent>().speed = dogSpeedMin;

            gameManager.currenthealth -= dogDamage;

            Debug.Log(gameManager.currenthealth);

        }  

        if(collision.gameObject.tag == "Bullet"){

            dogHealth -= 1;
            Debug.Log(dogHealth);
        }  
    }



}
