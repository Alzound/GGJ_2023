using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    private int t;

    public int time, repeat, quit;
    public float y = .5f;
    public TextMeshProUGUI mainText;
    //public string[] dialogues;

    // Start is called before the first frame update
    void Start()
    {
        
        //mainText.text = dialogues[0];
    }

    // Update is called once per frame
    void Update()
    {
        mainText.ForceMeshUpdate();
        var textInfo = mainText.textInfo;

        //time = Time.deltaTime; 

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];
            //StartCoroutine(StartDelay());
            if (!charInfo.isVisible)
            {
                continue;
            }

            var vertexs = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            //J hace referencia a los vertices de cada letra.
            for (int j = 0; j < 4; j++)
            {
                var orig = vertexs[charInfo.vertexIndex + j];
                //Movimiento vertical, tipo ola.
                vertexs[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * y + orig.x * 0.01f) * 5f, 0);
                //Movimiento tipo bandera. 
                //vertexs[charInfo.vertexIndex + j] = orig + new Vector3(Mathf.Sin(Time.time * y + orig.x * 0.01f) * 5f, Mathf.Sin(Time.time * y + orig.x * 0.01f) * 5f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            mainText.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
