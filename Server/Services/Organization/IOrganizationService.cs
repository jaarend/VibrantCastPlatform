using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Models.Organization;

namespace Server.Services.Organization
{
    public interface IOrganizationService
    {
        Task<bool> CreateOrganizationAsync(OrganizationCreate model);
    }
}