using System;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{

    Rigidbody rb;

    [SerializeField] float jumpForce=200;
    [SerializeField] float horizontalForce= 60;
    [SerializeField] float gravityCap = 10;
    [SerializeField] GameObject deathPanel;

    RigidbodyConstraints defaultConstraints;
    GameObject blade;
    bool inGame;
    bool grounded;
    bool jumpRoll;
    float jumpCount;

    private void Awake() {
        inGame = true;
        grounded = true;
        jumpRoll = false;
        rb = GetComponent<Rigidbody>();
        defaultConstraints = rb.constraints;
        blade = gameObject.transform.Find("Blade").gameObject;
    }

    private void Update() {
        if (inGame) 
            HandleInput(); 
    }
    private void FixedUpdate() {
        if (inGame) 
        UpdateCustomPhysics();
    }

    private void UpdateCustomPhysics() {
        CapGravity();
        Stick();
        Rotate();
        SimulateCeiling();
    }

    private void SimulateCeiling() {
        if (transform.position.y >= 9) 
            rb.AddForce(new Vector3(-horizontalForce,-jumpForce,0));
    }

    private void Stick() {
        if (grounded && !jumpRoll) {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        } else {
            rb.constraints = defaultConstraints;
        }
    }

    private void CapGravity() {
        rb.velocity = rb.velocity.y <= -gravityCap ? new Vector3(rb.velocity.x, -gravityCap, rb.velocity.z) : rb.velocity;
    }

    void HandleInput() {
        bool justTouched = Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began;

        if (Input.GetButtonDown("Fire1")||justTouched) 
            Jump();
    }

    private void Jump() {
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(horizontalForce, jumpForce, 0));
        jumpRoll = true;
        jumpCount = 180;
        GetComponent<AudioSource>().Play();
        blade.GetComponent<CapsuleCollider>().enabled = false;
    }

    void Rotate() {
        float currentRotation = transform.rotation.eulerAngles.z;
        float newRotation = 0;
        bool slowRotation = currentRotation >= 120 && currentRotation <= 300;

        if (jumpCount<=0) {
            jumpRoll = currentRotation >= 300 ? false : jumpRoll;
            blade.GetComponent<CapsuleCollider>().enabled = true;
        }

        if (jumpRoll) { 
            newRotation = -20;
            jumpCount -= 20;
        } else if (!grounded) { 
            newRotation = slowRotation ? -Math.Abs((270 - currentRotation) / 16) - .5f : -20;
        }

        transform.Rotate(0, 0, newRotation);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Lava")&& inGame) {
            Die();
        }
    }


    public void justCut() {
        float currentRotation = transform.rotation.eulerAngles.z;
        if (currentRotation < 275)
            transform.Rotate(0, 0, 5);
    }

    private void OnTriggerEnter(Collider other) {
        bool isTerrain = other.gameObject.layer == 0 || other.gameObject.layer == 4;
        bool isMultiplier = other.gameObject.GetComponent<ScoreMultiplier>()!=null;

        if (isTerrain)
            grounded = true;

        if (isMultiplier && inGame)
            Win(other.gameObject.GetComponent<ScoreMultiplier>().GetMultiplier());

    }



    private void Die() {
        inGame = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        GameManager.Instance.PlayerLost();
    }

    private void Win(int multiplier) {
        inGame = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        GameManager.Instance.PlayerWon(multiplier);
    }

    private void OnTriggerExit(Collider other) {
        bool isTerrain = other.gameObject.layer == 0 || other.gameObject.layer == 4;
        if (isTerrain) 
            grounded = false;
    }
}
