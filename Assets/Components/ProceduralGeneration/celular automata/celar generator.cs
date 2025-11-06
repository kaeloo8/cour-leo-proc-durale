using Components.ProceduralGeneration;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using VTools.Grid;
using VTools.ScriptableObjectDatabase;
using VTools.Grid;

namespace VTools.RandomService
{
    [CreateAssetMenu(menuName = "Procedural Generation Method/celular automata")]
    public class celargenerator : ProceduralGenerationMethod
    {
        [SerializeField] private int _density = 50;
        [SerializeField] private int _plus_de_x_to_ground = 4;
        [SerializeField] private int _moins_de_x_to_water = 2;
        [SerializeField] private int _to_sand = 7;
        protected override async UniTask ApplyGeneration(CancellationToken cancellationToken)
        {
            //cancellationToken.ThrowIfCancellationRequested();

            Nois_Generate();

            for (int i = 0; i < _maxSteps; i++)
            {
                Affinage();
                await UniTask.Delay(GridGenerator.StepDelay, cancellationToken: cancellationToken);
            }

        }

        private void Nois_Generate()
        {
            for (int x = 0; x < Grid.Width; x++)
            {
                for (int y = 0; y < Grid.Lenght; y++)
                {
                    if (!Grid.TryGetCellByCoordinates(x, y, out var cell))
                        continue;
                    float chance = (float)_density / 100f;
                    bool ground = RandomService.Chance(chance);
                    if (ground)
                        AddTileToCell(cell, GRASS_TILE_NAME, true);
                    else
                        AddTileToCell(cell, WATER_TILE_NAME, true);

                }
            }
        }

        public void Affinage()
        {
            VTools.Grid.Grid temp_grid = Grid;

            for (int x = 0; x < temp_grid.Width; x++)
            {
                for (int y = 0; y < temp_grid.Lenght; y++)
                {
                    int ground_count = 0;

                    for (int offsetX = -1; offsetX <= 1; offsetX++)
                    {
                        for (int offsetY = -1; offsetY <= 1; offsetY++)
                        {
                            if (offsetX == 0 && offsetY == 0)
                                continue;

                            int posX = x + offsetX;
                            int posY = y + offsetY;

                            if (!Grid.TryGetCellByCoordinates(posX, posY, out var verif_cell))
                                continue;

                            if (verif_cell.GridObject.Template.Name == GRASS_TILE_NAME || verif_cell.GridObject.Template.Name == SAND_TILE_NAME)
                                ground_count++;
                        }
                    }

                    if (Grid.TryGetCellByCoordinates(x, y, out var currentCell))
                    {
                        if (ground_count > _plus_de_x_to_ground)
                            AddTileToCell(currentCell, GRASS_TILE_NAME, true);
                        else if (ground_count < _moins_de_x_to_water)
                            AddTileToCell(currentCell, WATER_TILE_NAME, true);

                        if (currentCell.GridObject.Template.name == GRASS_TILE_NAME && ground_count < _to_sand && ground_count >= _moins_de_x_to_water)
                            AddTileToCell(currentCell, SAND_TILE_NAME, true);
                        else if (currentCell.GridObject.Template.name == GRASS_TILE_NAME || currentCell.GridObject.Template.Name == SAND_TILE_NAME)
                            AddTileToCell(currentCell, GRASS_TILE_NAME, true);

                    }
                }
            }
        }

    }
}
