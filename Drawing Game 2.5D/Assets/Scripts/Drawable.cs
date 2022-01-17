using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class Drawable : MonoBehaviour
{
    public GameObject TextureEditor;
    public GameObject Overworld;
    // declare all brushes
    public GameObject WhiteBrush;
    public GameObject BlackBrush;
    public GameObject RedBrush;
    public GameObject GreenBrush;
    public GameObject BlueBrush;

    // Set brush size
    public float BrushSize = 0.1f;
    //Render Texture property
    public RenderTexture DRTexture;

    public bool whiteBrush = true;
    public bool blackBrush;
    public bool redBrush;
    public bool greenBrush;
    public bool blueBrush;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (whiteBrush == true && Input.GetMouseButton(0)) // if white brush is set and the mouse is clicked
        {
            // Cast ray from camera to mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(Ray, out hit))
            {
                // Create an instance of white brush slightly above the surface
                var newBrush = Instantiate(WhiteBrush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                newBrush.transform.localScale = Vector3.one * BrushSize;
                

            }

        }

        if (blackBrush == true && Input.GetMouseButton(0)) // if black brush is set and the mouse is clicked
        {
            // Cast ray from camera to mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(Ray, out hit))
            {
                // Create an instance of black brush slightly above the surface
                var newBrush = Instantiate(BlackBrush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                newBrush.transform.localScale = Vector3.one * BrushSize;


            }

        }

        if (redBrush == true && Input.GetMouseButton(0)) // if red brush is set and the mouse is clicked
        {
            // Cast ray from camera to mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(Ray, out hit))
            {
                // Create an instance of red brush slightly above the surface
                var newBrush = Instantiate(RedBrush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                newBrush.transform.localScale = Vector3.one * BrushSize;


            }

        }

        if (greenBrush == true && Input.GetMouseButton(0)) // if green brush is set and the mouse is clicked
        {
            // Cast ray from camera to mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(Ray, out hit))
            {
                // Create an instance of green brush slightly above the surface
                var newBrush = Instantiate(GreenBrush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                newBrush.transform.localScale = Vector3.one * BrushSize;


            }

        }

        if (blueBrush == true && Input.GetMouseButton(0)) // if blue brush is set and the mouse is clicked
        {
            // Cast ray from camera to mouse position
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(Ray, out hit))
            {
                // Create an instance of blue brush slightly above the surface
                var newBrush = Instantiate(BlueBrush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                newBrush.transform.localScale = Vector3.one * BrushSize;


            }

        }

    }

    // Make brush size small
    public void BrushSizeSmall()
    {

        BrushSize = 0.04f;

    }

    // Make brush size medium
    public void BrushSizeMedium()
    {

        BrushSize = 0.06f;

    }

    // Make brush size large
    public void BrushSizeLarge()
    {

        BrushSize = 0.09f;

    }

    public void setBrushWhite()
    {
        whiteBrush = true;
        blackBrush = false;
        redBrush = false;
        greenBrush = false;
        blueBrush = false;
    }

    public void setBrushBlack()
    {
        whiteBrush = false;
        blackBrush = true;
        redBrush = false;
        greenBrush = false;
        blueBrush = false;
    }

    public void setBrushRed()
    {
        whiteBrush = false;
        blackBrush = false;
        redBrush = true;
        greenBrush = false;
        blueBrush = false;
    }

    public void setBrushGreen()
    {
        whiteBrush = false;
        blackBrush = false;
        redBrush = false;
        greenBrush = true;
        blueBrush = false;
    }

    public void setBrushBlue()
    {
        whiteBrush = false;
        blackBrush = false;
        redBrush = false;
        greenBrush = false;
        blueBrush = true;
    }

    //clear drawing
    public void clearDrawing()
    {

        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("brush"); // find objects with the "brush" tag
        foreach(GameObject obj in allObjects) // for each of the tagged objects
        {
            Destroy(obj); // delete object
        }

    }


    // Save drawing method
    public void Save()
    {

        StartCoroutine(CoSave()); // begin save coroutine

    }

    private IEnumerator CoSave()
    {
        yield return new WaitForEndOfFrame();

        //show save location in debug log
        Debug.Log(Application.dataPath + "/Saved_Drawing.png");

        //Set which render texture to be used
        RenderTexture.active = DRTexture;

        //convert to texture3d at the same size as the render texture
        var texture2D = new Texture2D(DRTexture.width, DRTexture.height);

        //read pixels of render texture and determine area
        texture2D.ReadPixels(new Rect(0, 0, DRTexture.width, DRTexture.height), 0, 0);
        texture2D.Apply();

        //encode texture2D to PNG
        var data = texture2D.EncodeToPNG();

        //write to file in application path and set filename
        File.WriteAllBytes(Application.dataPath + "/Saved_Drawing.png", data);
        AssetDatabase.Refresh(); // Refresh assets folder

        Time.timeScale = 1; // unpause the game
        TextureEditor.SetActive(false); // set texture editor container to inactive
        Overworld.SetActive(true); // set overworld container to active
    }
}
