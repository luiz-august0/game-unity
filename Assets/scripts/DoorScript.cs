using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    Cave Cave;
    void OnCollisionEnter2D(Collision2D collisor) {
        if (collisor.gameObject.tag == "char") {
            if (Cave.totalDeadEnemies == Cave.totalEnemiesOnScene) {
                Cave.totalDeadEnemies = 0;

                if (SceneManager.GetActiveScene().name == "cave 1") {
                    SceneManager.LoadScene("cave 2");
                    Cave.totalEnemiesOnScene = 0;
                }

            }
        }
    }
}
