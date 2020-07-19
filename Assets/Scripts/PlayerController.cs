using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private PlayerShipController ship;
    private GameController game;
    private ShieldController energyShield;

    [SerializeField] private int shieldCost;
    [SerializeField] private int shotCost;
    [SerializeField] private GameObject shieldPrefab;

    void Start() {
        ship = GetComponent<PlayerShipController>();
        game = GameObject.Find("GameManager").GetComponent<GameController>();
        GameObject shield = Instantiate(shieldPrefab, gameObject.transform.position, Quaternion.identity);
        shield.transform.SetParent(gameObject.transform);
        energyShield = shield.GetComponent<ShieldController>();
    }

    void Update() {
        float input = Input.GetAxis("Horizontal");
        if (input != 0) {
            ship.Move(input);
        }

        float currentEnergy = game.GetCurrentEnergy();
        if (Input.GetButton("Fire1") && currentEnergy >= shotCost) {
            if (ship.Shoot()) {
                game.UpdateEnergy(-shotCost);
            }
        }
        if (Input.GetButton("Fire2") && currentEnergy >= shotCost) {
            if (ship.ShootBySideGuns()) {
                game.UpdateEnergy(-shotCost);
            }
        }
        if (Input.GetKeyDown("space") && currentEnergy >= shieldCost) {
            if (energyShield.Enable()) {
                game.UpdateEnergy(-shieldCost);
            }
        }
    }
}
