using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DeathZoneTrigger");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().StartCoroutine("MoveOnFall");
            GameManager._instance.StartCoroutine("ResetAfterFalling");
        }
    }
}
