using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaviTest : MonoBehaviour
{
    GameObject[] arrows;
    public Transform target;
    private bool isbtnClicked = false;
    Vector3 pos;

    GameObject test;

    private void OnMouseDown()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(true);
        }
        isbtnClicked = true;
    }

    private void Start()
    {
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }

        test = GameObject.Find("Panel");
        test.SetActive(false);
    }

    private void hideArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
    }

    private void Update()
    {
        pos = target.transform.position;

        if (pos.z <= 365 && 335 <= pos.z && pos.x <= 15 && -15 <= pos.x)
        {
            hideArrow();
        }
    }
}
