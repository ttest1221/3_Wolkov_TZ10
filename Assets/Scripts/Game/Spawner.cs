using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private GameObject _platform;
    [SerializeField] private GameManager _gameManager;
    private float _spawnTime;


    void Update()
    {
        if (Time.time > _spawnTime && _gameManager.gameStarted == true)
        {
            Spawn();
            _spawnTime = Time.time + _timeBetweenSpawn;
        }

    }
    private void Spawn()
    {
        Instantiate(_platform, transform.position + new Vector3(0, 6, 0), transform.localRotation);
        _gameManager.speed += 0.01f;
    }
}
