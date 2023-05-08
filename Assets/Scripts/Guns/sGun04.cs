using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sGun04 : sGuns
{
    private void Awake()
    {
        currentAmmoStock = 90;
        currentAmmo = 30;
        maxCurrentAmmo = 30;
        maxAmmoStock = 90;
        reloadTime = 1f;
        caddenceShoot = 0f;
        dammage = 5;
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
