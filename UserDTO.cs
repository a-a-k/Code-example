﻿using System;

namespace DTO
{
    public class UserDTO
    {
        [ShortModelMember]
        public string UserGUID { get; set; }

        [ShortModelMember]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [ShortModelMember]
        public string Name { get; set; }
    }
}
