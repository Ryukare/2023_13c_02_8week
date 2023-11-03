using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPlatformBehaviour : MonoBehaviour
{
    private Collider2D platformCollider;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("DropAction"))
        {
            platformCollider.enabled = false;
            Invoke("EnableCollider", 0.5f);
        }
    }
    private void EnableCollider()
    {
        platformCollider.enabled = true;
    }
}