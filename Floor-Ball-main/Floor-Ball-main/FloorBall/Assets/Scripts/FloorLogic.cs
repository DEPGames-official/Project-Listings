using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Timers;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using Random = System.Random;

public class FloorLogic : MonoBehaviour
{
    public int colourTilesToKeep;
    void Awake()
    {
        colourTilesToKeep = chooseColourTiles();
        changeTexture();

        
    }

    public float timerToSet;
    private void Start()
    {

        Thread.Sleep(1000);
        timeRemaining = timerToSet;
        timerRunning = true;
        
    }

    public bool timerRunning = false;
    public float timeRemaining;
    
    public string removeColour;
    public bool updateInfoScreen = false;
    private void Update()
    {
        if (updateInfoScreen == true)
        {
            switch (colourTilesToKeep)
            {
                case 0:
                    removeColour = "Black";
                    break;

                case 1:
                    removeColour = "Blue";
                    break;

                case 2:
                   removeColour = "Green";
                    break;

                case 3:
                    removeColour = "Orange";
                    break;

                case 4:
                    removeColour = "Purple";
                    break;

                case 5:
                   removeColour = "Red";
                    break;

                /*default:
                    colourTilesToRemove = chooseColourTiles();
                    break;*/
            }


            updateInfoScreen = false;
        }
       

        if (timerRunning == true)
        {
            if (timeRemaining > 0)
            {
                updateInfoScreen = true;
                timeRemaining -= Time.deltaTime;
                infoScreen.text = $"The Colour Is:{removeColour} \n" +
                    $"Time Left: {Mathf.FloorToInt(timeRemaining +1)}";


            }
            else if(timeRemaining < 0 || timeRemaining == 0)
            {
                

                collapseWrongTiles(colourTilesToKeep);
                timeRemaining = 0;
                timerRunning = false;
                print("Time Is Up");
            }
        }
        
        //collapseWrongTiles();
    }

    public int chooseColourTiles()
    {
        Random randomColour = new Random();
        int Range = randomColour.Next(0, 5);

        
        return Range;
    }


    public Material[] texture;

    public int objectValue;
    public GameObject[] gameobject;

    public MeshRenderer mr;

    List<string> tilesColour = new List<string>();
    public void changeTexture()
    {
        gameobject = GameObject.FindGameObjectsWithTag("FloorPiece");
        

        foreach (GameObject tiles in gameobject)
        {

            mr = gameobject[objectValue].GetComponent<MeshRenderer>();

            Random randomFloor = new Random();
            int Range = randomFloor.Next(0, texture.Length);


            switch (Range)
            {
                case 0:
                    mr.material = texture[0];
                    mr.name = "Colour0";
                    break;

                case 1: 
                    mr.material = texture[1];
                    mr.name = "Colour1";
                    break;

                case 2:
                    mr.material = texture[2];
                    mr.name = "Colour2";
                    break;

                case 3: 
                    mr.material = texture[3];
                    mr.name = "Colour3";
                    break;

                case 4:
                    mr.material = texture[4];
                    mr.name = "Colour4";
                    break;

                case 5:
                    mr.material = texture[5];
                    mr.name = "Colour5";
                    break;

                default:
                    changeTexture();
                    break;
            }
            
            tilesColour.Add(mr.name);

            objectValue++;
        }
    }

    public TextMeshProUGUI infoScreen;

    public void collapseWrongTiles(int Range)
    {
        

       

        foreach (GameObject tiles in gameobject)
        {
            switch (Range)
            {
                case 0:
                    if (tiles.name != "Colour0")
                    {

                        tiles.SetActive(false);
                    }
                    break;

                case 1:
                    if (tiles.name != "Colour1")
                    {
                        tiles.SetActive(false);
                    }
                    break;

                case 2:
                    if (tiles.name != "Colour2")
                    {
                        tiles.SetActive(false);
                    }
                    break;

                case 3:
                    if (tiles.name != "Colour3")
                    {
                        tiles.SetActive(false);
                    }
                    break;

                case 4:
                    if (tiles.name != "Colour4")
                    {
                        tiles.SetActive(false);
                    }
                    break;

                case 5:
                    if (tiles.name != "Colour5")
                    {
                        tiles.SetActive(false);
                    }
                    break;

            }
        }

    }

    

    










}