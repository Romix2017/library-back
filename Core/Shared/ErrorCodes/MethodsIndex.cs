using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shared.ErrorCodes
{
    public class MethodsIndex
    {
        #region General DB Methods (1-100)
        public const int ADD = 1;
        public const int REMOVE = 2;
        public const int UPDATE = 3;
        public const int REMOVE_RANGE = 4;
        public const int GET_BY_ID = 5;
        public const int GET_ALL = 6;
        public const int ADD_RANGE = 7;
        public const int ADD_ENTITY = 8;
        public const int UPDATE_ENTITY = 9;
        #endregion

        #region UsersService
        public const int GET_USER_BY_NAME = 101;
        #endregion
    }
}
