using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;
using System.IO;
using System;
using Reign;

public class OpenFromGallery : MonoBehaviour {

    public Texture2D texture; 
    public ImageTests imageTests;
    public void Open()
    {
        #if UNITY_EDITOR
        PickImageFinished(texture);
        #else
        NPBinding.MediaLibrary.SetAllowsImageEditing(false);
        NPBinding.MediaLibrary.PickImage(eImageSource.ALBUM, 1, PickImageFinished);
       #endif
    }

    private void PickImageFinished(
        ePickImageFinishReason _reason, Texture2D _image)
    {
        if (_image == null)
            return;
        imageTests.SetTexture(_image);
    }

    private void PickImageFinished(Texture2D _image)
    {
        if (_image == null)
            return;
        imageTests.SetTexture(_image);
    }

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
