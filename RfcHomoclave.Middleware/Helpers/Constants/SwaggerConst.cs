namespace RfcHomoclave.Middleware.Helpers.Constants
{
    public class SwaggerConst
    {
        public const string ServiceVersion = "v1";

        public const string Bearer = "Bearer";
        public const string DefinitionName = "Authorization";
        public const string BearerFormat = "JWT";

        public const string CustomUi = "custom-swagger-ui";
        public const string VirtualDirectory = "VirtualDirectory";
        public const string SwaggerExtensionXml = ".xml";
        public const string Description = "Autorizacion JWT esquema. \r\n\r\n Write 'Bearer' [gap] and write your token.\r\n\r\nExample: \"Bearer 12345abcdef\"";

        #region RfcHomoclave
        public const string RfcHomoclaveTitle = "RfcHomoclave Service";
        public const string RfcHomoclaveName = "rfc_homoclave";
        #endregion
    }
}
