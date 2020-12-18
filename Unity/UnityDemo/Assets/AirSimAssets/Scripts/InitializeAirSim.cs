using System;
using System.Diagnostics;
using System.IO;
using AirSimUnity;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitializeAirSim : MonoBehaviour
{
    void Awake()
    {
        if (GetAirSimSettingsFileName() != string.Empty)
        {
            if (AirSimSettings.Initialize())
            {
                UnityEngine.Debug.Log("Example: " + AirSimSettings.GetSettings().SimMode);
                AirSimSettings.Initialize();
                AirSimSettings.GetSettings().SimMode = "Multirotor";
                UnityEngine.Debug.Log("Settings: " + AirSimSettings.GetSettings().SimMode);
                SceneManager.LoadSceneAsync("Scenes/DroneDemo", LoadSceneMode.Single);

            }
        }
    }

    public static string GetAirSimSettingsFileName()
    {

        string fileName = Application.dataPath + "\\..\\settings.json";
        if (File.Exists(fileName))
        {
            return fileName;
        }

        fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine("AirSim", "settings.json"));
        string linuxFileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine("Documents/AirSim", "settings.json"));
        if (File.Exists(fileName))
        {
            return fileName;
        }
        else
            return string.Empty;
    }
}
