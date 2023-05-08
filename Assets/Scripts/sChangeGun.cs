using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sChangeGun : MonoBehaviour
{
    public sHUD_Ammunition actualGunHUD;

    public List<GameObject> Guns = new List<GameObject>();
    
    public GameObject activeGun;

    public int selectedGun = 0;

    private void Start()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            Guns.Add(this.gameObject.transform.GetChild(i).gameObject);
        }

        SelectGun();

        activeGun = Guns[0];
    }

    // Update is called once per frame
    void Update()
    {
        actualGunHUD.textMesh.text = activeGun.name;
    }

    public void ChangeGuns(float direction)
    {
        int previousSelectedGun = selectedGun;
        activeGun.GetComponent<sGuns>().stopReload();
        if(direction > 0)
        {
            if (selectedGun >= transform.childCount - 1)
            {
                selectedGun = 0;
            }
            else
            {
                selectedGun++;
            }
        }
        else if (direction < 0)
        {
            if (selectedGun <= 0)
            {
                selectedGun = transform.childCount - 1;
            }
            else
            {
                selectedGun--;
            }
        }

        if(previousSelectedGun != selectedGun)
        {
            SelectGun();
        }

    }

    public void MenuGun(float x, float y)
    {
        activeGun.GetComponent<sGuns>().stopReload();
        if (y > 0)
        {
            selectedGun = 0;
        }
        else if (y < 0)
        {
            selectedGun = 1;
        }
        else if (x > 0)
        {
            selectedGun = 3;
        }
        else if (x < 0)
        {
            selectedGun = 2;
        }
        SelectGun();
    }

    public void SelectGun()
    {
        int i = 0;
        foreach (Transform gun in transform)
        {
            if(i == selectedGun)
            {
                gun.gameObject.SetActive(true);
                activeGun = Guns[i];
            }
            else
            {
                gun.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
