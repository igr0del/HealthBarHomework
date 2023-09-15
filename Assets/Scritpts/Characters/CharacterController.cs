using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(SpriteRenderer))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Object _buttonDamage;
    [SerializeField] private Object _buttonHealth;
    [SerializeField] private float _maxHealth;

    private float _correctHealth;
    private float _damage;
    private float _health;
    private bool _isDeath = false;

    public float MaxHealth => _maxHealth;
    public float CorrectHealth => _correctHealth;
    public bool IsDeath => _isDeath;

    private void Start()
    {
        _buttonDamage = GameObject.FindObjectOfType<ButtonDamage>();
        _damage = _buttonDamage.GetComponent<ButtonDamage>().DamageValue;

        _buttonHealth = GameObject.FindObjectOfType<ButtonHealth>();
        _health = _buttonHealth.GetComponent<ButtonHealth>().HealthValue;

        _correctHealth = _maxHealth;

        SetValueDamageButton(_damage);
        SetValueHealthButton(_health);
    }

    private void SetValueDamageButton(float damage)
    {
        _damage = damage;
    }

    private void SetValueHealthButton(float damage)
    {
        _damage = damage;
    }

    public void TakeDamage()
    {
        _spriteRenderer.DOColor(Color.white, 0).SetLoops(2, LoopType.Yoyo);

        if (_correctHealth > 0)
            _correctHealth -= _damage;
        else
            _correctHealth = 0;

        _spriteRenderer.DOColor(Color.red, 0.1f).SetLoops(2, LoopType.Yoyo);
    }

    public void TakeHealth()
    {
        _spriteRenderer.DOColor(Color.white, 0).SetLoops(2, LoopType.Yoyo);

        if (_correctHealth < _maxHealth)
            _correctHealth += _health;
        else if (_correctHealth > _maxHealth)
            _correctHealth = _maxHealth;

        _spriteRenderer.DOColor(Color.green, 0.1f).SetLoops(2, LoopType.Yoyo);
    }
}
