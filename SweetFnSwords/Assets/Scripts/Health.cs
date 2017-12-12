using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    public const int max = 100;
    public int currentHealth = max;
    [SerializeField] private SteamVR_Controller.Device device;

    void Start()
    {
        currentHealth = max;
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10);
            //device.TriggerHapticPulse(3999);
        }
    }

    void TakeDamage(int hit)
    {
        currentHealth -= hit;
        Debug.Log("YOU GOT HIT, BITCH");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Death");
            Debug.Log("You died, dummy");
        }
    }
}
