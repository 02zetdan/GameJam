using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefabScript : MonoBehaviour
{
    public enum WeaponType
    {
        fryingPan,
        rollingPin
    }
    // Start is called before the first frame update
    private float despawnTimer = 0, timeToDespawn = 5;

    private float blinkTimer = 0, orgTimeToBlink = 0.5f, timeToBlink, startBlinkingFactor = 0.7f;

    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    private float sinFactor = 0.5f, sinSpeed = 5f;

    public WeaponType weaponType;

    private SpriteRenderer sprite;

    void Start()
    {
        sprites.Add("fryingPan", Resources.Load<Sprite>("WeaponSprites/rollingPinSprite"));
        sprites.Add("rollingPin", Resources.Load<Sprite>("WeaponSprites/fryingPanSprite"));

        timeToBlink = orgTimeToBlink;
        sprite = GetComponent<SpriteRenderer>();

        Array values = Enum.GetValues(typeof(WeaponType));
        System.Random random = new System.Random();
        weaponType = (WeaponType)values.GetValue(random.Next(values.Length));

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
