using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody aRigidBody;
    Transform target;
    Transform myTransform;
    public float movespeed = 3.0f;
    private float ogMoveSpeed;
    public float rotationspeed = 3.0f;
    public float stop = 1.5f;
    

    void Awake()
    {
        myTransform = transform;
    }
    // Use this for initialization
    void Start()
    {
        setMoveSpeed();
        enemy = this.gameObject;
        aRigidBody = enemy.GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player").transform;

    }

    public void setMoveSpeed()
    {
        movespeed = UnityEngine.Random.Range(3f, 6f);
        ogMoveSpeed = movespeed;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            movespeed = -8;
        }

        else
        {
            movespeed = ogMoveSpeed;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        movespeed = ogMoveSpeed;
    }

    void Update()
    {
        float distance = Vector3.Distance(myTransform.position, target.position);

        if (distance > stop)
        {
            aRigidBody.constraints = RigidbodyConstraints.None;
            myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), rotationspeed * Time.deltaTime);
            myTransform.rotation = Quaternion.Euler(new Vector3(0f, myTransform.eulerAngles.y, 0f));
            myTransform.position += myTransform.forward * movespeed * Time.deltaTime;
        }

        else
        {
            aRigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}