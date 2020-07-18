using UnityEngine;

public class EnemyController : MonoBehaviour {
    private ShipController ship;
    private GameObject player;
    [SerializeField] private float flightAngle;

    void Start() {
        ship = GetComponent<ShipController>();
        player = GameObject.Find("PlayerShip");
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -ship.speed);
        Vector3 shipAngle = transform.rotation.eulerAngles;
        shipAngle.y = -180f + Random.Range(-flightAngle, flightAngle);
        transform.rotation = Quaternion.Euler(shipAngle);
    }

    void Update() {
        if (player == null) {
            return;
        }
        // AI thingy
        if (Time.time > ship.GetMainGunCooldown() + ship.gunCooldown) {
            Quaternion direction = Quaternion.LookRotation(player.transform.position - transform.position);
            ship.Shoot(direction);
        }
    }
}
