using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldController : MonoBehaviour {
    [SerializeField] private int shieldCooldown;
    private float currentCooldown;
    private Slider cooldownSlider;

    void Start() {
        gameObject.SetActive(false);
        cooldownSlider = GameObject.Find("ShieldSlider").GetComponent<Slider>();
        currentCooldown = shieldCooldown;
    }

    void Update() {
        if (currentCooldown < shieldCooldown) {
            currentCooldown += Time.deltaTime;
            cooldownSlider.value = Mathf.Clamp01(currentCooldown / shieldCooldown);
        }
    }

    public bool Enable() {
        if (currentCooldown >= shieldCooldown) {
            gameObject.SetActive(true);
            currentCooldown = 0;
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
