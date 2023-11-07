using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _toGameButton;
    [SerializeField] private Button _toMenuButton;
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _shop;
    [SerializeField] private Image _background;
    [SerializeField] private GameObject[] _firstTringle;
    [SerializeField] private GameObject[] _secondTringle;
    [SerializeField] private GameObject[] _thierdTringle;
    [SerializeField] private GameObject[] _fourTringle;
    [SerializeField] private List<List<GameObject>> _triangle;
    [SerializeField] private Button[] _buyButtons;
    
    private void Awake()
    {
        _toGameButton.onClick.AddListener(() => NewGameClick());
        _gameManager.HideGame();
        for (int i = 0; i < _buyButtons.Length; i++)
        {
            Button localButton = _buyButtons[i];
            _buyButtons[i].onClick.AddListener(() => BuySpriteButton(localButton));
        }
        _background.color = Color.blue;
    }
    public void ChangeColor(int val)
    {
        switch(val)
        {
            case 0:
                _background.color = Color.red;
                break;
            case 1:
                _background.color = Color.blue;
                break;
            case 2:
                _background.color = Color.green;
                break;
        }
    }
    private void NewGameClick()
    {
        _gameManager.ShowGame();
    }
    private void BuySpriteButton(Button button)
    {
        int id = int.Parse(button.transform.GetChild(1).name);
        switch(id)
        {
            case 0:
                for (int i = 0; i < _gameManager.triangle.Count; i++)
                    _gameManager.triangle[i].GetComponent<SpriteRenderer>().color = _firstTringle[i+1].GetComponent<Image>().color;
                _gameManager.background.GetComponent<SpriteRenderer>().color = _firstTringle[0].GetComponent<Image>().color;
                break;
            case 1:
                for (int i = 0; i < _gameManager.triangle.Count; i++)
                    _gameManager.triangle[i].GetComponent<SpriteRenderer>().color = _secondTringle[i+1].GetComponent<Image>().color;
                _gameManager.background.GetComponent<SpriteRenderer>().color = _secondTringle[0].GetComponent<Image>().color;
                break;
            case 2:
                for (int i = 0; i < _gameManager.triangle.Count; i++)
                    _gameManager.triangle[i].GetComponent<SpriteRenderer>().color = _thierdTringle[i+1].GetComponent<Image>().color;
                _gameManager.background.GetComponent<SpriteRenderer>().color = _thierdTringle[0].GetComponent<Image>().color;
                break;
            case 3:
                for (int i = 0; i < _gameManager.triangle.Count; i++)
                    _gameManager.triangle[i].GetComponent<SpriteRenderer>().color = _fourTringle[i+1].GetComponent<Image>().color;
                _gameManager.background.GetComponent<SpriteRenderer>().color = _fourTringle[0].GetComponent<Image>().color;
                break;
        }
        

    }
}
