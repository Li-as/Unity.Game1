using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Die()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
}
