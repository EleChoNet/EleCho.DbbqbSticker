using EleCho.DbbqbSticker;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static async Task TestMethod1Async()
        {
            HttpClient client = new HttpClient();
            foreach (var info in await Dbbqb.GetAsync())
            {
                //using FileStream fs = File.Create($"{info.Id}.jpg");
                Console.WriteLine(info);
                
                //Stream stream = await client.GetStreamAsync(info.Path);
                //stream.CopyTo(fs);
                //Assert.IsTrue(stream.Length != 0);
            }
        }
    }
}