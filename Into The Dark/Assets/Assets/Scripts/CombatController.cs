using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

    [HideInInspector]
    public int health;
    public int maxHealth;
    public int damage;

    private Animator anim;

    // Use this for initialization
    void Start() {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0)
            StartCoroutine(deathTransition());
    }

    public void isAttacked(CombatController cc) {
        if (cc != null) {
            health -= cc.damage;
        }
    }

    public IEnumerator deathTransition()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        anim.SetTrigger("dead");
        GetComponent<Rigidbody>().detectCollisions = false; //stops taking damage during animation
        float animLength = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animLength);
        GameLogicScript.score += 10;
        Destroy(this.gameObject);
    }
}