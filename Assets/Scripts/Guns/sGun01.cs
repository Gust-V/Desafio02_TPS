using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sGun01 : sGuns
{
    private void Awake()
    {
        currentAmmoStock = 20;
        currentAmmo = 10;
        maxCurrentAmmo = 10;
        maxAmmoStock = 20;
        reloadTime = 2f;
        caddenceShoot = 0.3f;
        dammage = 20;
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
