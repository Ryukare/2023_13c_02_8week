using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBarrel : MonoBehaviour
{
    [SerializeField] private RollingBarrelConfig _rollingBarrelConfig;
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _player.position) <= _rollingBarrelConfig.detectionRadius)
        {
            float rotation = _rollingBarrelConfig.rollSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotation);
        }
    }
}
