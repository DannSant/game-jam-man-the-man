using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject goalText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        goalText.SetActive(true);
        Destroy(gameObject);
    }
}
