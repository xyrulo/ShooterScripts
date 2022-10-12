using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public Main S;

    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemySpawnPadding = 1.5f;
    public float enemySpawnRate;
    public int enemyRange = prefabEnemies.length;

    // Start is called before the first frame update
    void Awake()
    {
        S = this;
        enemySpawnRate = 1f/enemySpawnPerSecond;
        Invoke("SpawnEnemy", enemySpawnRate);
    }

    void SpawnEnemy() {
        // Pick random enemy, increase difficulty of enemies as game continues
        int ndx = Random.Range(0, enemyRange);
        GameObject go = Instantiate(prefabEnemies[ndx]);
        Vector3 pos = Vector3.zero;
        float xMin = Utils.camBounds.min.x + enemySpawnPadding;
        float xMax = Utils.camBounds.max.x + enemySpawnPadding;
        pos.x = Random.Range( xMin, xMax );
        pos.y = Utils.camBounds.max.y + enemySpawnPadding;
        go.transform.position = pos;
        Invoke("SpawnEnemy", enemySpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
