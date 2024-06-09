using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    public int coinCount;
    public Text pineappleText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pineappleText.text = "Pineapple Collected: " + coinCount.ToString();
    }
}
