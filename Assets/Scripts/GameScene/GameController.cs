using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    private List<GameBehaviour> behaviours = new List<GameBehaviour>();
    private MouseBehaviour mouseBehaviour;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Initialize behaviours
        mouseBehaviour = new MouseBehaviour();
        behaviours.Add(mouseBehaviour);
    }

    void Start()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Start();
        }
    }

    void Update()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.Update();
        }
    }

    void OnDestroy()
    {
        foreach (var behaviour in behaviours)
        {
            behaviour.OnDestroy();
        }
    }

    public bool IsMouseLocked
    {
        get { return mouseBehaviour.IsMouseLocked; }
    }
}
