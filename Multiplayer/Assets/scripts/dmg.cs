using UnityEngine;
using UnityEngine.Networking;

public class DamageClass : NetworkBehaviour
{
    public delegate void TakeDamageDelegate(int amount, float dir);

    [SyncEvent]
    public event TakeDamageDelegate EventTakeDamage;

    [Command]
    public void CmdDoMe(int val)
    {
        EventTakeDamage(val, 1.0f);
    }
}

public class dmg : NetworkBehaviour
{
    public DamageClass damager;
    int health = 100;

    void Start()
    {
        if (NetworkClient.active)
            damager.EventTakeDamage += TakeDamage;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Debug.Log(health);
    }
    public void TakeDamage(int amount, float dir)
    {
        health -= amount;
    }
}