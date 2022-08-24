using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReloadScript : MonoBehaviour
{
   
    public bool canReload;

    public GameManager GameManager;

    [SerializeField]
    private PlayerInput playerInput;


    private InputAction reloadAction;

    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Awake()
    {
        reloadAction = playerInput.actions["Reload"];
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    // Update is called once per frame
    void Update()
    {
       if(canReload == true)
        {
            rend.sharedMaterial = material[1];
        }
       else if(canReload == false)
        {
            rend.sharedMaterial = material[0];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if(GameManager.Amo <= 0)
            {
                canReload = true;
               
            }
            else if(GameManager.Amo <= 40)
            {
                canReload = false;
               
            }

        }
    }

   

    private void OnEnable()
    {
        reloadAction.performed += _ => Reload();

    }

    private void OnDisable()
    {
        reloadAction.performed -= _ => Reload();
    }



    public void Reload()
    {
        if (canReload == true)
        {
            GameManager.Amo += 30;
        }

    }
}
