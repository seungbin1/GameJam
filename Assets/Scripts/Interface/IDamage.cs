using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void OnDamage(Collider2D collider, float damage);
}
