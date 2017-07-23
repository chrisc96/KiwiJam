using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatController : MonoBehaviour {

    public GameObject target;

    private CombatController cc;
    private Animator anim;

    private double auto = 10, basic = 10, side = 10, spin = 10, slam = 10;   //Timers
    public double autoCD = 10,                   //Cooldown times
                    basicCD = 10,
                    sideCD = 10,
                    spinCD = 10,
                    slamCD = 10;

    private bool autoR, basicR, sideR, spinR, slamR; //Which abilities are ready

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        cc = GetComponent<CombatController>();
    }

    // Update is called once per frame
    void Update() {
        updateTimers();
        if ((autoR || basicR || sideR || slamR || spinR) && anim.GetBool("withinAttackRange"))
            attack();
    }

    private void updateTimers() {
        autoR = (auto -= Time.deltaTime) <= 0;
        basicR = (basic -= Time.deltaTime) <= 0;
        sideR = (side -= Time.deltaTime) <= 0;
        slamR = (slam -= Time.deltaTime) <= 0;
        spinR = (spin -= Time.deltaTime) <= 0;
    }

    private void attack() {
        int attackType = (int)(Random.value * 4);
        switch (attackType) {
            case 0:
                if (autoR) {
                    anim.SetTrigger("autoAttack");
                    auto = autoCD;
                    return;
                }
                goto case 1;
            case 1:
                if (basicR) {
                    anim.SetTrigger("basicAttack");
                    basic = basicCD;
                    return;
                }
                goto case 2;
            case 2:
                if (sideR) {
                    anim.SetTrigger("sideAttack");
                    side = sideCD;
                    return;
                }
                goto case 3;
            case 3:
                if (slamR) {
                    anim.SetTrigger("slamAttack");
                    slam = slamCD;
                    return;
                }
                goto case 4;
            case 4:
                if (spinR) {
                    anim.SetTrigger("spinAttack");
                    spin = spinCD;
                    return;
                }
                goto case 0;
        }
    }

    // Player hitting enemy (other = hammer's collider)
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Hammer") && GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().GetBool("attacking")) {
            cc.isAttacked(GameObject.FindGameObjectWithTag("Player").GetComponent<CombatController>());
        }
    }
}
