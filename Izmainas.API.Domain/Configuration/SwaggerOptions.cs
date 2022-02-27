namespace Izmainas.API.Domain.Configuration
{
    /// <summary>
    /// Structure used to retrieve Swagger configuration from file
    /// </summary>
    public class SwaggerOptions
    {
        /// <summary>
        /// Represents application version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Represents title to show on swagger page
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents endpoint to access the swagger page
        /// </summary>
        public string Endpoint { get; set; }
    }
}
