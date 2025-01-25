using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TeleportButtonManager : MonoBehaviour
{
    public RawImage rawImage; // ������ʾͼƬ����Ƶ��UI���
    public VideoPlayer videoPlayer; // ��Ƶ���������
    public Texture imageTexture; // ��̬ͼƬ������
    public RenderTexture videoRenderTexture; // ��Ƶ��RenderTexture

    void Start()
    {
        // ��ʼ��ʱ��ʾͼƬ
        rawImage.texture = imageTexture;
        videoPlayer.targetTexture = videoRenderTexture;
        videoPlayer.loopPointReached += OnVideoEnd; // ��Ƶ����
    }

    void Update()
    {
        // �����Ƶ����״̬
        if (videoPlayer.isPlaying)
        {
            rawImage.texture = videoRenderTexture; // ��ʾ��Ƶ
        }
        else
        {
            rawImage.texture = imageTexture; // ��ʾͼƬ
        }
    }

    public void PlayVideo()
    {
        videoPlayer.Play(); 
    }

    public void PauseVideo()
    {
        videoPlayer.Pause(); 
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // ��Ƶ����ʱ��ʾͼƬ
        rawImage.texture = imageTexture;
    }
}
