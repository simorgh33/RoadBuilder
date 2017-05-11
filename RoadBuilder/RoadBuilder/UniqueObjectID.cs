using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    class UniqueObjectID
    {
        private uint _ID;
        private uint _IDType;
        private string _IDName;

        public UniqueObjectID()
        {
            _ID = 0;
            _IDType = 0;
            _IDName = "Undefined";
        }

        public UniqueObjectID(uint ID, uint IDType, string IDName)
        {
            this._ID = ID;
            this._IDType = IDType;
            this._IDName = IDName;
        }

        public uint ID
        {
            get
            {
                return this._ID;
            }
        }

        public uint IDType
        {
            get
            {
                return this._IDType;
            }
        }

        public string IDName
        {
            get
            {
                return this._IDName;
            }
        }
    }
}
