using FaceBook.Marketing.SDK;
using FaceBook.Marketing.SDK.Models.SystemUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facebook.Marketing.Api.Application.Services
{
    public interface ISystemUserService
    {
        Task<FacebookResult<CreateSystemUserResponse>> CreateSystemUser();


    }
}
