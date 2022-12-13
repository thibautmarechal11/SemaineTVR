using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;


    public int health = 40;
    public GemScript[] gems;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (health <= 30)
            gems[0].Destroy();
        if (health <= 20)
            gems[1].Destroy();
        if (health <= 10)
            gems[2].Destroy();
        if (health <= 0)
            gems[3].Destroy();
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;

        if (health <= 0)
            Death();
    }
    
    void Death()
    {

    }
}
