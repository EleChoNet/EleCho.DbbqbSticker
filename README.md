# EleCho.DbbqbSticker

ĳ���Ʊ������վ�Ľӿڵ��÷�װ

## ʹ�÷�ʽ

```csharp
using EleCho.DbbqbSticker;

var allInfo = await Dbbqb.GetAsync();    // ��ȡ�������Ϣ
foreach (var info in allInfo)
{
    using FileStream fs = File.Create($"{info.Id}.jpg");        // Open File
    Console.WriteLine(info);                                    // ����̨��ӡ��Ϣ

    Stream stream = await client.GetStreamAsync(info.Path);     // ���ر����
    stream.CopyTo(fs);                                          // ���浽�ļ�
}
```