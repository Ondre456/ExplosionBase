using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public GameObject[] Spawn(Vector3 position, Vector3 scale, float dividor)
    {
        const int MinNumberOfNewObjects = 2;
        const int MaxNumberOfNewObjects = 6;

        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);
        GameObject[] result = new GameObject[countOfNewObjects];

        for (int i = 0; i < countOfNewObjects; i++)
        {
            GameObject spawnableObject = Instantiate(_prefab);
            spawnableObject.AddComponent<MeshRenderer>();
            spawnableObject.AddComponent<Rigidbody>();
            spawnableObject.AddComponent<BoxCollider>();
            spawnableObject.transform.position = position;
            spawnableObject.transform.localScale = scale;

            Repainter repainter = spawnableObject.AddComponent<Repainter>();

            repainter?.SetRandomColor();

            result[i] = spawnableObject;
        }

        return result;
    }
}
