using System.Collections;
using UnityEngine;

public class StartupBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPrefab;
    [SerializeField]
    private GameObject[] _corePrefabs;

    private void Awake()
    {
        StartCoroutine(ScheduleStartup());
    }

    private IEnumerator ScheduleStartup()
    {
        foreach (var prefab in _corePrefabs)
        {
            Instantiate(prefab);
        }

        yield return new WaitForEndOfFrame();

        Instantiate(_mainPrefab);
    }
}
