using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sEnemy : MonoBehaviour
{
    public int currentHP = 100;
    private int maxHP = 100;
    public int damagePlayer = 10;

    public Material material;
    public Color color;
    private bool timeToDamage = true;

    private bool isLive = true;

    void Awake()
    {
        material = gameObject.GetComponent<Renderer>().material;
        color = material.color;
        material.SetColor("_Color", Color.green);
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            isLive = false;
            material.SetColor("_Color", color);
        }
    }
    protected IEnumerator damage()
    {
        material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(.1f);
        material.SetColor("_Color", Color.green);
    }

    public void bulletDamage(int receivedDamage)
    {
        if (currentHP > 0)
        {
            currentHP -= receivedDamage;
            StartCoroutine(damage());
        }
        else if (currentHP <= 0)
        {
            isLive = false;
            material.SetColor("_Color", color);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && timeToDamage == true && isLive == true)
        {
            collision.gameObject.GetComponent<sPlayerController_02>().currentHP -= damagePlayer;
        }
    }

    protected IEnumerator dmgPlayer()
    {
        timeToDamage = false;
        yield return new WaitForSeconds(2);
        timeToDamage = true;
    }
}
