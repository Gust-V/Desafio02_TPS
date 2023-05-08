using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sHealthSlider : MonoBehaviour
{
    private Slider hpSlider;
    public sPlayerController_02 player;

    void Awake()
    {
        hpSlider = gameObject.GetComponent<Slider>();
        hpSlider.maxValue = player.maxHP;
        hpSlider.minValue = 0;
        hpSlider.wholeNumbers = true;
        hpSlider.interactable = false;
    }

    void Update()
    {
        hpSlider.value = player.currentHP;
    }
}
