using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class QTE : MonoBehaviour
{
    public GameObject Button;
    public GameObject QTEText;
    private int QTEGen;
    private int WaitingForKey;
    public static int CorrectKey;
    private int CountingDown;
    private float Randomtime = 6f;
    private Sprite sprite_blue;
    private Sprite sprite_red;
    private Sprite sprite_green;
    private Image buttonimg;
    void Start()
    {
        buttonimg = Button.GetComponent<Image>() as Image;
        sprite_blue = Resources.Load("button",typeof(Sprite)) as Sprite;
        sprite_red = Resources.Load("button_red",typeof(Sprite)) as Sprite;
        sprite_green = Resources.Load("button_green",typeof(Sprite)) as Sprite;
        Button.SetActive(false);
        QTEText.SetActive(false);
    }
    public int GetCorrectKey(){
        return CorrectKey;
    }
    void Update(){
        Randomtime -= Time.deltaTime;
        if (Randomtime <= 0){
            Randomtime = UnityEngine.Random.Range(1,3);
            if (WaitingForKey == 0){
                QTEGen = UnityEngine.Random.Range(1,4);
                //Debug.Log(QTEGen);
                buttonimg.sprite = sprite_blue;
                Button.SetActive(true);
                QTEText.SetActive(true);
                CountingDown = 1;
                StartCoroutine(CountDown());
                if (QTEGen == 1){
                    WaitingForKey = 1;
                    QTEText.GetComponent<Text>().text = "[J]";
                }
                if (QTEGen == 2){
                    WaitingForKey = 1;
                    QTEText.GetComponent<Text>().text = "[K]";
                }
                if (QTEGen == 3){
                    WaitingForKey = 1;
                    QTEText.GetComponent<Text>().text = "[L]";
                }
            }
        }
        
        if (QTEGen == 1) {
            if (Input.anyKeyDown){
                if (Input.GetKeyDown("j")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")){

                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2) {
            if (Input.anyKeyDown){
                if (Input.GetKeyDown("k")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")){
                    
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 3) {
            if (Input.anyKeyDown){
                if (Input.GetKeyDown("l")){
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")){
                    
                }
                else{
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        
    }
    IEnumerator KeyPressing(){
        QTEGen = 4;
        if (CorrectKey == 1){
            CountingDown = 2;
            buttonimg.sprite = sprite_green;
            yield return new WaitForSeconds (1.5f);
            CorrectKey = 0;
            QTEText.GetComponent<Text>().text = "";
            Button.SetActive(false);
            QTEText.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
        if (CorrectKey == 2){
            CountingDown = 2;
            buttonimg.sprite = sprite_red;
            yield return new WaitForSeconds (1.5f);
            CorrectKey = 0;
            QTEText.GetComponent<Text>().text = "";
            Button.SetActive(false);
            QTEText.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
    IEnumerator CountDown(){
        yield return new WaitForSeconds (3.5f);
        if (CountingDown == 1){
            QTEGen = 4;
            CountingDown = 2; 
            buttonimg.sprite = sprite_red;
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            QTEText.GetComponent<Text>().text = "";
            Button.SetActive(false);
            QTEText.SetActive(false);
            yield return new WaitForSeconds(1.5f);
            WaitingForKey = 0;
            CountingDown = 1;
        }
    }
}