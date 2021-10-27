namespace ChatRoom.Configuration
{
    public class AppSettings
    {
        /// <summary>
        ///     Id de la aplicacion de Luis
        /// </summary>
        public string LuisId { get; set; }

        /// <summary>
        ///     Id del servicio de cognitivo de azure
        /// </summary>
        public string LuisApiKey { get; set; }

        /// <summary>
        ///     Host de conexión al servicio cognivito
        /// </summary>
        public string LuisHostName { get; set; }

        /// <summary>
        ///     Endpoint de la aplicación de luis
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        ///     Api de publicación
        /// </summary>
        public string FullEndpoint { get; set; }
    }
}