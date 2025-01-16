using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    public Cube CreateExplodableObject(GameObject sendor, float dividor)
    {
        GameObject explosionProduct = Instantiate(_prefab);
        explosionProduct.AddComponent<MeshRenderer>();
        explosionProduct.AddComponent<Rigidbody>();
        explosionProduct.AddComponent<BoxCollider>();
        explosionProduct.transform.position = sendor.transform.position;
        explosionProduct.transform.localScale = sendor.transform.localScale / dividor;

        ExplosionSource explosionSource = explosionProduct.AddComponent<ExplosionSource>();
        explosionSource.AcceptSpawner(this);
        explosionSource.DivideChanceToExpload(dividor);
        Cube cube = explosionProduct.AddComponent<Cube>();
        Repainter repainter = explosionProduct.AddComponent<Repainter>();

        repainter?.SetRandomColor();
        explosionSource.DivideChanceToExpload(dividor);
        
        return cube;
    }
}
