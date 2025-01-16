using UnityEngine;

public class ExplosionSource : MonoBehaviour
{
    private const int MinNumberOfNewObjects = 2;
    private const int MaxNumberOfNewObjects = 6;
    

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

    public void SetNewDividor()
    {
        
    }

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
            var explosionProduct = _explosionProductSpawner.CreateExplodableObject(transform.position, transform.localScale / _explosionDividor, _explosionDividor);
            AddExplosionPower(explosionProduct);
        }
    }

    private void AddExplosionPower(Cube cube)
    {
        Vector3 explosion = Random.onUnitSphere * _explosionPower;
        cube.AcceptForce(explosion);
    }
}
