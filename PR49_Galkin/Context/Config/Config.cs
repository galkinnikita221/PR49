﻿using Microsoft.EntityFrameworkCore;

namespace PR49_Galkin.Context.Config
{
    public class Config
    {
        public static readonly string StrConnect = "server=localhost;uid=root;database=pr49";
        public static MySqlServerVersion mySqlServerVersion = new MySqlServerVersion(new System.Version(8, 0, 11));
    }
}
