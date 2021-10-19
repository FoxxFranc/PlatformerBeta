using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _hitPoints;

    private int _numberOfCoins;

    public int HitPoints => _hitPoints;

    public void TakeDamage(int damage)
    {
        _hitPoints -= damage;
        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeCoin()
    {
        _numberOfCoins++;
    }
}
