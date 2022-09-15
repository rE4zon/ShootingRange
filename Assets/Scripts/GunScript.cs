using System.Collections;
using UnityEngine;
using TMPro;

public class GunScript : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    [SerializeField] float fireRate = 15f;
    [SerializeField] float impactForce = 30f;
    [SerializeField] int maxAmmo = 10;
    public int currentAmmo;
    [SerializeField] float reloadAmmo = 1f;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] private AudioSource ShootSound;
    [SerializeField] private AudioSource GunReload;
    public Camera fpsCam;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject impactEffect;
    private bool isReloading;
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI ammoInfoText;
    [SerializeField] int magazineSize = 120;
    private bool isShooting;

    

    private void Start()
    {
        currentAmmo = maxAmmo;


    }

    private void Update()
    {
        if (currentAmmo == 0 && magazineSize == 0)
        {
            animator.SetBool("isShooting", false);
            return;
        }
        if (isReloading)
            return;
        GunScript currentGun = FindObjectOfType<GunScript>();
        ammoInfoText.text = currentGun.currentAmmo + " / " + currentGun.magazineSize;
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            ShootSound.Play();

            if (currentAmmo < 0)
            {
                StartCoroutine(Reload());
            }

        }

        IEnumerator Reload()
        {

            GunReload.Play();
            isReloading = true;
            Debug.Log("Reloading...");
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(reloadTime - .25f);
            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.25f);


            if (magazineSize >= maxAmmo)
            {
                currentAmmo = maxAmmo;
                magazineSize -= maxAmmo;
            }
            else
            {
                currentAmmo = magazineSize;
                magazineSize = 0;
            }
            isReloading = false;
        }

        void Shoot()
        {
            muzzleFlash.Play();
            currentAmmo--;

           
                    RaycastHit hit;
                    if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
                    {
                        Debug.Log(hit.transform.name);
                        Target target = hit.transform.GetComponent<Target>();
                        if(target != null)
                         {
                            target.TakeDamage(damage);
                         }
                    }
                    Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                }
        }
            
}
        