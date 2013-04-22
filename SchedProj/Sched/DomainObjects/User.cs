using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SWE346.Module5.Problem1.DomainObjects
{
    /// <summary>
    /// Creates a login user who can schedule and be invited to meetings
    /// Display room availability for each day on the web page.
    /// Properties:
    /// Name
    /// Login password (encrypted)
    /// Availability (Time / Date slots)
    /// Methods:
    /// User.Login
    /// User.RequestMeeting(Attendee, Resource, Time/Date)
    /// User.ReceiveRequest(Requester, Resource, Time/Date)
    /// </summary>
    public class User
    {
        /// <summary>
        /// The name of the User.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Pass { get; set; }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        public void Login (string uname
            , string passwd) { 
            ; }

        /// <summary>
        /// Request to invite another user to a resource at a given time
        /// Returns the Invite Num index
        /// </summary>
        public int Request(
            string invitee
            , string  resource
            , DateTime reqdate) {
                return 0;
        }

        /// <summary>
        /// Accept an invitation given the invite num
        /// </summary>
        public void Accept(int invnum)
        {
            ;
        }

        /// <summary>
        /// Reject an invitation given the invite num
        /// </summary>
        public void Reject(int invnum)
        {
            ;
        }

    }
}