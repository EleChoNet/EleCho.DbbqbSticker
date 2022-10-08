# EleCho.DbbqbSticker

某逗逼表情包网站的接口调用封装

## 使用方式

```csharp
using EleCho.DbbqbSticker;

var allInfo = await Dbbqb.GetAsync();    // 获取表情包信息
foreach (var info in allInfo)
{
    using FileStream fs = File.Create($"{info.Id}.jpg");        // Open File
    Console.WriteLine(info);                                    // 控制台打印信息

    Stream stream = await client.GetStreamAsync(info.Path);     // 下载表情包
    stream.CopyTo(fs);                                          // 保存到文件
}
```