using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Profiles.Resolvers
{
    /// <summary>
    /// Additional structure that helps to resolve guid while mapping objects
    /// </summary>
    public class GuidResolver : IValueResolver<object, object, Guid>
    {
        /// <summary>
        /// Method for automatically setting destination identifier
        /// </summary>
        /// <param name="source">Mapping source object</param>
        /// <param name="destination">Mapping destination object</param>
        /// <param name="destMember">Mapping destionation object member</param>
        /// <param name="context"></param>
        /// <returns>Resolved guid</returns>
        public Guid Resolve(object source, object destination, Guid destMember, ResolutionContext context)
        {
            return Guid.NewGuid();
        }
    }
}
