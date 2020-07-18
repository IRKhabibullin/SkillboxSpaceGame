using UnityEngine;

public class PlayerShipController : ShipController {

    [SerializeField] private GameObject sideLazer;
    [SerializeField] private Transform leftGun;
    [SerializeField] private Transform rightGun;
    private float sideGunsCooldown;

    public void ShootBySideGuns() {
        if (Time.time > sideGunsCooldown + gunCooldown) {
            GameObject shot = Instantiate(sideLazer, rightGun.position, rightGun.rotation);
            shot.GetComponent<LazerScript>().shootedShip = gameObject;
            shot = Instantiate(sideLazer, leftGun.position, leftGun.rotation);
            shot.GetComponent<LazerScript>().shootedShip = gameObject;
            sideGunsCooldown = Time.time;
        }
    }
}
