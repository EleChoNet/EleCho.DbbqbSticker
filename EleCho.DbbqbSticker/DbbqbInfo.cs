using System.Text.Json.Serialization;

namespace EleCho.DbbqbSticker
{
    /// <summary>
    /// 逗逼表情包信息 Funny sticker infomation
    /// </summary>
    public class DbbqbInfo
    {
        private static readonly Uri BaseUri = new Uri("https://image.dbbqb.com");

        /// <summary>
        /// 构建实例; Construct a new instance
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="width">宽度; Width</param>
        /// <param name="height">高度; Height</param>
        /// <param name="path">相对地址; Related path</param>
        /// <param name="description">描述信息; Description</param>
        [JsonConstructor]
        public DbbqbInfo(int id, int width, int height, string path, string? description)
        {
            Id = id;
            Width = width;
            Height = height;
            Path = new Uri(BaseUri, path).ToString();
            Description = description;
        }

        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; }
        /// <summary>
        /// 宽度
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; }
        /// <summary>
        /// 高度
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; }
        /// <summary>
        /// 表情地址; Sticker address
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; }
        /// <summary>
        /// 描述信息
        /// </summary>
        [JsonPropertyName("desc")]
        public string? Description { get; }
    }
}