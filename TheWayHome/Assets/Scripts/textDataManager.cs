using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textDataManager : MonoBehaviour
{
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text habilidadText;
    [SerializeField] private Text vidaText;

    private static textDataManager instance;

    public static textDataManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<textDataManager>();
            }
            return instance;
        }
    }

    public void UpdateText(PlayerData playerData)
    {
        playerNameText.text = playerData.PlayerName;
        habilidadText.text = playerData.Habilidad;
        vidaText.text = playerData.Vida.ToString();
    }
}
