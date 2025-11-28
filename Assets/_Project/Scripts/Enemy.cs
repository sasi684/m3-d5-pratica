using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;

    private PlayerController _player;

    private void Awake()
    {
        _player = GameObject.FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 10f) * _speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
            Destroy(collision.gameObject);
    }
}
