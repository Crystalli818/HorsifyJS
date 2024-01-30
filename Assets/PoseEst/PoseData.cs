using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoseData
{
    public List<double> bbox;
    public Keypoints keypoints;

    public override string ToString()
    {


        string s = "";

        s = s + "bbox: " + toStringDoubleList(bbox) + "\n";

        s = s + "LeftBackPaw: " + toStringDoubleList(keypoints.LeftBackPaw) + "\n";
        s = s + "LeftElbow: " + toStringDoubleList(keypoints.LeftElbow) + "\n";
        s = s + "LeftEye: " + toStringDoubleList(keypoints.LeftEye) + "\n";
        s = s + "LeftFrontPaw: " + toStringDoubleList(keypoints.LeftFrontPaw) + "\n";
        s = s + "LeftHip: " + toStringDoubleList(keypoints.LeftHip) + "\n";
        s = s + "LeftKnee: " + toStringDoubleList(keypoints.LeftKnee) + "\n";
        s = s + "LeftShoulder: " + toStringDoubleList(keypoints.LeftShoulder) + "\n";

        s = s + "Neck: " + toStringDoubleList(keypoints.Neck) + "\n";
        s = s + "Nose: " + toStringDoubleList(keypoints.Nose) + "\n";

        s = s + "RightBackPaw: " + toStringDoubleList(keypoints.RightBackPaw) + "\n";
        s = s + "RightElbow: " + toStringDoubleList(keypoints.RightElbow) + "\n";
        s = s + "RightEye: " + toStringDoubleList(keypoints.RightEye) + "\n";
        s = s + "RightHip: " + toStringDoubleList(keypoints.RightHip) + "\n";
        s = s + "RightKnee: " + toStringDoubleList(keypoints.RightKnee) + "\n";
        s = s + "RightShoulder: " + toStringDoubleList(keypoints.RightShoulder) + "\n";
        s = s + "RootofTail: " + toStringDoubleList(keypoints.RootofTail) + "\n";

        return s;
    }

    private static string toStringDoubleList(List<double> list)
    {

        if(list.Count == 0)
        {
            return "empty";
        }

        string s = "[ ";
        
        foreach(double d in list)
        {
            s = s + d.ToString() + ", ";
        }

        s = s + " ]";
        return s;
    }

    public PoseData(string json)
    {
        bbox = parseDoubleListFromJson(json, "bbox");
        keypoints = new Keypoints(json);
    }


    public static List<double> parseDoubleListFromJson(string json, string key)
    {
        List<double> doubleValues = new List<double>();

        string searchTerm = "\"" + key + "\":";
        int start = json.IndexOf(searchTerm, 0) + searchTerm.Length + 1;
        int end = json.IndexOf("]", start);


        foreach (string s in json.Substring(start, end - start).Split(','))
        {
            if (double.TryParse(s, out double parsedValue))
            {
                doubleValues.Add(parsedValue);
            }
        }
        return doubleValues;
    }
}


[System.Serializable]
public class Keypoints
{
    public Keypoints(string json)
    {
        LeftBackPaw = PoseData.parseDoubleListFromJson(json, "Left Back Paw");
        LeftElbow = PoseData.parseDoubleListFromJson(json, "Left Elbow");
        LeftEye = PoseData.parseDoubleListFromJson(json, "Left Eye");
        LeftFrontPaw = PoseData.parseDoubleListFromJson(json, "Left Front Paw");
        LeftHip = PoseData.parseDoubleListFromJson(json, "Left Hip");
        LeftKnee = PoseData.parseDoubleListFromJson(json, "Left Knee");
        LeftShoulder = PoseData.parseDoubleListFromJson(json, "Left Shoulder");

        Neck = PoseData.parseDoubleListFromJson(json, "Neck");
        Nose = PoseData.parseDoubleListFromJson(json, "Nose");

        RightBackPaw = PoseData.parseDoubleListFromJson(json, "Right Back Paw");
        RightElbow = PoseData.parseDoubleListFromJson(json, "Right Elbow");
        RightEye = PoseData.parseDoubleListFromJson(json, "Right Eye");
        RightFrontPaw = PoseData.parseDoubleListFromJson(json, "Right Front Paw");
        RightHip = PoseData.parseDoubleListFromJson(json, "Right Hip");
        RightKnee = PoseData.parseDoubleListFromJson(json, "Right Knee");
        RightShoulder = PoseData.parseDoubleListFromJson(json, "Right Shoulder");

        RootofTail = PoseData.parseDoubleListFromJson(json, "Root of Tail");
    }

    //[JsonProperty("Left Back Paw")]
    public List<double> LeftBackPaw;

    //[JsonProperty("Left Elbow")]
    public List<double> LeftElbow;

    //[JsonProperty("Left Eye")]
    public List<double> LeftEye;

    //[JsonProperty("Left Front Paw")]
    public List<double> LeftFrontPaw;

    //[JsonProperty("Left Hip")]
    public List<double> LeftHip;

    //[JsonProperty("Left Knee")]
    public List<double> LeftKnee;

    //[JsonProperty("Left Shoulder")]
    public List<double> LeftShoulder;
    public List<double> Neck;
    public List<double> Nose;

    //[JsonProperty("Right Back Paw")]
    public List<double> RightBackPaw;

    //[JsonProperty("Right Elbow")]
    public List<double> RightElbow;

    //[JsonProperty("Right Eye")]
    public List<double> RightEye;

    //[JsonProperty("Right Front Paw")]
    public List<double> RightFrontPaw;

    //[JsonProperty("Right Hip")]
    public List<double> RightHip;

    //[JsonProperty("Right Knee")]
    public List<double> RightKnee;

    //[JsonProperty("Right Shoulder")]
    public List<double> RightShoulder;

    //[JsonProperty("Root of Tail")]
    public List<double> RootofTail;
}