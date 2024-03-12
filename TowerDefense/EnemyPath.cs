using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spline;

namespace TowerDefense
{
    internal class EnemyPath
    {
        public SimplePath path { get; private set; }
        List<PathPanel> enemyPathPanels = new();

        public EnemyPath()
        {
            BuildMap();
            PutTexturesOnMap();
        }

        private void PutTexturesOnMap()
        {
            for (int i = 0; i < path.AntalPunkter; i++)
            {
                enemyPathPanels.Add(new PathPanel(path.GetPos(i)));
            }

        }

        private void BuildMap()
        {
            path = new(Globals.GraphicsDevice);
            path.Clean();

            //original path
            path.AddPoint(new Vector2(-30, 100));
            path.AddPoint(new Vector2(0, 100));
            path.AddPoint(new Vector2(200, 100));
            path.AddPoint(new Vector2(400, 100));
            path.AddPoint(new Vector2(600, 100));
            path.AddPoint(new Vector2(700, 100));
            path.AddPoint(new Vector2(725, 200));
            path.AddPoint(new Vector2(750, 300));
            path.AddPoint(new Vector2(550, 300));
            path.AddPoint(new Vector2(350, 300));
            path.AddPoint(new Vector2(225, 300));
            path.AddPoint(new Vector2(100, 300));
            path.AddPoint(new Vector2(100, 350));
            path.AddPoint(new Vector2(250, 400));
            path.AddPoint(new Vector2(400, 450));
            path.AddPoint(new Vector2(380, 610));
            path.AddPoint(new Vector2(380, 640));

            QuadruplePathPoints();
        }

        /// <summary>
        /// Quadruples the points of the path for smoother turns and more accurate path
        /// </summary>
        private void QuadruplePathPoints() 
        {
            List<Vector2> originalPath = new List<Vector2>();
            for (int i = 0; i < path.AntalPunkter; i++)
            {
                originalPath.Add(path.GetPos(i));
            }

            DoublePathPoints(originalPath);

            originalPath.Clear();
            for (int i = 0; i < path.AntalPunkter; i++)
            {
                originalPath.Add(path.GetPos(i));
            }

            DoublePathPoints(originalPath);
        }

        private void DoublePathPoints(List<Vector2> originalPath)
        {
            for (int i = 0; i < originalPath.Count - 1; i++)
            {
                Vector2 midPoint = (originalPath[i] + originalPath[i + 1]) / 2;               
                path.InsertPoint(midPoint, i * 2 + 1);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < path.AntalPunkter - 1; i++)
            {
                Vector2 direction = path.GetPos(i + 1) - path.GetPos(i);

                float rotationAngle = (float)Math.Atan2(direction.Y, direction.X);
                enemyPathPanels[i].Draw(rotationAngle);
            }
        }
    }
}
