﻿using DomainLayer.Models.User;
using InfrastructureLayer.DataAccess.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.DataAccess.Repositories.User
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
    }
}
