using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController:MonoBehaviour
{

    //�˽ű�����Ҫ�̳�MonoBehaviour   


    public static Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();


    private void Start()
    {
        
    }
    /// <summary>
    /// ��Ҫ����ĳ����Ч��ʱ����Ҫ���ô˷����Ϳ�����
    /// </summary>
    /// <param name="dir">��������Ч��·��, ������ResourcesĿ¼��</param>
    /// <param name="name">��Ч������</param>
    public static void PlaySnd(string dir, string name)
    {

        AudioClip clip = LoadClip(dir, name.ToLower());
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, new Vector3(0f,0f,7f));   //Vector3.zero �ǲ������ֵ�λ��(0,0,0)
        else                                                   // ���������������λ��Զ�Ļ����������С���������������
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

    //���ò���
    private void AudioSourceShow()
    {

        //��������������õ�ʱ��ֻ��Ҫ�����������̬����
        //����Ŀǰ�������ļ�����(Resources/Muisc)Ŀ¼�£��ļ���ΪOnClick��
        //AudioSourceController.PlaySnd("Music", "OnClick");  //(����Ч��������Զ�ɾ��)
    }

}