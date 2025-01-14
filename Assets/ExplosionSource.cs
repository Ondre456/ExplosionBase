using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    private const int MinNumberOfNewObjects = 2;
    private const int MaxNumberOfNewObjects = 6;
    private const float ExplosionDividor = 2;

    [SerializeField] private float _explosionPower;

    private float _chanceToExplode = 1f;

    private void OnMouseDown()
    {
        float randomValue = Random.value;
        
        if (randomValue <= _chanceToExplode)
        {
            Explode();
        }

        Destroy(gameObject);
    }

    private void Explode()
    {
        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);

        for (int i = 0; i < countOfNewObjects; i++)
        {
            CreateExplosionProduct();
        }
    }

    private void CreateExplosionProduct()
    {
        GameObject explosionProduct = new GameObject("ExplosionProduct");
        Cube cube = explosionProduct.AddComponent<Cube>();
        cube.transform.localScale /= ExplosionDividor;
        ExplosionSource newExplosionSource = explosionProduct.GetComponent<ExplosionSource>();

        if (newExplosionSource != null)
            newExplosionSource._chanceToExplode = _chanceToExplode / ExplosionDividor;

        cube?.SetRandomColor();
        cube?.AddRandomForce(_explosionPower);
    }
}
