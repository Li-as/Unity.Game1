using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject template)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(template, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault((t) => t.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectsOutsideScreen()
    {
        foreach (GameObject item in _pool)
        {
            if (item.activeSelf == true)
            {
                Vector3 point = Camera.main.WorldToViewportPoint(item.transform.position);
                if (point.x < 0)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (GameObject item in _pool)
        {
            item.SetActive(false);
        }
    }
}
