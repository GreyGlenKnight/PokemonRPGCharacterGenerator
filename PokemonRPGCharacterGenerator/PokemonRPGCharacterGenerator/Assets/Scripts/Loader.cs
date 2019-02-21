using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameManager gameManager;

    private void Awake()
    {
        if (gameManager == null)
            gameManager = Instantiate(gameManager);

    }


}
