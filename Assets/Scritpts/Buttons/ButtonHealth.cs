using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ButtonHealth : MonoBehaviour
{
    [SerializeField] private float _health = 10;
    public float HealthValue => _health;
}