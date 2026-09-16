using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public enum WeaponType { Rifle, Shotgun, Grenade }
    public WeaponType currentWeapon = WeaponType.Rifle;

    public Transform firePoint;
    public ProjectilePool projectilePool;

    public float fireRate = 0.15f;
    float nextFireTime = 0f;

    void Start()
    {
        if (projectilePool == null)
            projectilePool = FindObjectOfType<ProjectilePool>();
    }

    public void Fire()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;

        switch (currentWeapon)
        {
            case WeaponType.Rifle:
                FireRifle();
                break;
            case WeaponType.Shotgun:
                FireShotgun();
                break;
            case WeaponType.Grenade:
                FireGrenade();
                break;
        }
    }

    void FireRifle()
    {
        var p = projectilePool.GetProjectile();
        p.transform.position = firePoint.position;
        p.SetDirection(transform.right);
        p.SetDamage(10);
        p.gameObject.SetActive(true);
    }

    void FireShotgun()
    {
        int pellets = 6;
        float spread = 12f;
        for (int i = 0; i < pellets; i++)
        {
            float angle = Mathf.Lerp(-spread, spread, i / (float)(pellets - 1));
            Vector3 dir = Quaternion.Euler(0, 0, angle) * transform.right;
            var p = projectilePool.GetProjectile();
            p.transform.position = firePoint.position;
            p.SetDirection(dir);
            p.SetDamage(6);
            p.gameObject.SetActive(true);
        }
    }

    void FireGrenade()
    {
        var p = projectilePool.GetProjectile();
        p.transform.position = firePoint.position;
        p.SetArcLaunch(6f, 0.6f);
        p.SetDamage(40);
        p.gameObject.SetActive(true);
    }
}
