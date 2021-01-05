using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : EnemyBaseClass
{
    [SerializeField]
    float damage = 10;
    [SerializeField]
    float speed = 5;
    [SerializeField]
    float health = 100;

    public override void Init(float _damage, float _health, float _speed)
    {
        _damage = damage;
        _health = health;
        _speed = speed;
        base.Init(_damage, _health, _speed);
    }

    public void Awake()
    {
        
        //calls the start from parent
        base.Awake();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
