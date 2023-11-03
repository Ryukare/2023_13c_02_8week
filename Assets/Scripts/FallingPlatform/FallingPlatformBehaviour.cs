using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformBehaviour : MonoBehaviour
{
    [SerializeField] private FallingPlatformConfig _fallingPlatformConfig;
    private bool playerOnPlatform = false;
    private bool canDisappear = true;

    private void Update()
    {
        if (playerOnPlatform && canDisappear)
        {
            _fallingPlatformConfig.disappearTime -= Time.deltaTime;
            if (_fallingPlatformConfig.disappearTime <= 0)
            {
                gameObject.SetActive(false);
                canDisappear = false;
                Invoke("ReappearPlatform", _fallingPlatformConfig.cooldownTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    private void ReappearPlatform()
    {
        gameObject.SetActive(true);
        _fallingPlatformConfig.disappearTime = 3.0f;
        canDisappear = true;
    }
}
