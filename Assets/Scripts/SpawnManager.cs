using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] List<Transform> spawnPoints;

    void Awake()
    {
        HealthSystem.PlayerResetEvent += OnPlayerResetEvent;
    }

    void OnDisable()
    {
        HealthSystem.PlayerResetEvent -= OnPlayerResetEvent;
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
    }

    public Transform SpawnPlayer(GameObject player)
    {
        player.GetComponent<Rigidbody>().Move(GetRandomSpawnPoint().position, Quaternion.identity);
        return player.transform;
    }

    private Transform OnPlayerResetEvent(GameObject player)
    {
        return SpawnPlayer(player);
    }
}
