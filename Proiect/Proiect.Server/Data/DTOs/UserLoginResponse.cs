﻿using Proiect.Models;

namespace Proiect.Data.DTOs
{
    public class UserLoginResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }


        public UserLoginResponse(User user, string token)
        {
            Id = user.Id;
            UserName = user.Username;
            Token = token;
        }
    }
}
