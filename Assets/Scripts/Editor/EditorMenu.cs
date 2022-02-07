using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

public class EditorMenu : MonoBehaviour
{
    [MenuItem("Scenes/GameScene")]
    static void EditorMenu_LoadInGameScene() // 게임 씬
    {
        EditorSceneManager.OpenScene("Assets/Scenes/SampleScene.unity"); 
    }
}
