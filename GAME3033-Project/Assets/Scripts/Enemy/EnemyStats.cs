using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{
    public static int globalHealth = 100;
    public static int globalDamage = 10;

    public static void IncreaseStats()
    {
        globalHealth += 5;
        globalDamage += 5;
    }

    public static void IncreaseStats(int health, int damage)
    {
        globalHealth += health;
        globalDamage += damage;
    }
}
