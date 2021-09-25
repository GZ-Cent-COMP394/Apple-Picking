using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TerrainType
{
    Plain =1,
    Hills=3,
    Mountainous=10
}

public class TerrainGenerator : MonoBehaviour
{

    public TerrainType terrainType;
    private int _depth = 20;
    // 
    private int _width = 256;
    // length
    private int _height = 256;

    private float _noiseScale;
    public int Width
    {
        get => _width;
        set => _width = value;
    }
    public int Height
    {
        get => _height;
        set => _height = value;
    }
    public int Depth
    {
        get => _depth;
        set => _depth = value;
    }
    public float NoiseScale
    {
        get => _noiseScale;
        set => _noiseScale = value;
    }

    private void Start()
    {
        NoiseScale = (float) terrainType;
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }
    

    //Procedual Generation of terrain
    private TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = Width + 1;

        terrainData.size = new Vector3(Width, Depth, Height);

        terrainData.SetHeights(0, 0, GenerateHeights());

        return terrainData;
    }

    private float[,] GenerateHeights()
    {
        float[,] height = new float[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                //Some Perlin Noise Value
                height[x, y] = CalculateHeight(x, y);
            }
        }
        return height;
    }

    // This method gives a heights array of Perlin Noise values
    float CalculateHeight(int x, int y)
    {
        float xCoord = (float) x / Width*NoiseScale;
        float yCoord = (float) y / Height* NoiseScale;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
