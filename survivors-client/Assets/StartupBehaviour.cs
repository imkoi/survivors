using System.Collections;
using UnityEngine;

public class StartupBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainPrefab;
    [SerializeField]
    private GameObject[] _singletonPrefabs;

    private void Awake()
    {
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        foreach (var prefab in _singletonPrefabs)
        {
            Instantiate(prefab);
        }

        yield return new WaitForEndOfFrame();

        Instantiate(_mainPrefab);
    }
}
