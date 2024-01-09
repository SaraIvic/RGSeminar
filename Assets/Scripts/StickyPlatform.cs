using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // We have two box colliders on our platform, smaller one of them has onTrigger checked
    // Code bellow applies only to that smaller collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Duck")
        {
            // We set duck to folllow platform coordinates when on it
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Duck")
        {
            // Duck stops to folllow platform coordinates when not on it
            collision.gameObject.transform.SetParent(null);
        }
    }
}
