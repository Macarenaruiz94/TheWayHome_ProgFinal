using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instanciarEnemigos : MonoBehaviour
{
    public GameObject[] enemigos;
    public float instanciarTimer = 2f;
    private Vector2 screenBound;
    void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemigoWave());
    }

    void InstanciarEnemigo()
    {
        GameObject a = Instantiate(enemigos[Random.Range(0, enemigos.Length)]) as GameObject;
        a.transform.position = new Vector2(screenBound.x * 2, Random.Range(-screenBound.y, screenBound.y));
    }

    IEnumerator EnemigoWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(instanciarTimer);
            InstanciarEnemigo();
        }
    }
}
