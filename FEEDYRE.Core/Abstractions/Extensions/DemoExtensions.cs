using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEDYRE.Core.Models;
using FEEDYRE.Web.Dtos;

namespace FEEDYRE.Core.Abstractions.Extensions
{
    public static class DemoExtensions
    {
        public static User ToEntity(this UserDto user)
        {
            return new User()
            {
                Email = user.Email,
                Password = user.Password
            };
        }

        public static UserDto ToDto(this User user)
        {
            return new UserDto()
            {
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
