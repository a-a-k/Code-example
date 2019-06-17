using System;
using System.Linq.Expressions;

namespace EyeRide.FMS.DTO.Mapping
{
    public class UserDTOMapping
    {
        public static Expression<Func<Users, UserDTO>> ToShortDTO =>
        u => new UserDTO
        {
            UserGUID = u.UserGUID,
            UserName = u.AspNetUser.UserName,
            Name = u.AspNetUser.TryGetFullName(),
        };
    }
}
