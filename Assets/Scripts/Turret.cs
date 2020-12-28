using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour


{
    public Queue<GameObject> targets;
    public float rof = 5;
    public GameObject bullet;
    public float projectileSpeed = 4f;
    private float initRof;
    
    // Start is called before the first frame update
    void Start()
    {
        initRof = rof;
        targets = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rof -= Time.deltaTime;
        if (rof <= 0f  )
        {
            rof = initRof;
            if (targets.Count > 0)
            {
                shoot(targets.Peek());

            }
            
        }
    }



    public void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.tag == "TARGET")
        {
            this.targets.Enqueue(other.gameObject);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TARGET")
        {
            //removes exiting target from the queue
            targets = new Queue<GameObject>(targets.Where(obj => obj != other.gameObject).ToArray());
        }
    }


    public void shoot(GameObject target)
    {
        var b = Instantiate(bullet, this.transform);
        b.GetComponent<Bullet>().target = target.transform;
        b.GetComponent<Bullet>().speed =  projectileSpeed;
        

    }
}
