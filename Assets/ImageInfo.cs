using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageInfo : MonoBehaviour
{
    public GameObject currentImage;
    public GameObject BigImage;
    // Start is called before the first frame update
    public void DisplayBigImage()
    {
        BigImage.GetComponent<Image>().sprite = currentImage.GetComponent<Image>().sprite;
        BigImage.SetActive(true);
    }
}
