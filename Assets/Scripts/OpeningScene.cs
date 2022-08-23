using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpeningScene : MonoBehaviour
{
   
    public AudioSource hunterAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CameraZoomOut());
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    IEnumerator CameraZoomOut()
    {
        yield return new WaitForSeconds(4);
        transform.DOMoveZ(25, 4);
        hunterAudioSource.Play();
        yield return new WaitForSeconds(5);
        this.gameObject.SetActive(false);



    }

}
