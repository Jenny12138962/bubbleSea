using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class TeleportButtonManager : MonoBehaviour
{
    public RawImage rawImage; // 用于显示图片和视频的UI组件
    public VideoPlayer videoPlayer; // 视频播放器组件
    public Texture imageTexture; // 静态图片的纹理
    public RenderTexture videoRenderTexture; // 视频的RenderTexture

    void Start()
    {
        // 初始化时显示图片
        rawImage.texture = imageTexture;
        videoPlayer.targetTexture = videoRenderTexture;
        videoPlayer.loopPointReached += OnVideoEnd; // 视频结束
    }

    void Update()
    {
        // 检测视频播放状态
        if (videoPlayer.isPlaying)
        {
            rawImage.texture = videoRenderTexture; // 显示视频
        }
        else
        {
            rawImage.texture = imageTexture; // 显示图片
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
        // 视频结束时显示图片
        rawImage.texture = imageTexture;
    }
}
