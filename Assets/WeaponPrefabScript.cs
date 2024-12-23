using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WeaponPrefabScript : MonoBehaviour
{

    // Start is called before the first frame update
    private float despawnTimer = 0, timeToDespawn = 5;

    private float blinkTimer = 0, orgTimeToBlink = 0.5f, timeToBlink, startBlinkingFactor = 0.7f;

    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    private float sinFactor = 0.5f, sinSpeed = 5f;

    public Pickup weaponType;

    private SpriteRenderer sprite;

    void Start()
    {
        sprites.Add("FryingPan", Resources.Load<Sprite>("WeaponSprites/fryingPanSprite"));
        sprites.Add("RollingPin", Resources.Load<Sprite>("WeaponSprites/rollingPinSprite"));

        timeToBlink = orgTimeToBlink;
        sprite = GetComponent<SpriteRenderer>();

        int random = UnityEngine.Random.Range(0, 2);
        if (random == 0)
        {
            weaponType = Pickup.FryingPan;
        }
        else 
        {
            weaponType = Pickup.RollingPin;
        }

        sprite.sprite = sprites[weaponType.ToString("g")];
    }

    public string getWeaponTypeString()
    {
        return weaponType.ToString("g");
    }

    public void RemoveMe()
    {
        //Allows for some animation and stuff if we want
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3((float)Math.Sin(despawnTimer * sinSpeed) * sinFactor + 1, (float)Math.Sin(despawnTimer * sinSpeed) * sinFactor + 1, 0);

        despawnTimer += Time.deltaTime;
        blinkTimer += Time.deltaTime;
        if (despawnTimer > timeToDespawn)
        {
            RemoveMe();
            despawnTimer = 0;
        }

        if (blinkTimer > timeToBlink && despawnTimer > timeToDespawn * startBlinkingFactor)
        {
            sprite.enabled = !sprite.enabled;
            blinkTimer = 0;
            timeToBlink = orgTimeToBlink * (float)Math.Pow(despawnTimer / (timeToDespawn), 3);
        }

    }
}
