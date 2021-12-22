using System.IO;
using System;
using Newtonsoft.Json;
using UnityEngine;

public static class Settings
{
    private static string dir => $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{Application.companyName}";
    private static string fileName => "settings.json";
    private static string path => Path.Combine(dir, fileName);
    private static void SetSettings(GameSettings settings)
    {
        File.WriteAllText(path, JsonConvert.SerializeObject(settings));
    }

    public static bool FullScreen { 
        get
        { 
            return GetSettings().Fullscreen; 
        } 
        set 
        { 
            GameSettings newSettings = GetSettings(); newSettings.Fullscreen = value; SetSettings(newSettings); 
        } 
    }

    public static int ResX => GetSettings().ResX;
    public static int ResY => GetSettings().ResY;

    public static void SetResolution(int width, int height)
    {
        GameSettings settings = GetSettings();
        settings.ResX = width; settings.ResY = height;
        Screen.SetResolution(width, height, settings.Fullscreen);
        SetSettings(settings);
    }

    public static void SetQualityLevel(int level)
    {
        GameSettings settings = GetSettings();
        settings.GraphicsQuality = level;
        SetSettings(settings);
    }

    public static void InitSettings()
    {
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(path))
            SetSettings(new GameSettings());

        SetResolution(ResX, ResY);
        FullScreen = FullScreen;
        SetQualityLevel(GetSettings().GraphicsQuality);
    }

    public static GameSettings GetSettings()
    {
        return JsonConvert.DeserializeObject<GameSettings>(File.ReadAllText(path));
    }

}