﻿using UnityEngine;
using System.Collections;
using System.IO;

// This class encapsulates all of the metrics that need to be tracked in your game. These may range
// from number of deaths, number of times the player uses a particular mechanic, or the total time
// spent in a level. These are unique to your game and need to be tailored specifically to the data
// you would like to collect. The examples below are just meant to illustrate one way to interact
// with this script and save data.
public class MetricManager : MonoBehaviour
{
    // You'll have more interesting metrics, and they will be better named.
    private int fire_input;
    private int jump_input;
    private int shield_input;

    // Public method to add to Metric 1.
    public void AddToMetric1(int valueToAdd)
    {
        fire_input += valueToAdd;
    }

    // Public method to add to Metric 2.
    public void AddToMetric2(int valueToAdd)
    {
        jump_input += valueToAdd;
    }

    public void AddToMetric3(int valueToAdd)
    {
        shield_input += valueToAdd;
    }

    // Converts all metrics tracked in this script to their string representation
    // so they look correct when printing to a file.
    private string ConvertMetricsToStringRepresentation()
    {
        string metrics = "Here are my metrics:\n";
        metrics += "Fire inputs: " + fire_input.ToString() + "\n";
        metrics += "Jump inputs: " + jump_input.ToString() + "\n";
        metrics += "Shield inputs: " + shield_input.ToString() + "\n";

        return metrics;
    }

    // Uses the current date/time on this computer to create a uniquely named file,
    // preventing files from colliding and overwriting data.
    private string CreateUniqueFileName()
    {
        string dateTime = System.DateTime.Now.ToString();
        dateTime = dateTime.Replace("/", "_");
        dateTime = dateTime.Replace(":", "_");
        dateTime = dateTime.Replace(" ", "___");
        return "DankTanks_metrics_" + dateTime + ".txt";
    }

    // Generate the report that will be saved out to a file.
    private void WriteMetricsToFile()
    {
        string totalReport = "Report generated on " + System.DateTime.Now + "\n\n";
        totalReport += "Total Report:\n";
        totalReport += ConvertMetricsToStringRepresentation();
        totalReport = totalReport.Replace("\n", System.Environment.NewLine);
        string reportFile = CreateUniqueFileName();

#if !UNITY_WEBPLAYER
        File.WriteAllText(reportFile, totalReport);
#endif
    }

    // The OnApplicationQuit function is a Unity-Specific function that gets
    // called right before your application actually exits. You can use this
    // to save information for the next time the game starts, or in our case
    // write the metrics out to a file.
    private void OnApplicationQuit()
    {
        WriteMetricsToFile();
    }
}
