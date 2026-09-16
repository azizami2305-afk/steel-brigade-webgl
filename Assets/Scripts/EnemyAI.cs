using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform leftPoint;
    public Transform rightPoint;
    public float patrolSpeed = 2f;
    public float shootInterval = 1.5f;

    Transform targetPoint;
    float nextShoot;
    WeaponSystem weapon;

    void Start()
    {
        targetPoint = rightPoint;
        weapon = GetComponent<WeaponSystem>();
        nextShoot = Time.time + shootInterval;
    }

    void Update()
    {
        Patrol();
        if (Time.time > nextShoot)
        {
            nextShoot = Time.time + shootInterval;
            weapon?.Fire();
        }
    }

    void Patrol()
    {
        Vector3 dir = (targetPoint.position - transform.position).normalized;
        transform.position += new Vector3(dir.x, 0, 0) * patrolSpeed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - targetPoint.position.x) < 0.1f)
        {
            targetPoint = (targetPoint == rightPoint) ? leftPoint : rightPoint;
            // flip facing
            Vector3 rot = transform.eulerAngles;
            rot.y += 180f;
            transform.eulerAngles = rot;
        }
    }
}
