using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawnPoint : MonoBehaviour
{
    [SerializeField] private RollingBarrelConfig _barrelConfig;
    [SerializeField] private GameObject _barrelPrefab;

    private Transform _player;
    private bool canSpawn = true;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (canSpawn && Vector2.Distance(transform.position, _player.position) <= _barrelConfig.detectionRadius)
        {
            SpawnBarrel();
        }
    }

    private void SpawnBarrel()
    {
        GameObject newBarrel = Instantiate(_barrelPrefab, transform.position, Quaternion.identity);
        Vector2 direction = (_player.position - transform.position).normalized;
        newBarrel.GetComponent<Rigidbody2D>().AddForce(direction * _barrelConfig.rollSpeed, ForceMode2D.Impulse);
        canSpawn = false;
        Destroy(newBarrel, _barrelConfig.destroyDelay);
        StartCoroutine(ReSpawnBarrel());
    }

    private IEnumerator ReSpawnBarrel()
    {
        yield return new WaitForSeconds(_barrelConfig.spawnCooldown);
        canSpawn = true;
    }
}
