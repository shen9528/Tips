using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarVisualization : MonoBehaviour
{
    public AudioClip[] Clips;
    public SpriteRenderer[] BarsSprites;
    public Slider MusicSlider;
    [Range(0, 10)]
    public float ColorMultiply = 1;
    [Range(0, 1)]
    public float s = 1;
    [Range(0, 1)]
    public float v = 1;

    int index = 0;
    float musicLength;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //play the music when the game starts
        ChangeSound();
    }

    private void Update()
    {
        Visualize();
        if (Input.GetMouseButtonDown(0))
        {
            ChangeSound();
        }
        MusicSliderFunc();
    }

    //music visualization
    void Visualize()
    {
        float[] musicData = new float[64];
        audioSource.GetSpectrumData(musicData, 0, FFTWindow.Triangle);
        int i = 0;
        while (i < 44)
        {
            BarsSprites[i].transform.localScale = new Vector3(0.2f, musicData[i] * 5, 1);
            BarsSprites[i].color = HSVtoRGB(musicData[i] * ColorMultiply, s, v, 1);
            i++;
        }
    }

    //play next one
    void ChangeSound()
    {
        index++;
        if (index > Clips.Length - 1)
        {
            index = 0;
        }
        audioSource.clip = Clips[index];
        audioSource.Play();
    }

    //show music's playback progress
    void MusicSliderFunc()
    {
        musicLength = audioSource.time;
        MusicSlider.value = musicLength / audioSource.clip.length;
    }

    //color changes
    public static Color HSVtoRGB(float hue, float saturation, float value, float alpha)
    {
        while (hue > 1)
        {
            hue -= 1;
        }
        while (hue < 0)
        {
            hue += 1;
        }
        while (saturation > 1)
        {
            saturation -= 1;
        }
        while (saturation < 0)
        {
            saturation += 1;
        }
        while (value > 1)
        {
            value -= 1;
        }
        while (value < 0)
        {
            value += 1f;
        }
        hue = Mathf.Clamp(hue, 0.001f, 0.999f);
        if (saturation > 0.999f)
        {
            saturation = 0.999f;
        }
        if (saturation < 0.001f)
        {
            return new Color(value * 255, value * 255, value * 255);
        }
        value = Mathf.Clamp(value, 0.001f, 0.999f);

        float h6 = hue * 6f;
        if (h6 == 6f)
        {
            h6 = 0;
        }
        int ihue = (int)h6;
        float p = value * (1 - saturation);
        float q = value * (1 - (saturation * (h6 - (float)ihue)));
        float t = value * (1 - (saturation * (1 - (h6 - (float)ihue))));
        switch (ihue)
        {
            case 0:
                return new Color(value, t, p, alpha);
            case 1:
                return new Color(q, value, p, alpha);
            case 2:
                return new Color(p, value, t, alpha);
            case 3:
                return new Color(p, q, value, alpha);
            case 4:
                return new Color(t, p, value, alpha);
            default:
                return new Color(value, p, q, alpha);
        }
    }
}
