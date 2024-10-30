using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager _instance; //(1) 싱글톤

    public static CharacterManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("CharacterManager").AddComponent<CharacterManager>();
            }
            return _instance;
        }

    }
    public Player _player; // (2)
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake() // (3)
    {
        if (_instance == null)
        {
            _instance = this; // 게임오브젝트를 넣을필요없음
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance == this)
            {
                Destroy(gameObject);
            }
        }
    }
}
