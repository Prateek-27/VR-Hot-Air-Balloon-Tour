using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport_to_basket : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerCameraGameObject;
    public GameObject bottom;
    public Color activeColor;
    public Color inactiveColor;
    public bool colorChanging = false;
    private MeshRenderer myRenderer;
    public float myTimer = 0f;
    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
        myRenderer.material.color = inactiveColor;
        bottom = GameObject.Find("/Hot Air Balloon/Basket/bottom");
        playerCameraGameObject = GameObject.Find("/Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChanging)
        {
            myRenderer.material.color = Color.Lerp(myRenderer.material.color, activeColor, Time.deltaTime / 5f);
            myTimer += Time.deltaTime;

            if (myTimer >= 5f)
            {
                //Teleport player to location of TeleportCube
                Vector3 TeleportPose = new Vector3((bottom.transform.position.x), playerCameraGameObject.transform.position.y, bottom.transform.position.z);
                playerCameraGameObject.transform.position = TeleportPose;
            }
        }
    }

    public void OnPointerEnter()
    {
        GazeAt(true);
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        GazeAt(false);
    }

    public void GazeAt(bool gazing)
    {
        if (gazing)
        {
            colorChanging = true;
            //myRenderer.material.color = activeColor;
        }
        else
        {
            myTimer = 0f;
            colorChanging = false;
            myRenderer.material.color = inactiveColor;
            //myRenderer.material.color = inactiveColor;
        }
    }
}
