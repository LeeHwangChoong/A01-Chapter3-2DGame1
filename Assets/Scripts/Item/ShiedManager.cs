using System.Collections;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public static ShieldManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivateShield(GameObject shieldObject, float duration)
    {
        StartCoroutine(ShieldTimer(shieldObject, duration));
    }

    private IEnumerator ShieldTimer(GameObject shieldObject, float duration)
    {
        shieldObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        shieldObject.SetActive(false);
    }
}