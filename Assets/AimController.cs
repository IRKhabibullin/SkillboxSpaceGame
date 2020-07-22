using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour {
    private LineRenderer aim_line;
    private Transform mainGun;

    void Start() {
        aim_line = GetComponent<LineRenderer>();
        aim_line.positionCount = 2;

        mainGun = GameObject.Find("MainGun").transform;
        aim_line.SetPosition(0, mainGun.position);
    }

    void Update() {
    	aim_line.SetPosition(0, mainGun.position);
    	RaycastHit hit;
        if (Physics.Raycast(mainGun.position, mainGun.forward, out hit, 200, LayerMask.GetMask("Asteroid", "Ship"))) {
        	aim_line.SetPosition(1, hit.point);
        } else {
        	aim_line.SetPosition(1, mainGun.position + mainGun.forward * 200);
        }
    }
}
