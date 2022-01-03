using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Vector3 target = new Vector3(10, 0, 70);

    // Update is called once per frame
    void Update()
    {
        //1.MoveTowards
        /*transform.position =
            Vector3.MoveTowards(transform.position, target, 1f);*/

        //2.SmoothDamp
        Vector3 velo = Vector3.zero;

        transform.position =
            Vector3.SmoothDamp(transform.position, target, ref velo, 0.5f);

    }
}
