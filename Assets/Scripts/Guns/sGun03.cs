using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sGun03 : sGuns
{
    private void Awake()
    {
        currentAmmoStock = 3;
        currentAmmo = 1;
        maxCurrentAmmo = 1;
        maxAmmoStock = 3;
        reloadTime = 5f;
        caddenceShoot = 1f;
        dammage = 100;
    }
    public void isShotting(RaycastHit hit, bool hitTarget, Transform camera, int trgType)
    {
        shoot(hit, hitTarget, camera, trgType);
    }

    public void Reloading()
    {
        reload();
    }

}
