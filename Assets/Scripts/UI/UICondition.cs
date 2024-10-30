using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health; // (51)
    public Condition hunger; // (52)
    public Condition stamina; // (53)

    void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this; // (54) // ΩÃ±€≈Ê?
    }

    void Update()
    {

    }
}
