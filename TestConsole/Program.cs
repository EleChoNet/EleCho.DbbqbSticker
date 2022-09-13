
using EleCho.DbbqbSticker;


HttpClient client = new HttpClient();
foreach (var info in await Dbbqb.GetAsync())
{
    using FileStream fs = File.Create($"{info.Id}.jpg");
    Console.WriteLine(info);

    Stream stream = await client.GetStreamAsync(info.Path);
    stream.CopyTo(fs);
}