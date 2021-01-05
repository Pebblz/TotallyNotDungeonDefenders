using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstracts is a keyword that means you can't use it on an object
//you need to have a class derive from it in order for it to work
//this is used so we can still use classes like start and update with monoBehaviour
public abstract class EnemyBaseClass : MonoBehaviour
{
    float damage;
    Animator anim;
    float health;
    float speed;
    PlayerScript playerScript;
    public EnemyBaseClass(float _damage, float _health, float _speed)
    {
        damage = _damage;
        health = _health;
        speed = _speed;
    }
    public void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        anim = GetComponent<Animator>();
    }

    public void HitPlayer() {}
}
