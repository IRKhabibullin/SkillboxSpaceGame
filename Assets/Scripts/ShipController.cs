using UnityEngine;

public class ShipController : MonoBehaviour {
    public float speed = 10f;
    [SerializeField] private float rotationTilt = 0.6f;
    [SerializeField] private float flightWidth = 40f;
    [SerializeField] protected GameObject lazer;
    [SerializeField] private GameObject shipExplosion;

    public float gunCooldown;
    [SerializeField] private Transform mainGun;
    protected float mainGunCooldown;

    private Rigidbody ship;

    void Start() {
        ship = GetComponent<Rigidbody>();
    }

    public float GetMainGunCooldown() {
        return mainGunCooldown;
    }

    public void Explode() {
        if (gameObject.tag == "Player") {
            GameObject.Find("GameManager").GetComponent<GameController>().GameOver();
        }
        Instantiate(shipExplosion, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Move(float direction) {
        //if (Math.Abs(player.position.x + input * speed) < spaceBorders) {
            ship.velocity = new Vector3(direction, 0f, 0f) * speed;
            ship.position = new Vector3(Mathf.Clamp(ship.position.x, -flightWidth, flightWidth), 0f, 0f);
            ship.rotation = Quaternion.Euler(0f, 0f, -ship.velocity.x * rotationTilt);
        //}

        //input = Input.GetAxis("Vertical");
        //if (input != 0) {
        //    player.velocity = new Vector3(input, 0f, 0f) * speed;
        //    //player.position = new Vector3(Mathf.Clamp(player.position.x, -spaceBorders, spaceBorders), 0f, 0f);
        //    player.rotation = Quaternion.Euler(0f, 0f, -player.velocity.x * rotationTilt);
        //}
    }

    public void Shoot() {
        Shoot(Quaternion.identity);
    }

    public void Shoot(Quaternion direction) {
        if (Time.time > mainGunCooldown + gunCooldown) {
            GameObject shot = Instantiate(lazer, mainGun.position, direction);
            shot.GetComponent<LazerScript>().shootedShip = gameObject;
            mainGunCooldown = Time.time;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ship")) {
            Explode();
        }
    }
}
