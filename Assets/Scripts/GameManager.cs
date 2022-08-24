using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float Amo = 30f;

    public float currenthealth = 20f;
    public float maxhealth = 20f;

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
       // This also wouldn't update to the true value if its not related to the reloadscript. This will only
       // ever show the ammo going from 10 to 0.
        bulletCountTxt.text = Amo.ToString();

        if (currenthealth <= 0)
        {
            SceneManager.LoadScene("DeadScene");
        }
    }
}
