using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDropSystem : MonoBehaviour
{
    public GameObject chestPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewChest();
    }

    // Update is called once per frame
    public void SpawnNewChest()
    {
        float spawnPos = Random.Range(-8f, 19f);
        Instantiate(chestPrefab, new Vector3(spawnPos, 10, 0), Quaternion.identity);
    }

    public void SpawnNewChest(float time)
    {
        Invoke(nameof(SpawnNewChest),time);
    }
}
