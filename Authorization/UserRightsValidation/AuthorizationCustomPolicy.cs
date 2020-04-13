using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Db.Authorization.Model;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace UserRightsValidation
{
    public class AuthorizationCustomPolicy : IAuthorizationPolicyProvider
    {
        public DefaultAuthorizationPolicyProvider defaultAuthorizationPolicyProvider {get;}

        public AuthorizationCustomPolicy(IOptions<AuthorizationOptions> options)
        {
            defaultAuthorizationPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            return defaultAuthorizationPolicyProvider.GetDefaultPolicyAsync();
        }

        public Task<AuthorizationPolicy> GetPolicyAsync(string policyName) 
        {
            var policy = new AuthorizationPolicyBuilder();
            string[] subStringPolicy = policyName.Split(new Char[] { '.' });
            AttributeType attributeType = (AttributeType)Enum.Parse(typeof(AttributeType), subStringPolicy[0]);
            switch (attributeType) 
            {
                case AttributeType.Module:
                    var moduleType = (RightModule)Enum.Parse(typeof(RightModule), subStringPolicy[1]);
                    policy.AddRequirements(new ModuleRequirement(moduleType));
                    return Task.FromResult(policy.Build());

                case AttributeType.Permission:
                    var modulerType = (RightModule)Enum.Parse(typeof(RightModule), subStringPolicy[1]);
                    var objectType = (RightObject)Enum.Parse(typeof(RightObject), subStringPolicy[2]);
                    var operatorType = (RightOperator)Enum.Parse(typeof(RightOperator), subStringPolicy[3]);
                    
                    policy.AddRequirements(new PermissionRequirement(modulerType,objectType, operatorType));
                    return Task.FromResult(policy.Build());
                default :
                    return defaultAuthorizationPolicyProvider.GetPolicyAsync(policyName);

            }
                


        }

        public Task<AuthorizationPolicy> GetFallbackPolicyAsync()
        {
            return ((IAuthorizationPolicyProvider)defaultAuthorizationPolicyProvider).GetFallbackPolicyAsync();
        }
    }
}
