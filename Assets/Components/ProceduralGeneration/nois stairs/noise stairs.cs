using Components.ProceduralGeneration;
using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

namespace VTools.RandomService
{
    [CreateAssetMenu(menuName = "Procedural Generation Method/nois generator 3d escalier")]
    public class noisestairs : ProceduralGenerationMethod
    {
        [Header("map param")]
        [SerializeField] int _ecart_des_marche = 1;
        [SerializeField] int _marche_sand = 1;
        [SerializeField] int _marche_grass = 1;
        [SerializeField] int _marche_Rock = 1;
        [SerializeField] int _marche_snow = 1;
        [SerializeField] public Gradient _gradient = new();
        [SerializeField][Range(0, 1)] private readonly float _niveau_water = 0.2f;
        [SerializeField][Range(0, 1)] private readonly float _niveau_sand = 0.4f;
        [SerializeField][Range(0, 1)] private readonly float _niveau_grass = 0.6f;
        [SerializeField][Range(0, 1)] private readonly float _niveau_rock = 0.8f;
        [SerializeField][Range(0, 1)] private readonly float _niveau_snow = 1.0f;


        [Header("general")]
        float[,] noiseData;
        [SerializeField] FastNoiseLite.NoiseType _nois_type = FastNoiseLite.NoiseType.OpenSimplex2;
        [SerializeField] FastNoiseLite.RotationType3D _rota_3d = FastNoiseLite.RotationType3D.None;
        [SerializeField][Range(0, 100)] int _speed = 1;
        [SerializeField][Range(0, 2)] float _frequency = 0.025f;

        [Header("fractale")]
        [SerializeField] FastNoiseLite.FractalType _fractal_type = FastNoiseLite.FractalType.None;
        [SerializeField] int _octave = 3;
        [SerializeField] float _lacunarity = 2.0f;
        [SerializeField] float _gain = 0.5f;
        [SerializeField] float _weigther = 0.0f;
        [SerializeField] float _ping_pong = 2.0f;

        [Header("cellular")]
        [SerializeField] FastNoiseLite.CellularDistanceFunction _distance_function = FastNoiseLite.CellularDistanceFunction.Euclidean;
        [SerializeField] FastNoiseLite.CellularReturnType _return_type = FastNoiseLite.CellularReturnType.Distance;
        [SerializeField] float _jiter = 1.0f;


        Vertex[] _vertices_list;

        protected override async UniTask ApplyGeneration(CancellationToken cancellationToken)
        {

            GenerateNoise();

            Reorganise();

            GenerateMesh();
        }
        private void GenerateNoise()
        {
            FastNoiseLite noise = new FastNoiseLite();
            noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);

            noise.SetNoiseType(_nois_type);
            if (_nois_type != FastNoiseLite.NoiseType.OpenSimplex2)
                noise.SetRotationType3D(_rota_3d);
            noise.SetSeed(_speed);
            noise.SetFrequency(_frequency);


            if (_fractal_type != FastNoiseLite.FractalType.None)
            {
                noise.SetFractalOctaves(_octave);
                noise.SetFractalLacunarity(_lacunarity);
                noise.SetFractalGain(_gain);
                noise.SetFractalWeightedStrength(_weigther);
                if (_fractal_type == FastNoiseLite.FractalType.PingPong)
                    noise.SetFractalPingPongStrength(_ping_pong);
            }

            if (_nois_type == FastNoiseLite.NoiseType.Cellular)
            {
                noise.SetCellularDistanceFunction(_distance_function);
                noise.SetCellularReturnType(_return_type);
                noise.SetCellularJitter(_jiter);
            }

            noiseData = new float[Grid.Width, Grid.Lenght];

            for (int x = 0; x < Grid.Width; x++)
            {
                for (int y = 0; y < Grid.Lenght; y++)
                {
                    noiseData[x, y] = (noise.GetNoise(x, y) + 1) / 2.0f; // pour obtenir entre 0 et 1 et pas entre -1 et 1
                }
            }
        }

