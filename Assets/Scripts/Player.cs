using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller; // (4)

    private void Awake() //(5)
    {
        CharacterManager.Instance.Player = this; // CharacterManager.cs�� �ν��Ͻ��� ����Ǿ� �Լ�ó����
        controller = GetComponent<PlayerController>();
    }
}
