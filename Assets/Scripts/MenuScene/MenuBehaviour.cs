using UnityEngine;

public class MenuBehaviour : MonoBehaviour
{
    
    public GameObject[] rightMenus;

    public void enableRightMenu(GameObject rightMenu){

        if(!isARightMenu(rightMenu)){
            Debug.LogWarning("Trying to enable a menu that is not in the right menus list.");
            return;
        }

        if(rightMenu.activeSelf){
            disableAllRightMenus();
        }else{
            disableAllRightMenus();
            rightMenu.SetActive(true);
        }
    }

    private bool isARightMenu(GameObject menu){
        for(int i = 0; i < rightMenus.Length; i++){
            if(rightMenus[i] == menu){
                return true;
            }
        }
        return false;
    }

    private void disableAllRightMenus(){
        for(int i = 0; i < rightMenus.Length; i++){
            rightMenus[i].SetActive(false);
        }
    }

    public void QuitGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

}
