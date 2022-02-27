using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Profiles.Resolvers
{
    /// <summary>
    /// Additional structure that helps to resolve date while mapping objects
    /// </summary>
    public class DateTimeResolver : IValueResolver<object, object, long>
    {
        // TODO: refactor generated time
        /// <summary>
        /// Method for automatically setting destination date
        /// </summary>
        /// <param name="source">Mapping source object</param>
        /// <param name="destination">Mapping destination object</param>
        /// <param name="destMember">Mapping destionation object member</param>
        /// <param name="context"></param>
        /// <returns>Resolved unix timestamp</returns>
        public long Resolve(object source, object destination, long destMember, ResolutionContext context)
        {
            return DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}
