using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rigi;
    private Vector3 post;
    public float speed;
    public int point;
    public Text score;
    public GameObject win;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        post = new Vector3(moveHorizontal,0,moveVertical);
        rigi.AddForce(post*speed);
        score.text = "Score : " + point.ToString();
        if (point == 12)
        {
            win.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Collect")
        {
            point += 1;
            Destroy(other.gameObject);
        }
    }
}
