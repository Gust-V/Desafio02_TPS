using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sLife_Collectable : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.tag = "Life_Collectable";
    }
}
