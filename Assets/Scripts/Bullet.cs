using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    public float timeout = 6f;
    public Transform target;
    void Start()
    {
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        timeout -= Time.deltaTime;
        if (timeout<= 0f)
        {
            Destroy(this.gameObject);
        }
    }


    public void move()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TARGET")
        {
            Destroy(this.gameObject);
        }
    }


}
