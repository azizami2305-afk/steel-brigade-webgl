using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int initialSize = 32;

    GameObject[] pool;

    void Awake()
    {
        pool = new GameObject[initialSize];
        for (int i = 0; i < initialSize; i++)
        {
            var go = Instantiate(projectilePrefab, transform);
            go.SetActive(false);
            pool[i] = go;
        }
    }

    public Projectile GetProjectile()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
                return pool[i].GetComponent<Projectile>();
        }

        // Expand pool if none free
        var go = Instantiate(projectilePrefab, transform);
        go.SetActive(false);
        System.Array.Resize(ref pool, pool.Length + 1);
        pool[pool.Length - 1] = go;
        return go.GetComponent<Projectile>();
    }
}
