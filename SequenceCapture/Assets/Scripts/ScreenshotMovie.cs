// modified from http://wiki.unity3d.com/index.php/ScreenshotMovie

using UnityEngine;

public class ScreenshotMovie : MonoBehaviour
{
	// The folder we place all screenshots inside.
	// If the folder exists we will append numbers to create an empty folder.
	public string folder = "ScreenshotMovieOutput";
	public int frameRate = 24;
	public int sizeMultiplier = 1;
	
	private string realFolder = "";
	private bool recording = false;
	private bool folderMade = false;

	void Update()
	{

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			recording = !recording;
			folderMade = false;
		}

		if (recording) 
		{
			// Set the playback framerate!
			// (real time doesn't influence time anymore)
			Time.captureFramerate = frameRate;
			
			if (!folderMade)
			{
				// Find a folder that doesn't exist yet by appending numbers!
				realFolder = folder;
				int count = 1;
				while (System.IO.Directory.Exists(realFolder))
				{
					realFolder = folder + "_" + count;
					count++;
				}
				// Create the folder
				System.IO.Directory.CreateDirectory(realFolder);

				folderMade = true;
			}

			// name is "realFolder/shot 0005.png"
			var name = string.Format ("{0}/shot {1:D04}.png", realFolder, Time.frameCount);

			// Capture the screenshot
			Application.CaptureScreenshot (name, sizeMultiplier);

			Debug.Log ("Capturing to folder: " + realFolder);
		}
	}
}


