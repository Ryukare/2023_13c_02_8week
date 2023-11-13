using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private GameObject popUpPrefab;
    private GameObject currentPopUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 popUpPosition = transform.position + new Vector3(0.5f, 0.7f,0);
            currentPopUp = Instantiate(popUpPrefab, popUpPosition, Quaternion.identity);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && currentPopUp != null)
        {
            Destroy(currentPopUp);
        }
    }
}
