using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveSystem
{

	private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves";
	public static void init()
	{
		// if Save folder does not exist create one
		if (!Directory.Exists(SAVE_FOLDER))
		{
			Directory.CreateDirectory(SAVE_FOLDER);
		}
	}

	

	public static void Save(string saveString)
	{
		int saveNumber = 1;

		while(File.Exists("save_" + saveNumber + ".json"))
		{
			saveNumber++;
		}
		
		File.WriteAllText(SAVE_FOLDER + "save" + saveNumber + ".json"  , saveString);
	}

	public static string Load()
	{
			
		
		if (File.Exists(SAVE_FOLDER + "/save.txt"))
		{
			string saveString = File.ReadAllText(SAVE_FOLDER + "/save.json");

			return saveString;
		}
		else
		{
			return null;
		}
	}


}
