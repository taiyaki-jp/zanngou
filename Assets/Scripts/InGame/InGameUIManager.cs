using TMPro;
using UnityEngine;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private MainGameVariables _gameVariables;
    // Start is called before the first frame update
    void Start()
    {
        _gameVariables = GameObject.Find("SingletonCanvas").GetComponent<MainGameVariables>();
        ChangeLife();
    }

    public void ChangeLife()
    {
        if (_gameVariables.NowDiffculty ==4)_text.text = "一瞬の判断が生死を分ける";
        else _text.text = $"残機:{Mathf.Max(_gameVariables.HP-1,0)}";
    }
}
