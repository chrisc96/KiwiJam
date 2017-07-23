using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private float spawnTime = 6;
    public float delay;
    public GameObject enemy;

    private float timeOffset;

    private float repeatingTimer;

    // Use this for initialization
    void Start() {
        repeatingTimer = Time.time * 1000;
        timeOffset = 0.0001f;
    }

    private void Update() {
        // Spawn the enemy at spawnPoint
        if (Time.time * 1000 > repeatingTimer + spawnTime * 1000) {
            if (GameObject.FindGameObjectWithTag("Player") != null) {
                Instantiate(enemy, transform).GetComponent<Animator>().enabled = true;
            }
            repeatingTimer = Time.time * 1000;
        }

        if (spawnTime > 1) {
            spawnTime -= timeOffset;
        }
    }
}
