using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sHUD_Ammunition : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    void Awake()
    {
        textMesh = gameObject.GetComponent<TextMeshProUGUI>();
    }
}
