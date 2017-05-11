using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Roadbuilder
{
    class InterfaceObject : EventHandlingObject
    {
        private uint _GroupID;
        private string _Name;

        public InterfaceObject() : base()
        {
            this._GroupID = 0;
            this._Name = string.Empty;
        }

        public InterfaceObject(string Name, uint ID) : base(null)
        {

        }

        public InterfaceObject(string Name, uint ID, EventHandler EventHandler) : base(EventHandler)
        {

        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public uint GroupID
        {
            get
            {
                return this._GroupID;
            }
        }
    }
}
