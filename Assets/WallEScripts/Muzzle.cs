using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("hide", 3f);
    }

    void hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
