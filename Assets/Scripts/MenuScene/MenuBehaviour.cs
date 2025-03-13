using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    
    public GameObject playGameRightMenu;

    public void PlayGame(){
        if(playGameRightMenu.activeSelf)
            playGameRightMenu.SetActive(false);
        else    
            playGameRightMenu.SetActive(true);
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
