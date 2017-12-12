using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public Spawn spawny;
    public void Awake()
    {
        spawny = new Spawn();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sword")
        {
            spawny.DieBitch();
            Destroy(gameObject);
            Debug.Log("Hit enemy");
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
