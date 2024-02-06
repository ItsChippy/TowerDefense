using System;
using System.Collections.Generic;
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
        List<Vector2> enemyPathTexturePositions = new();
        Texture2D enemyPathTexture;
        public EnemyPath()
        {
            BuildMap();
            enemyPathTexture = Globals.Content.Load<Texture2D>("path_panel");
            PutTexturesOnMap();
        }

        private void PutTexturesOnMap()
        {
            for (int i = 0; i < path.AntalPunkter; i++)
            {
                Vector2 tempPos = path.GetPos(i);
                tempPos.X = tempPos.X - enemyPathTexture.Width / 2;
                tempPos.Y = tempPos.Y - enemyPathTexture.Height / 2;
                enemyPathTexturePositions.Add(tempPos);
            }

        }

        private void BuildMap()
        {
            path = new(Globals.GraphicsDevice);
            path.Clean();

            path.AddPoint(new Vector2(-30, 100));
            path.AddPoint(new Vector2(0, 100));
            path.AddPoint(new Vector2(200, 100));
            path.AddPoint(new Vector2(400, 100));
            path.AddPoint(new Vector2(600, 100));
            path.AddPoint(new Vector2(700, 100));
            path.AddPoint(new Vector2(750, 300));
            path.AddPoint(new Vector2(350, 300));
            path.AddPoint(new Vector2(100, 300));
            path.AddPoint(new Vector2(100, 350));
            path.AddPoint(new Vector2(400, 450));
            path.AddPoint(new Vector2(380, 610));
        }

        public void Draw()
        {
            path.Draw(Globals.SpriteBatch);
            path.DrawPoints(Globals.SpriteBatch);
            for (int i = 0; i < enemyPathTexturePositions.Count; i++) 
            {
                Globals.SpriteBatch.Draw(enemyPathTexture, enemyPathTexturePositions[i], Color.White);
            }
        }
    }
}
