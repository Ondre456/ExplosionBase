using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public Cube[] SpawnCubes(Vector3 position, Vector3 scale, float dividor)
    {
        const int MinNumberOfNewObjects = 2;
        const int MaxNumberOfNewObjects = 6;

        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);
        Cube[] result = new Cube[countOfNewObjects];

        for (int i = 0; i < countOfNewObjects; i++)
        {
            GameObject explosionProduct = Instantiate(_prefab);
            explosionProduct.AddComponent<MeshRenderer>();
            explosionProduct.AddComponent<Rigidbody>();
            explosionProduct.AddComponent<BoxCollider>();
            explosionProduct.transform.position = position;
            explosionProduct.transform.localScale = scale;

            Cube cube = explosionProduct.AddComponent<Cube>();
            Repainter repainter = explosionProduct.AddComponent<Repainter>();

            repainter?.SetRandomColor();

            result[i] = cube;
        }

        return result;
    }
}
