using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGun02 : sGuns
{
    private void Awake()
    {
        currentAmmoStock = 25;
        currentAmmo = 7;
        maxCurrentAmmo = 7;
        maxAmmoStock = 25;
        reloadTime = 3f;
        caddenceShoot = 1.0f;
        dammage = 35;
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
