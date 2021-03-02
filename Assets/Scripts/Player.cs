using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }
}
