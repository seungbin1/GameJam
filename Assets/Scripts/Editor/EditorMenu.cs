using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

public class EditorMenu : MonoBehaviour
{
    [MenuItem("Scenes/Game/GameScene")]
    static void EditorMenu_LoadInGameScene() // 게임 씬
    {
        EditorSceneManager.OpenScene("Assets/Scenes/GameScene.unity"); 
    }

    [MenuItem("Scenes/Test/JunseoScene")]
    static void EditorMenu_LoadInJunseoScene() // 준서 씬
    {
        EditorSceneManager.OpenScene("Assets/Scenes/JunseoScene.unity");
    }

    [MenuItem("Scenes/Game/MainMenu")]
    static void EditorMenu_LoadInMainMenu() // 메인메뉴 씬
    {
        EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
    }
}
