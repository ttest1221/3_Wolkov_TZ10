using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindAnyObjectByType<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody.gravityScale += _gameManager.speed;
        int colorRnd = Random.Range(0, _gameManager.triangle.Count);
        _spriteRenderer.color = _gameManager.triangle[colorRnd].GetComponent<SpriteRenderer>().color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Tripoly")
        {
            if (_spriteRenderer.color != collision.gameObject.GetComponent<SpriteRenderer>().color)
            {
                _gameManager.GameOver();
            }
            else
            {
                Destroy(this.gameObject);
                _gameManager.score++;
                _gameManager.TextsUpdate();
            }
        }
    }
}
