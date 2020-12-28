using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWayOrbScript : MonoBehaviour
{

    public GameObject[] GoToArea;
    int AreasWentTo = 0;
    public float speed;
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
        else
        {
            DestroyOrb();
        }
    }
    public void DestroyOrb()
    {
        //this is here so if the orbs get to the end of the path
        //and for when we start the waves it'll destroy the orbs
        Destroy(this.gameObject);
    }
}
