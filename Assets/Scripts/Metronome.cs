using UnityEngine;
using System.Collections;

public class Metronome : MonoBehaviour {

  public double bpm;
  public int beatsPerBar;
  public SoundPlayer soundPlayer;
  private int currentBeat = 0;
  private int prevBeat = 0;
  private double startTime = -1.0F;
  private bool running = false;
  private bool isBeatOne = false;

  public void start() {
    this.running = true;
    startTime = AudioSettings.dspTime;
  }

  void Update() {
    prevBeat = currentBeat;
    currentBeat = (int)((AudioSettings.dspTime - startTime) / (60.0F / bpm)) % beatsPerBar;

    isBeatOne = (prevBeat == beatsPerBar - 1 && currentBeat == 0);
    if (prevBeat != currentBeat) {
      Debug.Log("HERE YOU CAN EXECUTE ALL THE FUNCTIONS THAT HAPPEN EVERY BEAT.");
      Debug.Log("it is beat one: " + isBeatOne);
      soundPlayer.playSound(currentBeat);
    }

  }
}
