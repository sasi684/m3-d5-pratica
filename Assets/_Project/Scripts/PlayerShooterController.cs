using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerShooterController : MonoBehaviour
{
    [SerializeField] private float _fireRange = 10f;
    [SerializeField] private float _fireRate = 2f;

    private Bullet _bullet;
    private PlayerController _player;
    private float lastShot = 0;

    private void Awake()
    {
        _player = GetComponent<PlayerController>();
    }

    void Update()
    {
        Shoot();
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        Vector2 shortestDistance = Vector2.zero;
        if (enemies.Length > 0)
        {
            shortestDistance = enemies[0].transform.position - _player.transform.position;
            nearestEnemy = enemies[0];
        }
        
        foreach (GameObject enemy in enemies)
        {
            Vector2 distance = enemy.transform.position - _player.transform.position;
            if (distance.magnitude < shortestDistance.magnitude)
            {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;

    }

    void Shoot()
    {
        if (Time.time - lastShot > _fireRate)
        {
            GameObject nearestEnemy = FindNearestEnemy();
            if (nearestEnemy)
            {
                GameObject.Instantiate(_bullet);
                _bullet.transform.position = _player.transform.position;
                _bullet.GetRigidbody2D().MovePosition(_bullet.GetRigidbody2D().position + (Vector2)nearestEnemy.transform.position * _bullet.Speed);
            }
            lastShot = Time.time;
        }
    }
}
