using MVCPublishersProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPublishersProject.DataBase
{
    public class BataBaseContext
    {
        private static PublishersDB _DataBase;

        public static PublishersDB DataBase { get
            {
                if (_DataBase == null)
                {
                    _DataBase = new PublishersDB();
                }

                return _DataBase;
            }
        }

        private BataBaseContext()
        {
        }
    }
}