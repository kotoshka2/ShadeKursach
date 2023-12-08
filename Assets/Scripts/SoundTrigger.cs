using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    [SerializeField] private int TriggerNum;
    private GameManager _gameManager => GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    private Collider2D _collider2D => GetComponent<BoxCollider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        _gameManager.PlaySound(TriggerNum);
        _collider2D.enabled = false;
    }
}
