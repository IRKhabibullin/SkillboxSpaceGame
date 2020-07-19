using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerShipController ship;
    private GameController game;

    void Start() {
        ship = GetComponent<PlayerShipController>();
        game = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    void Update() {
        float input = Input.GetAxis("Horizontal");
        if (input != 0) {
            ship.Move(input);
        }

        if (game.GetCurrentEnergy() >= 1) {
            if (Input.GetButton("Fire1")) {
                if (ship.Shoot()) {
                    game.UpdateEnergy(-1);
                }
            }
            if (Input.GetButton("Fire2")) {
                if (ship.ShootBySideGuns()) {
                    game.UpdateEnergy(-1);
                }
            }
        }
    }
}
