using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
