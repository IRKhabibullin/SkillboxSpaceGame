using UnityEngine;

public class AsteroidController : MonoBehaviour {
    Rigidbody asteroid;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float speed = 25;
    [SerializeField] private int size;

    public float energyBounty;
    public int scoreBounty;

    [SerializeField] private GameObject asteroidExplosion;

    void Start() {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = new Vector3(0, 0, -speed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "GameBoundary") {
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Ship")) {
            other.gameObject.GetComponent<ShipController>().Explode();
        }
        Explode();
    }
    public void Explode() {
        GameObject explosion = Instantiate(asteroidExplosion, gameObject.transform.position, Quaternion.identity);
        explosion.transform.localScale = explosion.transform.localScale * size;
        Destroy(gameObject);
    }
}
