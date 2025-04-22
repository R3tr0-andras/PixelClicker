using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollViewPopulator : MonoBehaviour
{
    [Header("Trucs")]
    [SerializeField] public GameObject[] prefabs; // Liste de prefabs à instancier
    void Start()
    {
        SpawnPrefabs();
    }

    void SpawnPrefabs()
    {
        foreach (GameObject prefab in prefabs)
        {
            GameObject instance = Instantiate(prefab, transform); // ici on utilise 'transform'
            instance.transform.localScale = Vector3.one;
        }
    }
}
