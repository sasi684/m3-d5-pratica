using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    public float Speed { get => _speed; set => _speed = value; }

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (!_rb) Debug.LogError($"Nessuna componente RigidBody2D trovata per l'oggetto {gameObject.name}!!");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public Rigidbody2D GetRigidbody2D() => _rb;
    public Rigidbody2D SetRigidbody2D(Rigidbody2D rb) => _rb = rb;

}
