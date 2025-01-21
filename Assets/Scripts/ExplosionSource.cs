using UnityEngine;

[RequireComponent(typeof(MassiveObject))]
public class ExplosionSource : MonoBehaviour
{
    [SerializeField] private Spawner _explosionProductSpawner;
    [SerializeField] private float _explosionPowerModifier = 2;

    private float _chanceToExplode = 1f;
    private float _explosionDividor = 2;

    private void Explode()
    {
        float randomValue = Random.value;
        var explosionProducts = new Cube[0];

        if (randomValue <= _chanceToExplode)
        {
            explosionProducts = _explosionProductSpawner.Spawn(transform.position, transform.localScale / _explosionDividor);

            foreach (var explosionProduct in explosionProducts)
            {
                ExplosionSource explosionSource = explosionProduct.gameObject.AddComponent<ExplosionSource>();
                explosionSource._explosionProductSpawner = _explosionProductSpawner;
                explosionSource._chanceToExplode = _chanceToExplode / _explosionDividor;
                Repainter repainter = explosionProduct.GetComponent<Repainter>();
                repainter.ChangeColorToRandom();
            }
        }

        var explosion = gameObject.AddComponent<Explosion>();
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        explosion.AcceptExplosionCharacteristics(rigidbody.mass, _explosionPowerModifier);
    }

    private void OnMouseDown()
    {
        Explode();
    }
}
