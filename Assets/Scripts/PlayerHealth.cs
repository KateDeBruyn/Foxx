using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image fillImage;
    private Slider slider;

    public GameManager GameManager;

    void Awake()
    {
        
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        else if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        float fillValue = GameManager.currenthealth / GameManager.maxhealth;

        if (fillValue <= slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }
        else if (fillValue > slider.maxValue / 3)
        {
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
    }

}
