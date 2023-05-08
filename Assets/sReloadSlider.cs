using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sReloadSlider : MonoBehaviour
{
    public Slider reloadSlider;
    public float maxValue;
    public float currentValue;

    void Awake()
    {
        reloadSlider = gameObject.GetComponent<Slider>();
        reloadSlider.maxValue = maxValue;
        reloadSlider.minValue = 0;
        reloadSlider.wholeNumbers = false;
        reloadSlider.interactable = false;
    }

    private void Update()
    {
        reloadSlider.maxValue = maxValue;
        reloadSlider.value = currentValue;
    }
}
