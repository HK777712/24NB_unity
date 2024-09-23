using UnityEngine;
using ROS2;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

using System.Threading.Tasks;
using UnityMainThreadDispatcher;

//using rosImage = sensor_msgs.msg.Image;
using rosImage = sensor_msgs.msg.CompressedImage;

public class Tx2RTV2 : MonoBehaviour
{
    public RenderTexture targetRenderer;
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private Texture2D tex;
    private ISubscription<rosImage> image_sub;
    private byte[] imageData;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out ros2Unity);
        //targetRenderer = new RenderTexture(640,480,0);
        tex = new Texture2D(640,480, TextureFormat.RGB24, false);
        StartCoroutine(UpdateTextureAsync());
    }

    // Update is called once per frame
    void Update()
    {
        if(ros2Unity.Ok())
        {
            if(ros2Node == null){
                ros2Node = ros2Unity.CreateNode("RendererImageSubInUnity");
                Debug.Log("Unity listener heard: [rosOK]");
                image_sub = ros2Node.CreateSubscription<rosImage>("/image_raw/compressed",Callback);
            }
            
        }
        
    }
    void Callback(rosImage compressedImage){
        imageData = compressedImage.Data;
    }
    IEnumerator UpdateTextureAsync(){
        while(true){
            yield return new WaitForFixedUpdate();
            //tex.LoadRawTextureData(imageData);
            tex.LoadImage(imageData);
            //Debug.Log("Unity listener heard: [taskOK]");
            tex.Apply();
            //Debug.Log("Unity listener heard: [ThreadOK]");
            Graphics.Blit(tex,targetRenderer);
        }
        //yield return null;
    }
    /*
    private void RenderTexture(byte[] data){
        Debug.Log("Unity listener heard: [1]");
        tex.LoadRawTextureData(data);
        Debug.Log("Unity listener heard: [2]");
        targetRenderer.material.mainTexture = tex;
        Debug.Log("Unity listener heard: [3]");
        tex.Apply();
        Debug.Log("Unity listener heard: [4]");
    }
    */
}


