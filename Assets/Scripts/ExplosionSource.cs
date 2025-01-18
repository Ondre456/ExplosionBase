using Unity.VisualScripting;
using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private float _explosionPower;
    [SerializeField] private Spawner _explosionProductSpawner;

    private float _chanceToExplode = 1f;
    private float _explosionDividor = 2;

    public void DivideChanceToExpload(float dividor)
    {
        _chanceToExplode /= dividor;
    }
    
    public void AcceptSpawner(Spawner spawner)
    {
        _explosionProductSpawner = spawner;
    }

    public void Explode()
    {
        float randomValue = Random.value;

        if (randomValue <= _chanceToExplode)
        {
            var explosionProducts = _explosionProductSpawner.SpawnCubes(transform.position, transform.localScale / _explosionDividor, _explosionDividor);

            foreach (var explosionProduct in explosionProducts)
            {
                ExplosionSource explosionSource = explosionProduct.GetComponent<ExplosionSource>();
                explosionSource.AcceptSpawner(_explosionProductSpawner);
                explosionSource.DivideChanceToExpload(_explosionDividor);
                AddExplosionPower(explosionProduct);
            }
        }

        Destroy(gameObject);
    }

    private void AddExplosionPower(Cube cube)
    {
        Vector3 explosion = Random.onUnitSphere * _explosionPower;
        cube.AcceptForce(explosion);
    }
}
