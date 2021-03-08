using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{
    /*[SerializedField]*/
    public float moveSpeed;
    public Rigidbody2D rb;
    public Text keyText;
    public Text endText;
    
    bool redRiddle = true;
    bool orangeRiddle = false;
    bool yellowRiddle = false;
    bool greenRiddle = false;
    bool homeRiddle = false;


    bool eggActive = false;
    bool carrotActive = false;
    bool watermelonActive = false;
    bool donutActive = false;
    //bool homeActive = false;

    Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementInput();
        rb.velocity = movement * moveSpeed;
    }

    void movementInput(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector3(mx, my).normalized;
    }

    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.name == "red_0" && redRiddle == true){
            keyText.text = "A BOX WITHOUT HINGES, LOCK OR KEY, \nYET A GOLDEN TREASURE LIES INSIDE ME. \nGO FIND IT FOR ME!";
            Debug.Log("touched red, bools redRiddle:" + redRiddle + " orangeRiddle: " + orangeRiddle);
            eggActive = true;
        } else if(other.gameObject.name == "egg1" && eggActive == true){
            keyText.text = "CORRECT, AN EGG! THANK YOU!\n\nSEEMS LIKE ORANGE (BOTTOM LEFT) NEEDS SOME HELP TOO.";
            Debug.Log("found egg");
            Destroy(other.gameObject);
            redRiddle = false;
            eggActive = false;
            orangeRiddle = true;
        } else if(other.gameObject.name == "orange_0" && orangeRiddle == true){
            keyText.text = "HELP ME FIND SOMETHING THAT IS \nORANGE AND SOUNDS LIKE PARROT!";
            Debug.Log("touched orange");
            carrotActive = true;
        } else if(other.gameObject.name == "carrot1" && carrotActive == true){
            keyText.text = "YES, A CARROT! JUST WHAT I NEEDED!\n\nTALK TO YELLOW (BOTTOM RIGHT) NEXT?";
            Debug.Log("found carrot");
            Destroy(other.gameObject);
            orangeRiddle = false;
            carrotActive = false;
            yellowRiddle = true;
        } else if(other.gameObject.name == "yellow_0" && yellowRiddle == true){
            keyText.text = "IT LOOKS GREEN, IT OPENS RED. \nWHAT YOU EAT IS RED BUT \nWHAT YOU SPIT OUT IS BLACK. \nWHAT AM I LOOKING FOR?";
            Debug.Log("touched yellow");
            watermelonActive = true;
        } else if(other.gameObject.name == "watermelon1" && watermelonActive == true){
            keyText.text = "YES, A SLICE OF WATERMLON! YUM!\n\nPLEASE HELP GREEN (TOP RIGHT) AND CALL IT A DAY!";
            Debug.Log("found watermelon");
            Destroy(other.gameObject);
            yellowRiddle = false;
            watermelonActive = false;
            greenRiddle = true;
        } else if(other.gameObject.name == "green_0" && greenRiddle == true){
            keyText.text = "WHAT I AM LOOKING FOR HAS NO\nBEGINNING, MIDDLE, OR END.";
            Debug.Log("touched green");
            donutActive = true;
        } else if(other.gameObject.name == "donut1" && donutActive == true){
            keyText.text = "INDEED, IT IS A DONUT!\n\nTHANK YOU SO MUCH FOR YOUR HELP! \nIT'S GETTING LATE... YOU SHOULD HEAD HOME NOW.";
            Debug.Log("found donut");
            Destroy(other.gameObject);
            greenRiddle = false;
            donutActive = false;
            homeRiddle = true;
        } else if(other.gameObject.name == "homeDoor" && homeRiddle == true){
            endText.text = "IT HAS BEEN A GOOD DAY.\nTHE END.";
            Debug.Log("returned home");
            Destroy(gameObject);
            homeRiddle = true;
        } 
    } 
}
