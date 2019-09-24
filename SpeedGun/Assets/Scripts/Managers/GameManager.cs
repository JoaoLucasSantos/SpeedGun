using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController Player;

    void Start()
    {
        Player.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
