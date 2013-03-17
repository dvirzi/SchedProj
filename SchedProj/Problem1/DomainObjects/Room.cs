using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWE346.Module5.Problem1.DomainObjects
{
    /// <summary>
    /// Creates a Resource to schedule meetings
    /// Properties:
    /// Room Name
    /// Room Description or comments
    /// Login password (encrypted)
    /// Availability (Time / Date slots)
    /// Methods:
    /// Room.showAvail(date)
    /// Room.UpdateAvail(date)
    /// Room.showInfo
    /// </summary>
    public class Room
    {
        /// <summary>
        /// The name of the Room.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Room Description or comments.
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// Room Available?.
        /// </summary>
        public Boolean Available(DateTime dt)
        {
            // query DB for Room.Name and Date / Time  
            return false;
        }

        /// <summary>
        /// Room Available?.
        /// </summary>
        public Boolean Reserve(DateTime dt, string RO)
        {
            // Entry to DB for Room.Name and Date,Time = R / O
            return false;
        }
    }
}