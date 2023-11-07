using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _gameOverScore;
    [SerializeField] private Text _gameOverBestScore;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private Button _switchButton;
    [SerializeField] private Button _restartButton;


    public List<GameObject> triangle;
    public GameObject background;
    public bool gameStarted = false;
    public float speed;
    public int score;
    public int bestScore;

    private int _timespeed = 0;
    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _restartButton.onClick.AddListener(() => RestartClick());
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            LeftRotate();
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            RightRotate();
    }
    public void ShowGame()
    {
        _gameScreen.SetActive(true);
        _game.SetActive(true);
        _menu.SetActive(true);
        _menuScreen.SetActive(false);
        gameStarted = true;
        TextsUpdate();
    }
    public void HideGame()
    {

        _gameScreen.SetActive(false);
        _menuScreen.SetActive(true);
        _gameOverPanel.SetActive(false);
        gameStarted = false;
    }
    
    private void RestartClick()
    {
        _menu.SetActive(true);
        _game.SetActive(true);
        _gameOverPanel.SetActive(false);
        gameStarted = true;
        TextsUpdate();
    }
    public void PauseChange()
    {
        Time.timeScale = _timespeed;
        if (_timespeed == 0)
            _timespeed++;
        else
            _timespeed = 0;
    }
    public void TextsUpdate()
    {

        _scoreText.text = "Score: \n" + score.ToString();
        _bestScoreText.text = "Best Score: \n" + bestScore.ToString();
        _gameOverScore.text = score.ToString();
        _gameOverBestScore.text = bestScore.ToString();

    }
    public void GameOver()
    {
        Platform[] platforms = FindObjectsByType<Platform>(FindObjectsSortMode.None);
        for (int i = 0; i < platforms.Length; i++)
            Destroy(platforms[i].gameObject);
        _menu.SetActive(false);
        _game.SetActive(false);
        gameStarted = false;
        if (bestScore < score)
            bestScore = score;
        TextsUpdate();
        _gameOverPanel.SetActive(true);
        score = 0;
    }
    public void LeftRotate()
    {
        if (_timespeed != 1)
        {
            Color tempUp = triangle[0].GetComponent<SpriteRenderer>().color;
            Color tempLeft = triangle[1].GetComponent<SpriteRenderer>().color;
            Color tempRight = triangle[2].GetComponent<SpriteRenderer>().color;

            triangle[0].GetComponent<SpriteRenderer>().color = tempRight;
            triangle[1].GetComponent<SpriteRenderer>().color = tempUp;
            triangle[2].GetComponent<SpriteRenderer>().color = tempLeft;
        }
    }
    public void RightRotate()
    {
        if (_timespeed != 1)
        {
            Color tempUp = triangle[0].GetComponent<SpriteRenderer>().color;
            Color tempLeft = triangle[1].GetComponent<SpriteRenderer>().color;
            Color tempRight = triangle[2].GetComponent<SpriteRenderer>().color;

            triangle[0].GetComponent<SpriteRenderer>().color = tempLeft;
            triangle[1].GetComponent<SpriteRenderer>().color = tempRight;
            triangle[2].GetComponent<SpriteRenderer>().color = tempUp;
        }
    }
}
