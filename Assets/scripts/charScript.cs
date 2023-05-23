using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charScript : MonoBehaviour
{
    public GameObject fireProject;
    public Transform gun;
    private bool fire;
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

    private void Fire() {
        if (fire == true) {
            GameObject temp = Instantiate(fireProject);
            temp.transform.position = gun.position;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(fireForce, 0);
            Destroy(temp.gameObject, 3f);
        }
    }

    private void Flip() {
        flipX = !flipX;
        float x = transform.localScale.x;
        x *= -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        fireForce *= -1;
    }
}
