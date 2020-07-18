using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerShipController ship;

    void Start() {
        ship = GetComponent<PlayerShipController>();
    }

    void Update() {
        float input = Input.GetAxis("Horizontal");
        if (input != 0) {
            ship.Move(input);
        }

        if (Input.GetButton("Fire1")) {
            ship.Shoot();
        }
        if (Input.GetButton("Fire2")) {
            ship.ShootBySideGuns();
        }
    }
}
