using UnityEngine;

public class MouseBehaviour : GameBehaviour
{
    private bool isMouseLocked = false;
    public bool IsMouseLocked { get { return isMouseLocked; } }

    public override void Start()
    {
        LockMouse();
    }

    public override void Update()
    {
        HandleMouseLock();
    }

    private void HandleMouseLock()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab))
        {
            UnlockMouse();
        }
        else if (Input.GetMouseButtonDown(0) && !isMouseLocked)
        {
            LockMouse();
        }
    }

    public void LockMouse()
    {
        isMouseLocked = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockMouse()
    {
        isMouseLocked = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
} 