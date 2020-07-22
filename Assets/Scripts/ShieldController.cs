using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour {
    [SerializeField] private int shieldCooldown;
    private float currentCooldown;
    private Slider cooldownSlider;
    public GameObject shieldOwner;

    void Start() {
        Toggle(false);
        cooldownSlider = GameObject.Find("ShieldSlider").GetComponent<Slider>();
        currentCooldown = shieldCooldown;
    }

    void Update() {
        if (currentCooldown < shieldCooldown) {
            currentCooldown += Time.deltaTime;
            cooldownSlider.value = Mathf.Clamp01(currentCooldown / shieldCooldown);
        }
    }

    public bool Activate() {
        if (currentCooldown >= shieldCooldown) {
            Toggle(true);
            currentCooldown = 0;
            return true;
        }
        return false;
    }

    private void Toggle(bool value) {
        GetComponent<MeshRenderer>().enabled = value;
        GetComponent<SphereCollider>().enabled = value;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Lazer")) {
            if (other.gameObject.GetComponent<LazerScript>().shootedShip == shieldOwner) {
                return;
            }
            Destroy(other.gameObject);
            Toggle(false);
        } else if (other.gameObject.layer == LayerMask.NameToLayer("Asteroid")) {
            AsteroidController asteroid = (AsteroidController)other.gameObject.GetComponent<AsteroidController>();
            asteroid.Explode();
            Toggle(false);
        }
    }
}
