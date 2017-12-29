using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.NativePlugins;

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
}
