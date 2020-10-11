using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            //respawn function will be used for later development
            /*rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            player.transform.position = respawnPoint.transform.position;*/
            Scene Scene_1 = SceneManager.GetActiveScene();
            SceneManager.LoadScene(Scene_1.name);
        }
    }
}
