using UnityEngine;
using System.Collections;
using System;

public class PersistentObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject persistentObjectPrefab;

    static bool hasSpawned;

    private void Awake()
    {
        if (hasSpawned) { return; }
        else 
        {
            SpawnPersistentObjects();
            hasSpawned = true;
        }
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentObject = Instantiate(persistentObjectPrefab);
        DontDestroyOnLoad(persistentObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
