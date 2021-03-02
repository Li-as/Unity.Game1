using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideScreenObjectsDisabler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle obstacle) ||
            collision.TryGetComponent(out Coin coin))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
