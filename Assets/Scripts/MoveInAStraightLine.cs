using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInAStraightLine : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

   
    }
}
