using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;

namespace dotnetMVCIdentity.Authorization
{
    public class NicknameRequirment : IAuthorizationRequirement
    {
        public NicknameRequirment(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
