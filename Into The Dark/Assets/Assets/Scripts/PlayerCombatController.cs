using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour {

    public float attackRange;
    public Slider healthBar, rageBar, skillCDImg1, skillCDImg2, skillCDImg3;
    public float ultiDistance;

    private Animator anim;

    private bool autoR, spinR, slamR; // Which abilities are ready
    private double auto, spin, slam;  // Timers
    public double autoCD,       // Cooldown timer
                    spinCD,
                    slamCD;

    private CombatController cc;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        cc = GetComponent <CombatController>();
        rageBar.value = 0;
    }

    // Update is called once per frame
    void Update() {
        if (tag.Equals("Player")) {
            if (!anim.GetBool("attacking")) {
                if (Input.GetButtonDown("Fire1") && autoR) {
                    skillCDImg1.value = 60;
                    attack(0);
                } else if (Input.GetButtonDown("Fire2") && slamR) {
                    skillCDImg2.value = 60;
                    attack(1);
                } else if (Input.GetButtonDown("Fire3") && spinR) {
                    skillCDImg3.value = 60;
                    attack(2);
                } else if (Input.GetButtonDown("Fire4") && rageBar.value == rageBar.maxValue) {
                    rageBar.value = 0;
                    attack(3);
                }
            }
            updateTimers();
        }
        
    }

    private void updateTimers() {
        autoR = ((auto -= Time.fixedDeltaTime) <= 0);
        slamR = (slam -= Time.fixedDeltaTime) <= 0;
        spinR = (spin -= Time.fixedDeltaTime) <= 0;
        if (skillCDImg1 != null && skillCDImg2 != null && skillCDImg3 != null) {
            skillCDImg1.value -= skillCDImg1.value <= 0 ? 0 : (float)((60 * Time.fixedDeltaTime)/ autoCD);
            skillCDImg2.value -= skillCDImg2.value <= 0 ? 0 : (float)((60 * Time.fixedDeltaTime) / slamCD);
            skillCDImg3.value -= skillCDImg3.value <= 0 ? 0 : (float)((60 * Time.fixedDeltaTime) / spinCD);
        }
    }

    public void attack(int attackType) {
        switch (attackType) {
            case 0:
                if (autoR) {
                    anim.SetTrigger("autoAttack");
                    auto = autoCD;
                    rageBar.value++;
                }
                break;
            case 1:
                if (slamR) {
                    anim.SetTrigger("slamAttack");
                    slam = slamCD;
                    rageBar.value += 3;
                }
                break;
            case 2:
                if (spinR) {
                    anim.SetTrigger("spinAttack");
                    spin = spinCD;
                    rageBar.value += 3;
                }
                break;
            case 3:
                GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i=0; i<go.Length; i++) {
                    if ((go[i].transform.position - transform.position).magnitude <= ultiDistance) {
						CombatController cc = go [i].GetComponent<CombatController> ();
						cc.StartCoroutine(cc.deathTransition());
                    }
                }
                break;
        }
    }

    // If we get attacked (wolf mouth or skeleton sword or ghost sword)
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyAttack") && other.GetComponentInParent<Animator>().GetBool("attacking")) {
            cc.isAttacked(other.gameObject.GetComponentInParent<CombatController>());
            healthBar.value = cc.health;
        }
    }
}