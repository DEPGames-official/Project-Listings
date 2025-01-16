using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System;

public class ColourRandomScript : ColourNameByCamera
{
    public int w;

    public int r;

    public int a;

    public int t = 0;

    public bool timer3Play;

    public float Timer3 = 3;

    public float backupTimer3;

    public TextMeshProUGUI numberText;

    public GameObject[] players;

    public Transform[] playersTransform;

    public int playerAmount;

    public bool range2SelectorBool = false;

    public bool callingTimer;

    public Text tileTypeText;

    public float setupTimer = 10f;

    public int p;

    public int g;

    public int m = 0;

    public int n = 0;

    public float Timer = 10;

    public float Timer2;

    public float backupTimer2;

    public float backupTimer;

    bool timerPlay;

    bool timerPlay2;

    public Texture[] texture; //= new Texture[6];

    public int textureNumber;

    //public int[] textures = new int[6];

    public int i = 0;

    public MeshRenderer mr;

    public int objectValue;

    public int objectValue2;

    public int objectValue3;

    public int objectValue4;

    public GameObject[] gameobject;

    public GameObject[] colourObject0;
    public GameObject[] colourObject1;
    public GameObject[] colourObject2;
    public GameObject[] colourObject3;
    public GameObject[] colourObject4;
    public GameObject[] colourObject5;

    //public GameObject colourObjectss;

    public GameObject[] tileObj;

    public Transform tr;

    public Transform tr2;

    int number;

    public int Range;

    public int Range2;

    public int tileNumbers;

    public Transform[] tileTransforms;

    //GameObject colourChangeTile;

    //GameObject go;

    //public Renderer rend;

    //public Rigidbody rb;

    //public Material material;

    Color[] Colours = new Color[7];

    List<GameObject> colourObjects = new List<GameObject>();

    void Awake()
    {
        backupTimer3 = Timer3;

        players = GameObject.FindGameObjectsWithTag("Player");



        backupTimer2 = Timer2;

        backupTimer = Timer;


        foreach (Texture textures in texture)
        {

            textureNumber++;
            //print(textureNumber);

        }
        changeTexture();




        //rend.GetComponent<Renderer>();
        //rb.GetComponent<Material>();



        /* Colours[1] = Color.red;
         Colours[2] = Color.magenta;
         Colours[3] = Color.grey;
         Colours[4] = Color.green;
         Colours[5] = Color.blue;
         Colours[6] = Color.black;*/




    }


    private void Start()
    {




    }

    public void changeTexture()
    {


        gameobject = GameObject.FindGameObjectsWithTag("colourChangeTile");

        // maxisnotahorRange2 = Random.Range(0, textureNumber);


        foreach (GameObject tiles in gameobject)
        {

            //Texture texture = gameobject[textureNumber].GetComponent<Texture2D>();    

            tr = gameobject[objectValue].GetComponent<Transform>();

            MeshRenderer mr = gameobject[objectValue].GetComponent<MeshRenderer>();

            Range = UnityEngine.Random.Range(0, textureNumber);


            //var myRange = texture[Range];

            //print(Range);

            //var colourRange = Random.Range(0, Colours.Length);
            //var myRandomNumber = Colours[colourRange];



            if (Range == 0)
            {

                mr.material.mainTexture = texture[0];

                tr.gameObject.tag = "Brown";





            }
            else if (Range == 1)
            {

                mr.material.mainTexture = texture[1];

                tr.gameObject.tag = "Red";



            }
            else if (Range == 2)
            {

                mr.material.mainTexture = texture[2];

                tr.gameObject.tag = "Blue";




            }
            else if (Range == 3)
            {

                mr.material.mainTexture = texture[3];

                tr.gameObject.tag = "Green";


            }
            else if (Range == 4)
            {
                mr.material.mainTexture = texture[4];

                tr.gameObject.tag = "Orange";


            }
            else if (Range == 5)
            {
                mr.material.mainTexture = texture[5];

                tr.gameObject.tag = "Purple";


            }
            else
            {
                changeTexture();
            }

            objectValue++;

            //objectValue %= 25;

        }











    }

