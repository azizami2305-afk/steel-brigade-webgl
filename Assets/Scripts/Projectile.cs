using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 18f;
    public int damage = 10;
    Vector3 direction;
    bool useArc = false;
    float arcSpeed = 0f;
    float life = 3f;
    float born;

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        born = Time.time;
    }

    void Update()
    {
        if (Time.time - born > life) gameObject.SetActive(false);

        if (!useArc)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = direction * arcSpeed + Vector3.up * 4f;
        }
    }

    public void SetDirection(Vector3 dir)
    {
        useArc = false;
        direction = dir.normalized;
    }

    public void SetArcLaunch(float speed, float verticalFactor)
    {
        useArc = true;
        arcSpeed = speed;
        direction = transform.right;
    }

    public void SetDamage(int d)
    {
        damage = d;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var hit = other.GetComponent<HealthComponent>();
            if (hit != null) hit.ApplyDamage(damage);
            gameObject.SetActive(false);
        }
    }
}
