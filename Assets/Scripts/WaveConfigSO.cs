using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] Transform PathPrefab;
    [SerializeField] float enemyMoveSpeed = 5f;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float enemySpawnVariance = 0f;
    [SerializeField] float minimumSpawnTime = 0.2f;

    public int GetEnemyCount()
    {
        return enemyPrefabs.Length;
    }
    
    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public Transform GetStartingWayPoint()
    {
        return PathPrefab.GetChild(0);
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[PathPrefab.childCount];

        for (int i = 0; i < PathPrefab.childCount; i++)
        {
            waypoints[i] = PathPrefab.GetChild(i);
        }
        return waypoints;
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - enemySpawnVariance,
            timeBetweenEnemySpawns + enemySpawnVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }


}