    private void Update()
    {
        print(Range2);

        if (timer3Play == true)
        {
            timer3Change();
        }


        range2Selector();

        //levelChange();

        canvasEnable();

        TimerScript();



        //playerDieInDeathZone();

        //OnTriggerEnter(deathZone);
        //print(objectValue);

        //OnTriggerEnter(deathZone);







    }


    public void TimerScript()
    {
        //print(Timer);



        int timerInt = Convert.ToInt32(Timer);

        numberText.text = timerInt.ToString();

        if (Input.GetKeyDown(KeyCode.C))
        {
            callingTimer = true;
        }

        if (Timer > 0 && callingTimer == true)
        {
            timer3Play = false;



            timerPlay = true;

            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                callingTimer = false;
            }

        }
        else if (Timer <= 0)
        {

            m = 0;

            timerPlay = false;

            levelChange();

            floorBreak();

            r = 0;

            timer3Play = true;
        }






        //print(Timer);
    }//Timer

    public void floorBreak()
    {

        if (timerPlay == false)
        {
            while (m == 0)
            {

                if (Range2 == 0)
                {//Brown

                    colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);



                    foreach (GameObject colourObjecting in colourObjects)
                    {

                        //print("Brown");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();

                        //tr2.GetComponent<Transform>();

                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);



                        objectValue2++;




                    }


                    m++;

                }
                else if (Range2 == 1)
                {
                    colourObject0 = GameObject.FindGameObjectsWithTag("Brown");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);

                    foreach (GameObject colourObjecting in colourObjects)
                    {
                        //print("Red");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();

                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);



                        objectValue2++;







                    }

                    m++;


                }
                else if (Range2 == 2)
                {
                    colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Brown");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);

                    foreach (GameObject colourObjecting in colourObjects)
                    {
                        //print("Blue");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();


                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);

                        objectValue2++;










                    }

                    m++;


                }
                else if (Range2 == 3)
                {
                    colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Brown");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);

                    foreach (GameObject colourObjecting in colourObjects)
                    {
                        //print("Green");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();

                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);

                        objectValue2++;



                    }

                    m++;

                }
                else if (Range2 == 4)
                {
                    colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Brown");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);

                    foreach (GameObject colourObjecting in colourObjects)
                    {
                        //print("Orange");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();

                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);

                        objectValue2++;


                    }

                    m++;

                }
                else if (Range2 == 5)
                {
                    colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                    colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                    colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                    colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                    colourObject4 = GameObject.FindGameObjectsWithTag("Brown");

                    colourObjects.AddRange(colourObject0);
                    colourObjects.AddRange(colourObject1);
                    colourObjects.AddRange(colourObject2);
                    colourObjects.AddRange(colourObject3);
                    colourObjects.AddRange(colourObject4);

                    foreach (GameObject colourObjecting in colourObjects)
                    {
                        //print("Purple");

                        tr2 = colourObjects[objectValue2].GetComponent<Transform>();

                        tr2.position = new Vector3(tr2.position.x, -10, tr2.position.z);

                        objectValue2++;


                    }

                    m++;

                }


            }

        }



    }//Floor falls when time is done

    public void canvasEnable()
    {
        if (timerPlay == true)
        {
            //Timer2 = 3f;

            //Timer2 -= Time.deltaTime;
            if (mainCanvas.enabled == true && mainCanvasScaler.enabled == true)
            {
                if (Timer2 > 0)
                {
                    //Timer2 -= Time.deltaTime;

                    timerPlay2 = true;

                    Timer2 -= Time.deltaTime;

                }
                else if (Timer2 <= 0)
                {
                    timerPlay2 = false;

                    //Timer2 = backupTimer2;

                }

            }

        }
        else if (timerPlay == false)
        {
            Timer2 = backupTimer2;
        }

    }

    void range2Selector()
    {
        if (Timer2 <= 0)
        {
            while (n == 0)
            {
                if (Range2 == 0)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Brown";


                    }

                }
                else if (Range2 == 1)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Red";


                    }

                }
                else if (Range2 == 2)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Blue";


                    }

                }
                else if (Range2 == 3)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Green";


                    }

                }
                else if (Range2 == 4)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Orange";


                    }
                }
                else if (Range2 == 5)
                {
                    if (Timer2 <= 0)
                    {
                        tileTypeText.text = "Purple";

                    }
                }


                n++;
            }

        }

    }

    public void putTilesInPosition()
    {

        while (t == 0)
        {

            if (Range2 == 0)
            {//Brown

                colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);



                foreach (GameObject colourObjecting in colourObjects)
                {

                    //print("Brown");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //tr2.GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;



                    }



                }
                t++;


            }
            else if (Range2 == 1)
            {
                colourObject0 = GameObject.FindGameObjectsWithTag("Brown");
                colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);

                foreach (GameObject colourObjecting in colourObjects)
                {
                    //print("Red");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;



                    }








                }

                t++;


            }
            else if (Range2 == 2)
            {
                colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                colourObject1 = GameObject.FindGameObjectsWithTag("Brown");
                colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);

                foreach (GameObject colourObjecting in colourObjects)
                {
                    //print("Blue");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;




                    }








                }

                t++;


            }
            else if (Range2 == 3)
            {
                colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                colourObject2 = GameObject.FindGameObjectsWithTag("Brown");
                colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);

                foreach (GameObject colourObjecting in colourObjects)
                {
                    //print("Green");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;




                    }

                }

                t++;


            }
            else if (Range2 == 4)
            {
                colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                colourObject3 = GameObject.FindGameObjectsWithTag("Brown");
                colourObject4 = GameObject.FindGameObjectsWithTag("Purple");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);

                foreach (GameObject colourObjecting in colourObjects)
                {
                    //print("Orange");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;



                    }

                }

                t++;


            }
            else if (Range2 == 5)
            {
                colourObject0 = GameObject.FindGameObjectsWithTag("Red");
                colourObject1 = GameObject.FindGameObjectsWithTag("Blue");
                colourObject2 = GameObject.FindGameObjectsWithTag("Green");
                colourObject3 = GameObject.FindGameObjectsWithTag("Orange");
                colourObject4 = GameObject.FindGameObjectsWithTag("Brown");

                colourObjects.Clear();

                colourObjects.AddRange(colourObject0);
                colourObjects.AddRange(colourObject1);
                colourObjects.AddRange(colourObject2);
                colourObjects.AddRange(colourObject3);
                colourObjects.AddRange(colourObject4);

                foreach (GameObject colourObjecting in colourObjects)
                {
                    //print("Purple");

                    tr2 = colourObjects[objectValue3].GetComponent<Transform>();

                    //if (Input.GetKeyDown(KeyCode.B))
                    {
                        tr2.position = new Vector3(tr2.position.x, 0, tr2.position.z);

                        objectValue3++;


                    }

                }

                t++;


            }

            //levelChange();

            checktrPosition();
            callingTimer = true;
        }


    }

    public void timer3Change()
    {
        Timer3 -= Time.deltaTime;

        if (Timer3 <= 0)
        {
            objectValue2 = 0;
            objectValue3 = 0;

            timer3Play = false;

            Timer3 = backupTimer3;

            t = 0;

            putTilesInPosition();
        }
        else
        {
            timer3Play = true;
        }

    }

    public void levelChange()
    {

        if (timer3Play == false)
        {
            a = 0;
            while (a == 0)
            {

                backupTimer--;

                Timer = backupTimer;

                a++;
            }




        }
    }


    public void checktrPosition()
    {
        tr2 = colourObjects[objectValue4].GetComponent<Transform>();

        {
            while (r == 0)
            {
                foreach (GameObject gameObjects in colourObjects)
                {
                    objectValue4++;
                }

                if (tr2.position.y == 0)
                {
                    Range2 = UnityEngine.Random.Range(0, textureNumber);
                }

                r++;
            }
        }
    }
}