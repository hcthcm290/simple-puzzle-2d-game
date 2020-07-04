using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected int health = 100;

    abstract protected void TakenDamage(int dmg);
}
