using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void OnDamage(Collision2D collision, float damage);
}
