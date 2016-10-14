using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchiffeVersenken_GUI
{
    class GameTile
    {
        private int _status;
        private bool _discovered;
        private string _color;

        public GameTile(int status)
        {
            _status = status;
            _discovered = false;
        }


        public int Status
        {
            get
            {
                if (_discovered)
                    return _status;
                return 2;
            }
            set
            {
                if (value == 2)
                {
                    _discovered = false;
                }
                else
                {
                    _status = value;
                }
            }
        }

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
    }
}
