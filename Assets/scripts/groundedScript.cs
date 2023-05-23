using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundedScript : MonoBehaviour
{

    charScript Player;

    // Start is called before the first frame update
    void Start() {
        Player = gameObject.transform.parent.gameObject.GetComponent<charScript>();
    }

    void OnCollisionEnter2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3) {
            Player.isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor) {
        if(collisor.gameObject.layer == 3) {
            Player.isJumping = true;
        }
    }
}
