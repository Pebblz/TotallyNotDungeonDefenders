using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : EnemyBaseClass
{
    float damage = 10;
    float speed = 5;
    float health = 100;
    public Goblin(float _damage, float _speed, float _health) : base(10, 100, 5)
    {
        damage = _damage;
        speed = _speed;
        health = _health;
    }

     void Start()
    {
        //calls the start from parent
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
