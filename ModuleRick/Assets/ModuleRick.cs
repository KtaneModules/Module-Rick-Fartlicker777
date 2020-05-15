using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class ModuleRick : MonoBehaviour
{
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
    int otherotherfat = 0;
    string otherotherotherfat = "FATASSANSWERCONFIRMCONFIRMANSWERGUCCI";

    void Awake()
	{
		moduleId = moduleIdCounter++;
		Iturnedmyselfintoamodulemortyyyyyyyyyyy.OnInteract += delegate () { PressRick(); return false; };
		Rickie.OnInteract += delegate () { PressRicksBalls(); return false; };
    }

    void Start()
	{
		otherotherotherfat = Bomb.GetSerialNumber();
		fat = (int)Char.GetNumericValue(otherotherotherfat[5]);
		if (fat == 0)
		{
			fat = 10;
		}
		Debug.LogFormat("[Module Rick #{0}] Module Rick needs to be pressed {1} times.", moduleId, fat);
	}

	void PressRick()
	{
		Audio.PlaySoundAtTransform("ITurnedMyselfIntoAModuleMorty", transform);
		Iturnedmyselfintoamodulemortyyyyyyyyyyy.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
		if (!moduleSolved)
		{
			otherotherfat += 1;
			if (otherotherfat == 11)
			{
				otherotherfat = 0;
			}
			Debug.LogFormat("[Module Rick #{0}] Module Rick has now been pressed {1} times from one Rick.", moduleId, otherotherfat);
			Rickle.GetComponent<MeshRenderer>().material = IMMODULERICK[otherotherfat];
		}
	}

	void PressRicksBalls()
	{
		Rickie.AddInteractionPunch();
		GetComponent<KMAudio>().PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
		if (!moduleSolved)
		{
			if (otherotherfat == fat)
			{
				Audio.PlaySoundAtTransform("ImModuleRick", transform);
				Debug.LogFormat("[Module Rick #{0}] You solved Module Rick.", moduleId, otherotherfat);
				GetComponent<KMBombModule>().HandlePass();
				moduleSolved = true;
			}
			else
			{
				Audio.PlaySoundAtTransform("ImGoingIntoCardiacArrest", transform);
				Debug.LogFormat("[Module Rick #{0}] How.", moduleId, otherotherfat);
				GetComponent<KMBombModule>().HandleStrike();
			}
		}
	}
	
	//twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use the command !{0} press [1-11] to press the module | Use the command !{0} submit to press the ring";
    #pragma warning restore 414
	
	string[] Valid = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11"};
	
	IEnumerator ProcessTwitchCommand(string command)
	{
		string[] parameters = command.Split(' ');
		if (Regex.IsMatch(command, @"^\s*submit\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
		{
			yield return null;
			Rickie.OnInteract();
		}
		
		else if (Regex.IsMatch(parameters[0], @"^\s*press\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
		{
			yield return null;
			if (parameters.Length != 2)
			{
				yield return "sendtochaterror The parameter length is invalid";
				yield break;
			}
			
			if (!parameters[1].EqualsAny(Valid))
			{
				yield return "sendtochaterror The text written is not between 1-10";
				yield break;
			}
			
			for (int x = 0; x < Int32.Parse(parameters[1]); x++)
			{
				Iturnedmyselfintoamodulemortyyyyyyyyyyy.OnInteract();
				yield return new WaitForSecondsRealtime(0.2f);
			}
		}
	}
}
