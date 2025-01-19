using UnityEngine;

[RequireComponent(typeof(Cube))]
public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private float _explosionPower;
    [SerializeField] private Spawner _explosionProductSpawner;

    private float _chanceToExplode = 1f;
    private float _explosionDividor = 2;
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void Explode()
    {
        float randomValue = Random.value;
        var explosionProducts = new GameObject[0];

        if (randomValue <= _chanceToExplode)
        {
            explosionProducts = _explosionProductSpawner.Spawn(transform.position, transform.localScale / _explosionDividor);

            foreach (var explosionProduct in explosionProducts)
            {
                ExplosionSource explosionSource = explosionProduct.AddComponent<ExplosionSource>();
                explosionSource._explosionProductSpawner = _explosionProductSpawner;
                explosionSource._explosionPower = _explosionPower / _explosionDividor;
                explosionSource._chanceToExplode = _chanceToExplode / _explosionDividor;
                Repainter repainter = explosionProduct.GetComponent<Repainter>();
                repainter.SetRandomColor();
                explosionProduct.GetComponent<Cube>().AcceptForce(GetExplosionPower());
            }
        }

        Destroy(gameObject);
    }

    private Vector3 GetExplosionPower()
    {
        return Random.onUnitSphere * _explosionPower;
    }

    private void OnMouseDown()
    {
        Explode();
    }
}
