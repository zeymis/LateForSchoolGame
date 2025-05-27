using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 6;
    public float horizontalSpeed = 8;
    public float rightLimit = 4f;
    public float leftLimit = -4f;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;

    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            if(this.gameObject.transform.position.x > leftLimit){
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }

        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            if(this.gameObject.transform.position.x < rightLimit){
            transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)){
            if(isJumping == false){
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }

        if(isJumping == true){
            if(comingDown == false){
                transform.Translate(Vector3.up * Time.deltaTime * 8, Space.World);
            }

            if(comingDown == true){
                transform.Translate(Vector3.up * Time.deltaTime * -8, Space.World);
            }
        }
    }

    IEnumerator JumpSequence(){
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Running");
    }
}
