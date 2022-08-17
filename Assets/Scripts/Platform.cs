using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("outlimit"))
        {
            Destroy(gameObject);
        }
    }
}
