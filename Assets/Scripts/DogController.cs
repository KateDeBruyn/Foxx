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
    #endregion


    private void Awake() {
        dogNavMeshAgent = GetComponent<NavMeshAgent>();
        //dogCollider = GetComponent<Collider>();
    }

    void Start()
    {
        dogHealth = 3;
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

            Debug.Log("I'm a slow boi");
            this.GetComponent<NavMeshAgent>().speed = dogSpeedMin;
        }  

        if(collision.gameObject.tag == "Bullet"){

            dogHealth -= 1;
            Debug.Log(dogHealth);
        }  
    }



}
