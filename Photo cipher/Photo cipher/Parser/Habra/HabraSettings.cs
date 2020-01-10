namespace Photo_cipher.Parser.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; set; }
    }
}
