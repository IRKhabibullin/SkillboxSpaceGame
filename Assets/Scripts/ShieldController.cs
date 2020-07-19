using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {
    [SerializeField] private int shieldCooldown;
    private float shieldLastEnabled;

    void Start() {
        gameObject.SetActive(false);
    }

    public bool Enable() {
        if (Time.time + shieldCooldown > shieldLastEnabled) {
            gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Lazer")) {
            Destroy(other.gameObject);
            gameObject.SetActive(false);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Asteroid")) {
            AsteroidController asteroid = (AsteroidController)other.gameObject.GetComponent<AsteroidController>();
            asteroid.Explode();
            gameObject.SetActive(false);
        }
    }
}
