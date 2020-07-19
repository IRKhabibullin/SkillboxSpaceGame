using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour {

    [SerializeField] private float speed = 50f;

    // used to avoid triggering with ship that instantiated this shot. Value is set from ShipController in Shoot method
    public GameObject shootedShip;

    void Start() {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ship") && other.gameObject != shootedShip) {
            EnemyController ship = other.gameObject.GetComponent<EnemyController>();
            if (ship) {
                GameObject.Find("GameManager").GetComponent<GameController>().UpdateEnergy(ship.energyBounty);
                GameObject.Find("GameManager").GetComponent<GameController>().UpdateScore(ship.scoreBounty);
            }
            other.gameObject.GetComponent<ShipController>().Explode();
            Destroy(gameObject);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Asteroid")) {
            AsteroidController asteroid = other.gameObject.GetComponent<AsteroidController>();
            GameObject.Find("GameManager").GetComponent<GameController>().UpdateEnergy(asteroid.energyBounty);
            GameObject.Find("GameManager").GetComponent<GameController>().UpdateScore(asteroid.scoreBounty);
            asteroid.Explode();
            Destroy(gameObject);
        }
    }
}
