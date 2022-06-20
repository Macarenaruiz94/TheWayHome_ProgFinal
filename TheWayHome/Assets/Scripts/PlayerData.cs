using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private string playerName;
    [SerializeField] private string habilidad;
    [SerializeField] private int vida;

    public string PlayerName { get { return playerName; } }
    public string Habilidad { get { return habilidad; } }
    public int Vida { get { return vida; } }
}
