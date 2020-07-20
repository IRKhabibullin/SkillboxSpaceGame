using UnityEngine;

public class EnemyController : MonoBehaviour {
    private ShipController ship;
    private GameObject player;
    [SerializeField] private float flightAngle;
    [SerializeField] private float shootDistance;
    public float energyBounty;
    public int scoreBounty;

    void Start() {
        ship = GetComponent<ShipController>();
        player = GameObject.Find("PlayerShip");
        Vector3 shipAngle = transform.rotation.eulerAngles;
        shipAngle.y = -180f + Random.Range(-flightAngle, flightAngle);
        transform.rotation = Quaternion.Euler(shipAngle);
        GetComponent<Rigidbody>().velocity = transform.forward * ship.speed;
    }

    void Update() {
        if (player == null) {
            return;
        }
        // AI thingy
        if (Time.time > ship.GetMainGunCooldown() + ship.gunCooldown && transform.position.z > shootDistance) {
            Quaternion direction = Quaternion.LookRotation(player.transform.position - transform.position);
            ship.Shoot(direction);
        }
    }
}
