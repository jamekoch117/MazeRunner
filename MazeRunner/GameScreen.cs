using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MazeRunner
{
    public partial class GameScreen : UserControl
    {
        // player control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        // shooting control keys
        Boolean wKeyDown, aKeyDown, sKeyDown, dKeyDown;

        // game values
        public static int level;

        // player object
        Player player;

        // player values
        public static int playerLives;
        public static int playerSpeed;

        // powerup values
        int powerPick;

        // lists
        List<Bullet> bullets = new List<Bullet>();
        List<Gremlin> gremlins = new List<Gremlin>();
        List<Powerup> powerups = new List<Powerup>();
        List<Wall> walls = new List<Wall>();

        // brushes
        SolidBrush lifeUpBrush = new SolidBrush(Color.Green);
        SolidBrush fasterBrush = new SolidBrush(Color.Red);

        // for random values
        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
            OnStart(); // call onstart method
        }

        public void OnStart()
        {
            // starting level
            level = 1;

            // set player life counter
            playerLives = 3;

            // set all button presses to false
            leftArrowDown = rightArrowDown = upArrowDown = downArrowDown = wKeyDown = aKeyDown = sKeyDown = dKeyDown = false;

            // setup starting player values and create player
            int playerWidth = 40;
            int playerHeight = 60;
            int playerX = playerWidth;
            int playerY = ((this.Height / 2) - (playerHeight / 2));
            playerSpeed = 5;
            player = new Player(playerX, playerY, playerWidth, playerHeight, playerSpeed, playerLives);

            LevelMaker();
        }

        public void LevelMaker()
        {
            // variables for block x and y values
            string wallX;
            string wallY;
            string wallWidth;
            string wallHeight;
            int intX;
            int intY;
            int intWidth;
            int intHeight;

            // create xml reader
            XmlTextReader reader = new XmlTextReader($"Resources/level{level}.xml");

            reader.ReadStartElement("level");

            //Grabs all the blocks for the current level and adds them to the list
            while (reader.Read())
            {
                reader.ReadToFollowing("x");
                wallX = reader.ReadString();

                reader.ReadToFollowing("y");
                wallY = reader.ReadString();

                reader.ReadToFollowing("width");
                wallWidth = reader.ReadString();

                reader.ReadToFollowing("height");
                wallHeight = reader.ReadString();

                if (wallX != "")
                {
                    intX = Convert.ToInt32(wallX);
                    intY = Convert.ToInt32(wallY);
                    intWidth = Convert.ToInt32(wallWidth);
                    intHeight = Convert.ToInt32(wallHeight);
                    Wall w = new Wall(intX, intY, intWidth, intHeight);
                    walls.Add(w);
                }
            }
            // close reader
            reader.Close();
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // player moving button presses
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                // shooting button presses
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                // player moving button releases
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                // shooting button releases
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //if (leftArrowDown && player.x > 0)
            //{

            //}

            // redraw the screen
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

