using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] public List<Pickup> PickupsToSpawn;
    [SerializeField] public List<Wall> Walls;

    public float SpawnTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    private Vector3 GetRandomLocationWithinWalls()
    {
        return new Vector3((int)Random.Range(Walls[2].transform.position.x, Walls[3].transform.position.x), (int)Random.Range(Walls[0].transform.position.y, Walls[1].transform.position.y));
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(PickupsToSpawn[Random.Range(0, PickupsToSpawn.Count)], GetRandomLocationWithinWalls(), Quaternion.identity);
            yield return new WaitForSecondsRealtime(SpawnTimer);
        }
    }
}
