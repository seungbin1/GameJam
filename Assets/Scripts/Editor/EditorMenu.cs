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
        EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity"); 
    }

    [MenuItem("Scenes/Test/JunseoScene")]
    static void EditorMenu_LoadInJunseoScene() // 준서 씬
    {
        EditorSceneManager.OpenScene("Assets/Scenes/JunseoScene.unity");
    }
}
