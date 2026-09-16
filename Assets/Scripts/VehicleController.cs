using UnityEngine;

public class VehicleController : MonoBehaviour
{
    public Transform mountPoint;
    public float moveSpeed = 3f;
    public WeaponSystem turretWeapon;
    public int health = 200;

    bool occupied = false;
    GameObject occupant;

    void Update()
    {
        if (!occupied) return;

        float h = InputHandler.GetHorizontal();
        transform.position += new Vector3(h * moveSpeed * Time.deltaTime, 0, 0);

        if (InputHandler.FirePressed())
        {
            turretWeapon?.Fire();
        }

        if (InputHandler.MountTogglePressed())
        {
            Dismount();
        }
    }

    public void Mount(GameObject player)
    {
        occupied = true;
        occupant = player;
        player.transform.position = mountPoint.position;
        player.SetActive(false);
    }

    public void Dismount()
    {
        if (!occupied) return;
        occupant.SetActive(true);
        occupant.transform.position = mountPoint.position + Vector3.up * 1.2f;
        occupant = null;
        occupied = false;
    }

    public void ApplyDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0) DestroyVehicle();
    }

    void DestroyVehicle()
    {
        // TODO: explosion VFX, camera shake
        Destroy(gameObject);
    }
}
