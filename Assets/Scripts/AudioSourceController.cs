using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController:MonoBehaviour
{

    //此脚本不需要继承MonoBehaviour   


    public static Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();


    private void Start()
    {
        
    }
    /// <summary>
    /// 需要播放某个音效的时候需要调用此方法就可以了
    /// </summary>
    /// <param name="dir">这是你音效的路径, 必须在Resources目录下</param>
    /// <param name="name">音效的名称</param>
    public static void PlaySnd(string dir, string name)
    {

        AudioClip clip = LoadClip(dir, name.ToLower());
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, new Vector3(0f,0f,7f));   //Vector3.zero 是播放音乐的位置(0,0,0)
        else                                                   // 如果主摄像机离这个位置远的话会出现声音小或者听不见的情况
            Debug.LogError("Clip is Missing" + name);
    }
    public static AudioClip LoadClip(string dir, string name)
    {
        if (!audioDic.ContainsKey(name))
        {
            string dirMusic = dir + "/" + name;
            AudioClip clip = Resources.Load(dirMusic) as AudioClip;
            if (clip != null)
                audioDic.Add(clip.name, clip);
        }
        return audioDic[name];
    }

    //调用测试
    private void AudioSourceShow()
    {

        //在其他类里面调用的时候只需要类名点这个静态方法
        //如我目前的音乐文件放在(Resources/Muisc)目录下，文件名为OnClick，
        //AudioSourceController.PlaySnd("Music", "OnClick");  //(此音效播放完会自动删除)
    }

}