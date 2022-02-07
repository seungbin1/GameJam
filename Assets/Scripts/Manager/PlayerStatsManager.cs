using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    #region Sigleton
    private static PlayerStatsManager _instance;
    public static PlayerStatsManager Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }
            else
            {
                var obj = FindObjectOfType<PlayerStatsManager>();
                if (obj != null)
                {
                    _instance = obj;
                }
                else
                {
                    var playerStatsManager = new GameObject("PlayerStatsManager").AddComponent<PlayerStatsManager>();
                    _instance = playerStatsManager;
                }
            }
            return _instance;
        }
    }

    void Awake()
    {
        var objs = FindObjectsOfType<PlayerStatsManager>();
        if (objs.Length != 1)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    [SerializeField] private int hp = 3;
    public int HP { get => hp; }

    [SerializeField] private int maxHp = 3;
    public int MaxHp { get => maxHp; }

    [SerializeField] private float speed = 0f;
    public float Speed { get => speed; }

    [SerializeField] private float jumpPower = 20f;
    public float JumpPower { get => jumpPower; }

    public void TakeDamage(int damage)
    {
        this.hp -= damage;
        ClampHP();
    }

    public void Heal(int heal)
    {
        this.hp += heal;
        ClampHP();
    }

    void ClampHP()
    {
        hp = Mathf.Clamp(hp, 0, maxHp);
    }
}
