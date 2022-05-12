using System.Collections;
using UnityEngine;

public class LineAnimation : MonoBehaviour
{
    [SerializeField] private Texture[] textures;
    [SerializeField] private Material material;

    [SerializeField] private float delay = 0.2f;

    private IEnumerator Start()
    {
        while (true)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                material.SetTexture("_MainTex", textures[i]);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
