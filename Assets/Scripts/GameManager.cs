using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float Amo = 10f;

    public float currenthealth = 10f;
    public float maxhealth = 10f;

    public GameObject player;
    PlayerController playerController;

    public TextMeshProUGUI bulletCountTxt;


    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
        bulletCountTxt.text = Amo.ToString();
    }
}
