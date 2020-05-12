using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KModkit;

public class ModuleRick : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable Iturnedmyselfintoamodulemortyyyyyyyyyyy;
    public Material[] IMMODULERICK;
    public GameObject Rickle;
    public KMSelectable Rickie;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    int fat = 0;
    int otherfat = 0;
    int otherotherfat = 0;
    string otherotherotherfat = "FATASSANSWERCONFIRMCONFIRMANSWERGUCCI";

    void Awake () {
        moduleId = moduleIdCounter++;
        Iturnedmyselfintoamodulemortyyyyyyyyyyy.OnInteract += delegate () { PressRick(); return false; };
        Rickie.OnInteract += delegate () { PressRicksBalls(); return false; };
    }

    void Start () {
      otherotherotherfat = Bomb.GetSerialNumber();
      fat = (int)Char.GetNumericValue(otherotherotherfat[5]);
      if (fat == 0) {
        fat = 10;
      }
      Debug.LogFormat("[Module Rick #{0}] Module Rick needs to be pressed {1} times.", moduleId, fat);
	}

	void PressRick () {
    Audio.PlaySoundAtTransform("ITurnedMyselfIntoAModuleMorty", transform);
    Iturnedmyselfintoamodulemortyyyyyyyyyyy.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
    otherotherfat += 1;
    if (otherotherfat == 11) {
      otherotherfat = 0;
    }
    Debug.LogFormat("[Module Rick #{0}] Module Rick has now been pressed {1} times from one Rick.", moduleId, otherotherfat);
    Rickle.GetComponent<MeshRenderer>().material = IMMODULERICK[otherotherfat];
	}

  void PressRicksBalls(){
    Rickie.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
    if (otherotherfat == fat) {
      Audio.PlaySoundAtTransform("ImModuleRick", transform);
      Debug.LogFormat("[Module Rick #{0}] You solved Module Rick.", moduleId, otherotherfat);
      GetComponent<KMBombModule>().HandlePass();
    }
    else {
      Audio.PlaySoundAtTransform("ImGoingIntoCardiacArrest", transform);
      Debug.LogFormat("[Module Rick #{0}] How.", moduleId, otherotherfat);
      GetComponent<KMBombModule>().HandleStrike();
    }
  }
}
