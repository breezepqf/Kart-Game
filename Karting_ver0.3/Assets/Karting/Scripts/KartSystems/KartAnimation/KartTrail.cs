using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using KartGame.KartSystems;

public class KartTrail : MonoBehaviour
{
    // public ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
    // {
    //     MaxTime = 5
    // };
    public bool isCoolingDown { get; private set; }
    public float lastActivatedTimestamp { get; private set; }
    private TrailRenderer trail;
    private ArcadeKart kart;
    // private QTE qte;
    public UnityEvent onPowerupActivated;
    public UnityEvent onPowerupFinishCooldown;
    public float cooldown = 0.5f;
    
    // Use this for initialization
    void Start () {
        trail = GetComponent<TrailRenderer>();
        trail.enabled = false;
        GameObject kp = GameObject.Find("Tocus");
        kart = kp.GetComponent<ArcadeKart>();
        // GameObject qtem = GameObject.Find("QTEManager");
        // qte = qtem.GetComponent<QTE>();
        lastActivatedTimestamp = -9999f;
        // boostStats.modifiers.TopSpeed = 10;
        // boostStats.modifiers.Acceleration = 2;
        isCoolingDown = false;
    }
    
    // Update is called once per frame
    void Update () {
        // if (Input.GetKeyDown(KeyCode.Space)){
        if (isCoolingDown) {
            if ((Time.time - lastActivatedTimestamp) > cooldown) {
                    //finished cooldown!
                isCoolingDown = false;
                onPowerupFinishCooldown.Invoke();
                trail.enabled = false;
                // Debug.Log("finish");
                // Debug.Log(trail.enabled);
            }
        }
        else if (QTE.CorrectKey == 1)
        { 
            lastActivatedTimestamp = Time.time;
            ArcadeKart.StatPowerup boostStats = new ArcadeKart.StatPowerup
            {
                MaxTime = 0.5f
            };
            // Debug.Log(QTE.CorrectKey);
            Debug.Log(lastActivatedTimestamp);
            boostStats.modifiers.TopSpeed = 2f;
            boostStats.modifiers.Acceleration = 2f;
            kart.AddPowerup(boostStats);
            onPowerupActivated.Invoke();
            isCoolingDown = true;
            trail.enabled = true;
        }
        
        // else if (Input.GetKeyUp(KeyCode.Space)){
        //     trail.enabled = false;
        // }
    }

}
