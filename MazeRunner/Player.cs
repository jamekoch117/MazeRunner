using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Player
    {
        public int x, y, width, height, speed, health;
        public string direction;

        public Player(int _x, int _y, int _width, int _height, int _speed, int _health)
        {
            x = _x;
            y = _y;
            width = _width;
            height = _height;
            speed = _speed;
            health = _health;
        }

        public void Move(string direction, int speed)
        {
            // player moving along x axis
            if (direction == "left")
            {
                x -= speed;
            }
            if (direction == "right")
            {
                x += speed;
            }

            // player moving along y axis
            if (direction == "up")
            {
                y -= speed;
            }
            if (direction == "down")
            {
                y += speed;
            }
        }
    }
}
