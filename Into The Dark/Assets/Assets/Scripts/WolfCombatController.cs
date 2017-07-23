using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCombatController : MonoBehaviour {

    private CombatController cc;

    // Use this for initialization
    void Start() {
        cc = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hammer") && GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("attacking")) {
            cc.isAttacked(GameObject.FindGameObjectWithTag("Player").GetComponent<CombatController>());
        }
    }
}
