using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using SimpleFileBrowser;
using UnityEngine.UI;

public class PoseEstimate : MonoBehaviour
{

    public enum PoseStatus {
        READY,
        DOWNLOADING,
        ERROR,
        SUCCESS,       
    }

    public PoseData pose = null;
    public PoseStatus status = PoseStatus.READY;
    public string url = "http://192.168.50.103:5000/fetch_pose";
    public string imagePath = "test.jpg";

    private Texture2D currentTexture; 

    public Image targetImage; // Reference to the UI Image component
    public float maxImageSize = 200.0f;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GetPoseWebRequest());
    }


    public void OnPressFileExplorer()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Images", ".jpg", ".png"), new FileBrowser.Filter("Text Files", ".txt", ".pdf"));
        FileBrowser.SetDefaultFilter(".jpg");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
        StartCoroutine(ShowLoadDialogCoroutine());
    }

    IEnumerator ShowLoadDialogCoroutine()
    {
        // Show a load file dialog and wait for a response from user
        // Load file/folder: both, Allow multiple selection: true
        // Initial path: default (Documents), Initial filename: empty
        // Title: "Load File", Submit button text: "Load"
        yield return FileBrowser.WaitForLoadDialog(FileBrowser.PickMode.Files, false, null, null, "Load Files and Folders", "Load");

        // Dialog is closed
        // Print whether the user has selected some files/folders or cancelled the operation (FileBrowser.Success)
        Debug.Log(FileBrowser.Success);

        if (FileBrowser.Success)
        {
            // Print paths of the selected files (FileBrowser.Result) (null, if FileBrowser.Success is false)
            for (int i = 0; i < FileBrowser.Result.Length; i++)
                Debug.Log(FileBrowser.Result[i]);

            // Read the bytes of the first file via FileBrowserHelpers
            // Contrary to File.ReadAllBytes, this function works on Android 10+, as well
            byte[] bytes = FileBrowserHelpers.ReadBytesFromFile(FileBrowser.Result[0]);

            // Or, copy the first file to persistentDataPath
            string destinationPath = Path.Combine(Application.persistentDataPath, FileBrowserHelpers.GetFilename(FileBrowser.Result[0]));
            FileBrowserHelpers.CopyFile(FileBrowser.Result[0], destinationPath);
            print(destinationPath);
            imagePath = destinationPath;
            SetImage();
            StartCoroutine(GetPoseWebRequest());
        }
    }

    private IEnumerator GetPoseWebRequest()
    {
        status = PoseStatus.DOWNLOADING;
        pose = null;

        // Combine the path of the image with the application data path
        string fullPath = Path.Combine(Application.dataPath, imagePath);

        // Read the image file as a byte array
        byte[] imageBytes = File.ReadAllBytes(fullPath);

        // HTTP Form
        WWWForm form = new WWWForm();

        // Add Image bytes to the form
        form.AddBinaryData("image", imageBytes, "image.jpg", "image/jpg");

        // Making the HTTP Post Request
        using (UnityWebRequest webRequest = UnityWebRequest.Post(url, form))
        {
            // Wait for the request resolve
            yield return webRequest.SendWebRequest();


            // If not successfull
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                status = PoseStatus.ERROR;
                Debug.Log(webRequest.error);
            }
            // If successfull
            else
            {
                status = PoseStatus.SUCCESS;
                Debug.Log("Form upload complete!");
                string rawTextJsonResponse = webRequest.downloadHandler.text;

                //pose = JsonUtility.FromJson<PoseData>(rawTextJsonResponse);
                pose = new PoseData(rawTextJsonResponse);

                print(rawTextJsonResponse);
                print(pose);
                //print(pose.bbox);
                //print(pose.keypoints);

                print("SetImage with pose");
                SetImage(pose);


            }
        }
    }


    private void SetImage()
    {
        Texture2D texture = LoadImageFromFile(imagePath);

        // Assign the loaded texture to the UI Image component and fit it to the size of the Image component
        if (texture != null)
        {
            targetImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);

            // Set the Image component's size to match the texture's size
            //targetImage.rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
        }
        currentTexture = texture;
    }


    private void SetImage(PoseData pose)
    {
        List<double> pt;

        print("SetImage with pose called");



        pt = pose.keypoints.Neck;
        currentTexture = DrawCircle(currentTexture, Color.red, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.Nose;
        currentTexture = DrawCircle(currentTexture, Color.red, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RootofTail;
        currentTexture = DrawCircle(currentTexture, Color.red, (int)pt[0], (int)pt[1], 5);


        pt = pose.keypoints.LeftBackPaw;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftElbow;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftEye;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftFrontPaw;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftHip;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftKnee;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.LeftShoulder;
        currentTexture = DrawCircle(currentTexture, Color.magenta, (int)pt[0], (int)pt[1], 5);

        pt = pose.keypoints.RightBackPaw;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightElbow;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightEye;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightFrontPaw;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightHip;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightKnee;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);
        pt = pose.keypoints.RightShoulder;
        currentTexture = DrawCircle(currentTexture, Color.cyan, (int)pt[0], (int)pt[1], 5);


        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftBackPaw, pose.keypoints.LeftKnee, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftHip, pose.keypoints.LeftKnee, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftHip, pose.keypoints.RootofTail, 5);

        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightBackPaw, pose.keypoints.RightKnee, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightHip, pose.keypoints.RightKnee, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightHip, pose.keypoints.RootofTail, 5);


        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftFrontPaw, pose.keypoints.LeftElbow, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftShoulder, pose.keypoints.LeftElbow, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftShoulder, pose.keypoints.Neck, 5);

        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightFrontPaw, pose.keypoints.RightElbow, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightShoulder, pose.keypoints.RightElbow, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightShoulder, pose.keypoints.Neck, 5);

        currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RootofTail, pose.keypoints.Neck, 5);

        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.LeftEye, pose.keypoints.Nose, 5);
        //currentTexture = DrawLine(currentTexture, Color.white, pose.keypoints.RightEye, pose.keypoints.Nose,5);


        // Assign the loaded texture to the UI Image component and fit it to the size of the Image component
        if (currentTexture != null)
        {

            targetImage.sprite = Sprite.Create(currentTexture, new Rect(0, 0, currentTexture.width, currentTexture.height), Vector2.one * 0.5f);
            print("Text set");

            // Set the Image component's size to match the texture's size
            //targetImage.rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
        }
    }


    public Texture2D DrawCircle(Texture2D tex, Color color, int x, int y, int radius = 10)
    {
        //print("DrawCircle");
        //print(x);
        //print(y);
        //print(tex.width);
        //print(tex.height);

        y = tex.height - y;

        float rSquared = radius * radius;

        for (int u = x - radius; u < x + radius + 1; u++)
        {
            for (int v = y - radius; v < y + radius + 1; v++)
            {
                if ((x - u) * (x - u) + (y - v) * (y - v) < rSquared)
                {
                    tex.SetPixel(u, v, color);
                    tex.Apply();
                }
            }
        }
        return tex;
    }


    private Texture2D DrawLine(Texture2D tex, Color color, List<double> start, List<double> end, int lineWidth = 3)
    {
        Vector2 startPoint = new Vector2((int)start[0], (int)start[1]);
        Vector2 endPoint = new Vector2((int)end[0], (int)end[1]);

        print(startPoint);
        print(endPoint);

        int minX = (int)Mathf.Min(startPoint.x, endPoint.x);
        int maxX = (int)Mathf.Max(startPoint.x, endPoint.x);
        int minY = (int)Mathf.Min(startPoint.y, endPoint.y);
        int maxY = (int)Mathf.Max(startPoint.y, endPoint.y);

        minY = tex.height - minY;
        maxY = tex.height - maxY;

        print(minX);
        print(maxX);

        print(minY);
        print(maxY);


        for (int x = minX; x <= maxX; x++)
        {
            for (int y = minY; y <= maxY; y++)
            {
                if (IsPointOnLine(new Vector2(x, y), startPoint, endPoint, lineWidth))
                {
                    tex.SetPixel(x, y, color);
                }
            }
        }

        tex.Apply();
        return tex;
    }

    private bool IsPointOnLine(Vector2 point, Vector2 lineStart, Vector2 lineEnd, int width)
    {
        Vector2 lineDirection = lineEnd - lineStart;
        Vector2 pointDirection = point - lineStart;

        float crossProduct = Vector3.Cross(lineDirection, pointDirection).magnitude;

        return crossProduct <= width * 0.5f;
    }



    private Texture2D LoadImageFromFile(string path)
    {
        Texture2D texture = null;
        if (System.IO.File.Exists(path))
        {
            byte[] data = System.IO.File.ReadAllBytes(path);
            texture = new Texture2D(2, 2);
            if (texture.LoadImage(data))
            {
                return texture;
            }
        }
        return null;
    }

}
