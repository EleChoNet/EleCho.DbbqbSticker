using System.Net.Http.Json;

namespace EleCho.DbbqbSticker
{
    /// <summary>
    /// 逗逼表情包; Funny stickers
    /// </summary>
    public static class Dbbqb
    {
        static Dbbqb()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseUri);
            Client.DefaultRequestHeaders.Add("User-Agent", "Meow");
            Client.DefaultRequestHeaders.Add("web-agent", "web");
        }

        private const string BaseUri = "https://www.dbbqb.com/";
        private static readonly HttpClient Client;

        /// <summary>
        /// 获取表情包; Get stickers
        /// </summary>
        /// <param name="start">起始索引; Start index</param>
        /// <param name="count">结果数量; Result count</param>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> GetAsync(int start, int count)
        {
            string requestUri = $"api/search/json?start={start}&size={count}";
            DbbqbInfo[]? dbbqbInfos = await Client.GetFromJsonAsync<DbbqbInfo[]>(requestUri);
            if (dbbqbInfos == null)
                return Array.Empty<DbbqbInfo>();
            return dbbqbInfos;
        }

        /// <summary>
        /// 获取表情包; Get stickers (starts from 0)
        /// </summary>
        /// <param name="count">结果数量; Result count</param>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> GetAsync(int count)
        {
            return await GetAsync(0, count);
        }

        /// <summary>
        /// 获取 100 个表情包; Get 100 stickers
        /// </summary>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> GetAsync()
        {
            return await GetAsync(0, 100);
        }

        /// <summary>
        /// 获取 1 个表情包; Get 1 sticker
        /// </summary>
        /// <returns>结果. null 表示无结果; Result. null for no result</returns>
        public static async Task<DbbqbInfo?> GetSingleAsync()
        {
            DbbqbInfo[] gets = await GetAsync(0, 1);
            return gets.Length != 0 ? gets[0] : null;
        }

        /// <summary>
        /// 搜索表情包; Search for stickers
        /// </summary>
        /// <param name="kwd">关键词; Keyword</param>
        /// <param name="start">起始索引; Start index</param>
        /// <param name="count">结果数量; Result count</param>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> SearchAsync(string kwd, int start, int count)
        {
            string queryStr = Uri.EscapeDataString(kwd);
            string requestUri = $"api/search/json?start={start}&size={count}&w={queryStr}";
            DbbqbInfo[]? dbbqbInfos = await Client.GetFromJsonAsync<DbbqbInfo[]>(requestUri);
            if (dbbqbInfos == null)
                return Array.Empty<DbbqbInfo>();
            return dbbqbInfos;
        }

        /// <summary>
        /// 搜索表情包; Search for stickers (从零开始. starts from 0)
        /// </summary>
        /// <param name="kwd">关键词; Keyword</param>
        /// <param name="count">结果数量; Result count</param>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> SearchAsync(string kwd, int count)
        {
            return await SearchAsync(kwd, 0, count);
        }

        /// <summary>
        /// 搜索表情包; Search for stickers (从零开始, 数量为100. starts from 0 and count for 100)
        /// </summary>
        /// <param name="kwd">关键词; Keyword</param>
        /// <returns>结果. 空表示无结果; Result. Empty for no result</returns>
        public static async Task<DbbqbInfo[]> SearchAsync(string kwd)
        {
            return await SearchAsync(kwd, 0, 100);
        }

        /// <summary>
        /// 搜索 1 个表情包; Search for one sticker
        /// </summary>
        /// <param name="kwd">关键词; Keyword</param>
        /// <returns>结果. null 表示无结果; Result. null for no result</returns>
        public static async Task<DbbqbInfo?> SearchSingleAsync(string kwd)
        {
            DbbqbInfo[] gets = await SearchAsync(kwd, 0, 1);
            return gets.Length != 0 ? gets[0] : null;
        }
    }
}