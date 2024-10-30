using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage; // (67)
    public float damageRate; // (68)

    List<IDamagalbe> things = new List<IDamagalbe>(); // (70)

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate); // (74)
    }

    void DealDamage() // (68)
    {
        for (int i = 0; i < things.Count; i++)
        {
            things[i].TakePhysicalDamage(damage);
        } // (73)
    }

    private void OnTriggerEnter(Collider other) // (69)
    {
        if (other.TryGetComponent(out IDamagalbe damagaIbe))
        {
            things.Add(damagaIbe); // (71)
        }
    }

    private void OnTriggerExit(Collider other) // (72)
    {
        if (other.TryGetComponent(out IDamagalbe damagable))
        {
            things.Remove(damagable);
        }
    }
}
