using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderConfigurator : MonoBehaviour
{
    public enum Materials{Wood, Metal};
    public Materials material;

    private SpriteRenderer SpriteRenderer;
    [ShowOnly] [SerializeField] private Sprite sprite;

    public bool isTop = false;

    void Update()
    {
        SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        string mat = material == Materials.Wood ? "Wood" : "Metal";
        string top = isTop ? "Top" : "";

        string fileName = mat + top;

        SpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Ladders/" + fileName);
    }

}
