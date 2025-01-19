using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public Cube[] Spawn(Vector3 position, Vector3 scale)
    {
        const int MinNumberOfNewObjects = 2;
        const int MaxNumberOfNewObjects = 6;

        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);
        Cube[] result = new Cube[countOfNewObjects];

        for (int i = 0; i < countOfNewObjects; i++)
        {
            Cube spawnableObject = Instantiate(_prefab);
            spawnableObject.transform.position = position;
            spawnableObject.transform.localScale = scale;
            spawnableObject.GetComponent<MeshRenderer>().enabled = true;
            spawnableObject.GetComponent<BoxCollider>().enabled = true;
            result[i] = spawnableObject;
        }

        return result;
    }
}
