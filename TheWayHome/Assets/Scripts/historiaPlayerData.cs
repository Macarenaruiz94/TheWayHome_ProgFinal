using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class historiaPlayerData : MonoBehaviour
{
    [SerializeField] PlayerData playerData;

    private void OnMouseDown()
    {
        textDataManager.Instance.UpdateText(playerData);
    }
}
