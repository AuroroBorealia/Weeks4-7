using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meow : MonoBehaviour
{

    //Where I got my cat meow sound effects: 
    //https://pixabay.com/users/u_6ekfl947a2-48694237/ - https://pixabay.com/sound-effects/cat-meow-297927/ 
    //https://pixabay.com/users/freesound_community-46691455/ - https://pixabay.com/sound-effects/cat-meow-81626/
    //https://pixabay.com/sound-effects/cat-meow-14536/
    //Where I got my PNGs: 
    //https://www.vecteezy.com/members/101078976245586861694 - https://www.vecteezy.com/png/48803704-cat-alpha-background
    //https://www.vecteezy.com/members/devendrasingh007 - https://www.vecteezy.com/png/20004432-grey-cat-lying-and-looking-up
    //https://www.vecteezy.com/members/em3asy - https://www.vecteezy.com/png/48470484-cute-fluffy-cat-with-blue-eyes 

    //setting up my variables
    public AudioClip greyMeow;
    public AudioClip fluffyMeow;
    public AudioClip bigMeow;

    //Animation curve variables
    public AnimationCurve curve;
    [Range(0, 1)]
    public float t;

    bool isSpinning = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //New vector 3 to make the euler angles spin and chcange based on the curve
        Vector3 spin = transform.eulerAngles;
        spin.z = curve.Evaluate(t);

        //If statement to make it so spin turns on when space is pressed
        if (Input.GetKey(KeyCode.Space))
        {
            isSpinning = true;
        }

        //Makes it so the spins happens
        if (isSpinning == true)
        {
            t += Time.deltaTime;

            transform.localEulerAngles = spin;

            //make the spin stop after a second
            if (t>1)
            {
                t = 0;
                spin.z = 0;
                transform.eulerAngles = spin;
                isSpinning = false;
            }
        }
    }
}
