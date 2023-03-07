using UnityEngine;
using DG.Tweening;

public class AnimMoney : MonoBehaviour
{
   private RectTransform _moneyText;
    private float _delay;
    private float _speed;
    private int addMoney;
    void Start()
    {
        _moneyText = GameObject.FindGameObjectWithTag("Bank").GetComponent<RectTransform>();
        _delay = 0.05f;
        _speed = 0.5f;
        addMoney = 15;
        DOTween.Sequence()
            .Append(transform.DOMove(_moneyText.position, _speed))
            .AppendInterval(_delay)
            .AppendCallback(AddMoney)
            .Append(_moneyText.DOShakePosition(5));
    }
    private void AddMoney()
    {
        Money.addmoney.Invoke(addMoney);
        Destroy(gameObject);
    }
}
