using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject[] GoToArea;

    int AreasWentTo = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (AreasWentTo < GoToArea.Length)
        {
            if (Vector3.Distance(transform.position, GoToArea[AreasWentTo].transform.position) >= .01f)
            {
                float step = speed * Time.deltaTime;
                transform.LookAt(GoToArea[AreasWentTo].transform);
                transform.position = Vector3.MoveTowards(transform.position, GoToArea[AreasWentTo].transform.position, step);
            }
            else
            {
                AreasWentTo += 1;
            }
        }
    }
    void Dead()
    {
        //this'll also be for playing a death animation if we ever get one 
        Destroy(gameObject);
    }
}
