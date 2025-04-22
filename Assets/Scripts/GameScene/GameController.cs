using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance { get { return instance; } }

    private List<GameBehaviour> behaviours = new List<GameBehaviour>();
    private MouseBehaviour mouseBehaviour;
    private GameMenuBehaviour menuBehaviour;
    private CraftMenuBehaviour craftMenuBehaviour;

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
        menuBehaviour = new GameMenuBehaviour(mouseBehaviour);
        craftMenuBehaviour = new CraftMenuBehaviour(mouseBehaviour, menuBehaviour);
        
        // Set up cross-references
        menuBehaviour.SetCraftMenuBehaviour(craftMenuBehaviour);
        
        behaviours.Add(mouseBehaviour);
        behaviours.Add(menuBehaviour);
        behaviours.Add(craftMenuBehaviour);
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
