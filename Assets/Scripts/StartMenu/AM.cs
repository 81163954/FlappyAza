using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;

public class AM : MonoBehaviour
{
    public Slider slider;
    public Toggle toggle;
    public AudioSource BGsound;
    // Start is called before the first frame update

    private void Start()
    {
        if (PlayerPrefs.HasKey("globalVolume")){
            BGsound.volume = PlayerPrefs.GetFloat("globalVolume");
            slider.value = PlayerPrefs.GetFloat("globalVolume");
        }
/*        LoadPrefabAndDoSomething("Assets/Prefabs/GlobalAudio/Canvas.prefab", obj => {
            slider.value = obj.GetComponent<AudioSource>().volume;
            //这里只读，无需加载到预制体
            return false;
        });*/
    }

    public void Volume()
    {
        Debug.Log("change volume");
        BGsound.volume = slider.value;
        PlayerPrefs.SetFloat("globalVolume", BGsound.volume);

    }
    /*public void WriteVolumeToPrefab()
    {
        LoadPrefabAndDoSomething("Assets/Prefabs/GlobalAudio/Canvas.prefab", obj => {
            obj.GetComponent<AudioSource>().volume = slider.value;
            return true;
        });
        LoadPrefabAndDoSomething("Assets/Prefabs/GlobalAudio/GM.prefab", obj => {
            obj.GetComponent<AudioSource>().volume = slider.value;
            return true;
        });
    }*/
    /*private void LoadPrefabAndDoSomething(string prefabPath, Func<GameObject, bool> doMethod)
    { 
*//*#if UNITY_EDITOR*//*
        GameObject targetObj = (GameObject)Resources.Load(prefabPath);
        bool isChange = doMethod(targetObj);
        if (isChange)
        {
            EditorUtility.SetDirty(targetObj);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
*//*#endif*//*
    }*/
}


 



