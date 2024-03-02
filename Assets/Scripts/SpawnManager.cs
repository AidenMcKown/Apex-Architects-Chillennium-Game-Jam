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
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    public Transform SpawnPlayer(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        playerRb.Move(GetRandomSpawnPoint().position, Quaternion.identity);
        return player.transform;
    }

    private Transform OnPlayerResetEvent(GameObject player)
    {
        return SpawnPlayer(player);
    }
}
