using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class ColourRandom : MonoBehaviour
{
    public Texture[] texture;

    public int textureNumber;

    public int[] textures = new int[6];

    public MeshRenderer mr;

    public int objectValue;

    public GameObject[] gameobject;

    int number;

    //GameObject colourChangeTile;

    //GameObject go;

    //public Renderer rend;

    //public Rigidbody rb;

    //public Material material;

    Color[] Colours = new Color[7];

    void Start()
    {
        

        

        changeTexture();

        //rend.GetComponent<Renderer>();
        //rb.GetComponent<Material>();



        /*Colours[1] = Color.red;
        Colours[2] = Color.magenta;
        Colours[3] = Color.grey;
        Colours[4] = Color.green;
        Colours[5] = Color.blue;
        Colours[6] = Color.black;*/


        foreach (Texture textures in texture)
        {
T           

        }



    }

    public void changeTexture()
    {


        gameobject = GameObject.FindGameObjectsWithTag("colourChangeTile");

  

        foreach (GameObject player in gameobject)
        {
            //Texture texture = gameobject[textureNumber].GetComponent<Texture2D>();    

            MeshRenderer mr = gameobject[objectValue].GetComponent<MeshRenderer>();

            var colourRange = Random.Range(0, Colours.Length);
            var myRandomNumber = Colours[colourRange];

            

            if (colourRange == 1)
            {
                

                
            }
            else if (colourRange == 2)
            {
                

                
            }
            else if (colourRange == 3)
            {
                

                
            }
            else if (colourRange == 4)
            {
              

                
            }
            else if (colourRange == 5)
            {
                

                
            }
            else if (colourRange == 6)
            {
                

                
            }
            else
            {
                changeTexture();
            }


            objectValue++;



        }


    }


    private void Update()
    {







    }


    



    

    
}