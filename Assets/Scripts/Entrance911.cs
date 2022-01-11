using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance911 : MonoBehaviour
{
    GameObject[] arrows;
    GameObject talkbox;
    GameObject nextbox;
    public Transform target;
    Vector3 pos;

    private void Start()
    {
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        talkbox = GameObject.Find("Talkbox");
        nextbox = GameObject.Find("Nextbox");

        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
    }

    public void onClickBtn()
    {
        talkbox = GameObject.Find("Talkbox");
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(true);
        }
        talkbox.SetActive(false);
        nextbox.SetActive(true);
    }


    public void hideArrow()
    {
        arrows = GameObject.FindGameObjectsWithTag("Arrow");

        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
    }

    private void Update()
    {
        pos = target.transform.position;

        if (pos.z <= -405 && -445 <= pos.z && pos.x <= -116 && -156 <= pos.x)
        {
            hideArrow();
        }
    }
}
