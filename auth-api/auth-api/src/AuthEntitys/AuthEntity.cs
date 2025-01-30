﻿using CreateEntitys.Base;

namespace CreateEntitys;

public class AuthEntity : EntityBase
{
    public string Password { get; set; }
    public DateTime LastLoginDate { get; set; }
    
    public string IdUser {get; set;}
    public UserEntity User { get; set; }   
}