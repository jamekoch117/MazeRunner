using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    class Bullet
    {
        public int x, y, xSpeed, ySpeed, width, height;
        Boolean bulletRight, bulletUp;

        public Bullet(int _x, int _y, int _xSpeed, int _ySpeed, int _width, int _height, bool _bulletRight, bool _bulletUp)
        {
            x = _x;
            y = _y;
            xSpeed = _xSpeed;
            ySpeed = _ySpeed;
            width = _width;
            height = _height;
            bulletRight = _bulletRight;
            bulletUp = _bulletUp;
        }

        public void Move()
        {
            //ball goes left/right
            if (bulletRight == true)
            {
                x = x + xSpeed;
            }
            else
            {
                x = x - xSpeed;
            }

            // ball goes up/down
            if (bulletUp == true)
            {
                y = y - ySpeed;
            }
            else
            {
                y = y + ySpeed;
            }
        }
    }
}
