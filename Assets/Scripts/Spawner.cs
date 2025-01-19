using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _prefab;

    public GameObject[] Spawn(Cube prefab, Vector3 position, Vector3 scale)
    {
        const int MinNumberOfNewObjects = 2;
        const int MaxNumberOfNewObjects = 6;

        int countOfNewObjects = Random.Range(MinNumberOfNewObjects, MaxNumberOfNewObjects);
        GameObject[] result = new GameObject[countOfNewObjects];

        for (int i = 0; i < countOfNewObjects; i++)
        {
            GameObject spawnableObject = Instantiate(_prefab.gameObject);
            spawnableObject.transform.position = position;
            spawnableObject.transform.localScale = scale;
            spawnableObject.GetComponent<MeshRenderer>().enabled = true;
            spawnableObject.GetComponent<BoxCollider>().enabled = true;
            result[i] = spawnableObject;
        }

        return result;
    }
}
