﻿using THOK.Authority.Dal.Interfaces;
using THOK.Authority.DbModel;
using THOK.Common.Ef.EntityRepository;

namespace THOK.Authority.Dal.EntityRepository
{
    public class UserRepository : RepositoryBase<AUTH_USER>, IUserRepository
    {        
    }
}
