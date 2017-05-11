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
    class GameObject : EventHandlingObject
    {
        private uint _GroupID;
        private string _Name;

        public GameObject() : base()
        {
            this._GroupID = GroupObjectID.GroupID_None;
            this._Name = string.Empty;
        }

        public GameObject(string Name, uint GroupID) : base()
        {
            this._GroupID = GroupID;
            this._Name = Name;
        }

        public GameObject(string Name, uint GroupID, EventHandler EventHandler) : base(EventHandler)
        {
            this._GroupID = GroupID;
            this._Name = Name;
        }

        public uint GroupID
        {
            get
            {
                return this._GroupID;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }
    }
}
