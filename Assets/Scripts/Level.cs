using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; // serialized for debugging purposes

    //cached reference
    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            gameSession.increaseLevel();
            sceneLoader.LoadNextScene();
        }
    }
}
