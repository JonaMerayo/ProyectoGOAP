using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControllerMonsters : MonoBehaviour
{
    public GameObject[] spawnList;
    public int initialSpawns=2;
    public Vector2 timeRange=new Vector2 (2, 10);
    private GameObject spawn;
    public string stateToIncrease;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialSpawns; i++)
        {
            instantiateSpawn();
        }

        Invoke("SpawnAgent", 5);
    }

    void SpawnAgent()
    {
        instantiateSpawn();
        Invoke("SpawnAgent", Random.Range(timeRange.x, timeRange.y));
    }

    private void instantiateSpawn()
    {
        spawn = Instantiate(spawnList[Random.Range(0, spawnList.Length - 1)], this.transform.position, Quaternion.identity);
        GWorld.Instance.GetWorld().ModifyState(stateToIncrease, 1);
        GWorld.Instance.AddMonster(spawn);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
