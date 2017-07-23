using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float acceleration;

    //Player movement sounds
    public AudioSource stepSound;
    public AudioSource attackSoundJ;
    public AudioSource attackSoundK;
    public AudioSource attackSoundL;

    private ParticleSystem ps;

    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRB;
    private int floorMask;
    private float camRayLength = 100f;
    private bool attacking;

    private void Awake() {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody>();
        ps = GameObject.FindGameObjectWithTag("ParticleSystem").GetComponent<ParticleSystem>();
    }

    private void Update() {

    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (gameObject.CompareTag("MainmenuOlaf")) {
            h *= -1;
            v *= -1;
        }

        move(h, v);
        if (h != 0 || v != 0) turning();
        animating(h, v);
    }

    private void move(float h, float v) {
        movement.Set(h, 0f, v);
        movement = movement.normalized * acceleration * Time.deltaTime;
        playerRB.AddForce(movement * 250);
        playerRB.velocity = Vector3.ClampMagnitude(playerRB.velocity, speed);
    }

    private void turning() {
        Quaternion newRot = Quaternion.LookRotation(movement);
        playerRB.rotation = Quaternion.Lerp(transform.rotation, newRot, Time.deltaTime * speed);
    }

    private void animating(float h, float v) {
        // Did we press horizontal/vertical axis
        bool walking = h != 0f || v != 0f;
        anim.SetBool("isRunning", walking);
        if (!walking) ps.Stop();
        else ps.Play();

    }
}
