using UnityEngine;
using TMPro;
using System;

public class Money : MonoBehaviour
{
    private TMP_Text _moneyText;
    private int _moneyCount = 0;
    private GameObject canvas;
    [SerializeField]private GameObject _money;

    public static Action<int> addmoney;
    public static Action<Transform> createMoney;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        _moneyText = GetComponent<TMP_Text>();
        addmoney += AddMoney;
        createMoney += CreateMoney;
        addmoney.Invoke(0); 
    }
    private void CreateMoney(Transform pos)
    {
      var money = Instantiate(_money, pos.position, Quaternion.identity);
        money.transform.parent = canvas.transform;
    }
    private void AddMoney(int money)
    {
        _moneyCount += money;
        _moneyText.text = $"Money: {_moneyCount}";
    }
    private void OnDestroy()
    {
        createMoney -= CreateMoney;
        addmoney -= AddMoney;
    }
}