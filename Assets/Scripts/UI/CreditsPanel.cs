using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CreditsPanel : MonoBehaviour
{
    [SerializeField] private float _openCloseDuration;

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Open();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        StartCoroutine(ChangeVisibility(1));
    }

    public void Close()
    {
        StartCoroutine(ChangeVisibility(0));
    }

    private IEnumerator ChangeVisibility(float goalAlpha)
    {
        float startAlpha = _canvasGroup.alpha;
        float passedTime = 0;
        while (passedTime < _openCloseDuration)
        {
            _canvasGroup.alpha = Mathf.Lerp(startAlpha, goalAlpha, passedTime / _openCloseDuration);
            passedTime += Time.deltaTime;
            yield return null;
        }
        _canvasGroup.alpha = goalAlpha;

        if (_canvasGroup.alpha == 0)
        {
            gameObject.SetActive(false);
        }

        yield break;
    }
}