        private void Reorganise()
        {
            for (int x = 0; x < Grid.Width; x++)
            {
                for (int y = 0; y < Grid.Lenght; y++)
                {
                    float val = noiseData[x, y];
                    float newVal = val;

                    switch (true)
                    {
                        case bool _ when val < _niveau_water:
                            newVal = _niveau_water;
                            break;

                        case bool _ when val < _niveau_sand:
                            {
                                float start = _niveau_water;
                                float end = _niveau_sand;
                                float range = end - start;
                                float step = range / _marche_sand;
                                float pos = val - start;
                                int marcheIndex = Mathf.FloorToInt(pos / step);
                                newVal = start + marcheIndex * step;
                                break;
                            }

                        case bool _ when val < _niveau_grass:
                            {
                                float start = _niveau_sand;
                                float end = _niveau_grass;
                                float range = end - start;
                                float step = range / _marche_grass;
                                float pos = val - start;
                                int marcheIndex = Mathf.FloorToInt(pos / step);
                                newVal = start + marcheIndex * step;
                                break;
                            }

                        case bool _ when val < _niveau_rock:
                            {
                                float start = _niveau_grass;
                                float end = _niveau_rock;
                                float range = end - start;
                                float step = range / _marche_Rock;
                                float pos = val - start;
                                int marcheIndex = Mathf.FloorToInt(pos / step);
                                newVal = start + marcheIndex * step;
                                break;
                            }

                        default:
                            {
                                float start = _niveau_rock;
                                float end = _niveau_snow;
                                float range = end - start;
                                float step = range / _marche_snow;
                                float pos = val - start;
                                int marcheIndex = Mathf.FloorToInt(pos / step);
                                newVal = start + marcheIndex * step;
                                break;
                            }
                    }

                    noiseData[x, y] = newVal;
                }
            }
        }

        private void GenerateMesh()
        {
            int width = Grid.Width - 1; 
            int height = Grid.Lenght - 1;

            _vertices_list = new Vertex[width * height * 4];
            Color[] colors = new Color[_vertices_list.Length];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 4;

                    UnityEngine.Vector3 v0 = new UnityEngine.Vector3(x, noiseData[x, y] * _ecart_des_marche, y);
                    UnityEngine.Vector3 v1 = new UnityEngine.Vector3(x + 1, noiseData[x + 1, y]* _ecart_des_marche, y);
                    UnityEngine.Vector3 v2 = new UnityEngine.Vector3(x, noiseData[x, y + 1]* _ecart_des_marche, y + 1);
                    UnityEngine.Vector3 v3 = new UnityEngine.Vector3(x + 1, noiseData[x + 1, y + 1] * _ecart_des_marche, y + 1);

                    _vertices_list[index] = new Vertex { position = v0 };
                    _vertices_list[index + 1] = new Vertex { position = v1 };
                    _vertices_list[index + 2] = new Vertex { position = v2 };
                    _vertices_list[index + 3] = new Vertex { position = v3 };

                    Color color = _gradient.Evaluate(noiseData[x,y]);
                    colors[index] = color;
                    colors[index + 1] = color;
                    colors[index + 2] = color;
                    colors[index + 3] = color;
                }
            }


            UnityEngine.Vector3[] vertices = new UnityEngine.Vector3[_vertices_list.Length];
            for (int i = 0; i < _vertices_list.Length; i++)
            {
                vertices[i] = _vertices_list[i].position;
            }

            int[] triangles = new int[width * height * 6];

            int t = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = (y * width + x) * 4;

                    triangles[t++] = index;
                    triangles[t++] = index + 2;
                    triangles[t++] = index + 1;

                    triangles[t++] = index + 1;
                    triangles[t++] = index + 2;
                    triangles[t++] = index + 3;
                }
            }
            Mesh mesh = new Mesh();
            for (int i = 0; i < _vertices_list.Length; i++)
                vertices[i] = _vertices_list[i].position;

            mesh.vertices = vertices;
            mesh.triangles = triangles.ToArray();
            mesh.colors = colors; // on ajoute la couleur par vertex
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            // objet dans la scène
            var go = new GameObject("GeneratedMesh");
            MeshFilter mf = go.AddComponent<MeshFilter>();
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            mf.mesh = mesh;
            mr.material.EnableKeyword("_VERTEX_COLOR");


            // nouveau matériau qui utilise la couleur des vertices
            Material mat = new Material(Shader.Find("Universal Render Pipeline/Particles/Unlit"));
            mat.SetFloat("_SurfaceType", 0); // opaque
            mat.SetFloat("_BlendMode", 0);
            mat.SetColor("_BaseColor", Color.white);
            mat.enableInstancing = true;
            mr.material = mat;

        }

    }
}