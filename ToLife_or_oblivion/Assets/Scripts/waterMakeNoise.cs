using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterMakeNoise : MonoBehaviour {

    public float power = 3;
    public float scale = 1;
    public float timeScale = 1;

    private float xOffset;
    private float yOffset;
    private MeshFilter mf;

	// Use this for initialization
	void Start () {
        mf = GetComponent<MeshFilter>();
        makeNoise();
	}

	private void Update()
	{
        makeNoise();
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;

	}

	void makeNoise() {
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++) {
            vertices[i].y = calculateHeight(vertices[i].x, vertices[i].z) * power;
        }
        mf.mesh.vertices = vertices;
    }

    float calculateHeight(float x, float y) {

        float coordX = x * scale + xOffset;
        float coordY = y * scale + yOffset;

        return Mathf.PerlinNoise(coordX,coordY);
    }
}
