using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharScript : MonoBehaviour
{
    public GameObject fireProject;
    public Transform gun;
    private bool fire;
    private bool isFiring = false;
    private GameObject currentProjectile;
    public float fireForce;
    private bool flipX = false;
    public float Speed;
    public float JumpForce;
    public bool isJumping;

    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start() {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        fire = Input.GetButtonDown("Fire1");
        Fire();
        Move();
        Jump();
    }

    void Move() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        float inputAxis = Input.GetAxis("Horizontal");

        if (flipX == true && inputAxis > 0) {
            Flip();
            //transform.eulerAngles = new Vector2(0f, 0f);
        }

        if (flipX == false && inputAxis < 0) {
            Flip();
            //transform.eulerAngles = new Vector2(0f, 180f);
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && !isJumping) {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    private IEnumerator WaitForProjectileDestroyed(){
        yield return new WaitUntil(() => currentProjectile == null);
        isFiring = false;
    }

    private void Fire() {
        if (fire == true) {
            if (!isFiring) {
                isFiring = true;

                currentProjectile = Instantiate(fireProject);
                currentProjectile.transform.position = gun.position;
                currentProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(fireForce, 0);
                Destroy(currentProjectile, 0.5f);
                
                StartCoroutine(WaitForProjectileDestroyed());
            }
        }
    }

    private void Flip() {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        fireForce *= -1;
    }

    void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3) {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3) {
            isJumping = true;
        }
    }
}
