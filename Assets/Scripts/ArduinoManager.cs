using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System.Linq;

public class ArduinoManager : MonoBehaviour
{
    [System.Serializable]
    public class Card
    {
        public string uuid;
        public Color color;
        public VideoClip clip;
    }

    public List<Card> cardList;
    public Image image;
    public VideoPlayer player;

    public SerialController serial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var msg = serial.ReadSerialMessage();
        if (string.IsNullOrEmpty(msg))
        {
            return;
        }

        Debug.Log(msg);


        var result = cardList.FirstOrDefault(x => x.uuid == msg.Trim());
        if (result == null)
        {
            return;
        }

        image.color = result.color;
        player.Stop();
        player.clip = result.clip;
        player.Play();
    }
}
