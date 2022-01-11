using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LookAtPlayer : MonoBehaviour
{
    GameObject msgbox;
    GameObject nextbox;
    private Button bt_loc_911;
    private Button bt_exit;

    private void Start()
    {
        msgbox = GameObject.Find("Talkbox");
        nextbox = GameObject.Find("Nextbox");
        msgbox.SetActive(false);
        nextbox.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(other.transform);
            msgbox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            msgbox.SetActive(false);
            nextbox.SetActive(false);
        }
    }

}