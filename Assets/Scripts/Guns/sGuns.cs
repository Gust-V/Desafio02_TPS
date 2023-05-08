using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGuns : MonoBehaviour
{
    public sHUD_Ammunition ammunitionHUD;
    public sReloadSlider reloadHUD;
    public int currentAmmoStock { get; set; }
    public int currentAmmo { get; set; }
    protected int maxCurrentAmmo { get; set; }
    protected int maxAmmoStock { get; set; }
    protected float reloadTime { get; set; }
    protected float caddenceShoot { get; set; }
    protected int dammage { get; set; }

    public bool isShoot = false;

    public float timeReloading;
    private bool isReloadingNow = false;

    public GameObject bulletPrefab;
    public Transform bulletParent;

    protected void shoot(RaycastHit hit, bool hitTarget, Transform camera, int trgType)
    {
        if (currentAmmo > 0 && isShoot == false && isReloadingNow == false)
        {
            isShoot = true;
            RaycastHit hitGun = hit;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, this.transform.GetChild(0).transform.position, Quaternion.identity, bulletParent);
            sBullet bulletController = bullet.GetComponent<sBullet>();

            if (hitTarget == true)
            {
                if (trgType == 7)
                {
                    hitGun.transform.gameObject.GetComponent<sEnemy>().bulletDamage(dammage);
                }
                bulletController.target = hitGun.point;
                bulletController.hit = true;
                bulletController.targetType = trgType;
               
            }
            else
            {
                bulletController.target = camera.position + camera.forward * 25f;
                bulletController.hit = false;
            }

            currentAmmo--;
            StartCoroutine(isShootting());
            Debug.Log("shoot");
        }
        else
        {
            Debug.Log("No ammunition or some else");
        }
    }

    protected void reload()
    {
        if (currentAmmo < maxCurrentAmmo)
        {
            if (currentAmmoStock == 0)
            {
                Debug.Log("No ammunition in stock");
            }
            else
            {
                StartCoroutine(isReloading());
            }
        }
        else
        {
            Debug.Log("full ammunation");
        }
    }

    protected IEnumerator isShootting()
    {
        isShoot = true;
        yield return new WaitForSeconds(caddenceShoot);
        isShoot = false;
    }

    protected IEnumerator isReloading()
    {
        isReloadingNow = true;
        reloadHUD.gameObject.SetActive(true);
        yield return new WaitForSeconds(reloadTime);
        isReloadingNow = false;
        currentAmmoStock -= (maxCurrentAmmo - currentAmmo);
        if (currentAmmoStock < 0)
        {
            currentAmmo += (maxCurrentAmmo - currentAmmo) + currentAmmoStock;
            currentAmmoStock = 0;
        }
        else
        {
            currentAmmo += (maxCurrentAmmo - currentAmmo);
        }
        reloadHUD.gameObject.SetActive(false);
        timeReloading = 0;
    }
    
    public void stopReload()
    {   
        if(isReloadingNow == true)
        {
            StopCoroutine(isReloading());
            timeReloading = 0;
            isReloadingNow = false;
            reloadHUD.gameObject.SetActive(false);
        }
        isShoot = false;
    }

    private void Update()
    {
        if (isReloadingNow == true)
        {
            timeReloading += Time.deltaTime;
        }

        ammunitionHUD.textMesh.text = currentAmmo.ToString() + "/" + currentAmmoStock.ToString();

        
        reloadHUD.maxValue = reloadTime;
        reloadHUD.currentValue = timeReloading;

    }
}
