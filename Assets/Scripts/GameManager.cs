using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Signleton

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Another instance of Game Manager found!");
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    #endregion

    public int currency;
}
