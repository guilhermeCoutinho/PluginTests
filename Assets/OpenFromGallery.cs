using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Reign;

public class OpenFromGallery : MonoBehaviour {

    public Texture2D texture; 
    public ImageTests imageTests;


    public void PickImage () {
        StreamManager.LoadFileDialog(FolderLocations.Pictures, new string[]{".png", ".jpg"}, imageLoadedCallback);
    }

    private void imageLoadedCallback(Stream stream, bool succeeded)
    {
        if (!succeeded)
        {
            if (stream != null) stream.Dispose();
            return;
        }

        try
        {
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            Texture2D tex = new Texture2D(4,4);
            texture.LoadImage(data);
            imageTests.SetTexture(texture);
        }
        catch (Exception e)
        {
            MessageBoxManager.Show("Error", e.Message);
        }
        finally
        {
            if (stream != null) stream.Dispose();
        }
    }
}
