namespace Photo_cipher.Parser.Habra
{
    class HabraSettings : IParserSettings
    {
        public HabraSettings(string baseUrl, string prefix)
        {
            BaseUrl = baseUrl;
            Prefix = prefix;
        }

        public string BaseUrl { get; set; }

        public string Prefix { get; set; }
    }
}
