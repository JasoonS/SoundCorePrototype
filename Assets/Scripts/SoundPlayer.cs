using UnityEngine;
using System.Collections;
using System;

public class SoundPlayer : MonoBehaviour {

  public GridDisplay grid;
  public AudioSource clip1;
  public AudioSource clip2;
  public AudioSource clip3;
  public AudioSource clip4;

  public double frequency = 440;
  public double gain = 1;
  public bool manipulateSound = false;

  private double increment;
  private double phase;
  private double sampling_frequency = 48000;

  void Start () {

  }

  void Update () {

  }

  public void playSound(int beat) {
    Debug.Log("Beat - " + beat);
    if (grid.displayTokens[0, beat].selected) {
      clip2.Play();
    }
    if (grid.displayTokens[1, beat].selected) {
      Debug.Log("GREEN - " + beat);
    }
    if (grid.displayTokens[2, beat].selected) {
      Debug.Log("YELLOW - " + beat);
    }
    if (grid.displayTokens[3, beat].selected) {
      Debug.Log("BLUE - " + beat);
    }
  }

  void OnAudioFilterRead(float[] data, int channels)
  {
    if (manipulateSound){
      // update increment in case frequency has changed
      increment = frequency * 2 * Math.PI / sampling_frequency;
      for (var i = 0; i < data.Length; i = i + channels)
      {
        phase = phase + increment;
      // this is where we copy audio data to make them “available” to Unity
        data[i] = data[i] * (float)(gain*Math.Sin(phase));
      // if we have stereo, we copy the mono data to each channel
        if (channels == 2) data[i + 1] = data[i];
        if (phase > 2 * Math.PI) phase = 0;
      }
    }
  }
}
