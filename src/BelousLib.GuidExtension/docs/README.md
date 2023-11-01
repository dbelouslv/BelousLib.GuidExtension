# BelousLib.GuidExtension
This library helps convert GUIDs to integers and vice versa

```csharp
using BelousLib.GuidExtension;

namespace Program
{
    public class Program
    {
        private static void Main()
        {
            //Output 36864
            Console.WriteLine(new Guid("00900000-0000-0000-0000-000000000000").ToInt32());

            //Output a7010000-0000-0000-0000-000000000000
            Console.WriteLine(423.ToGuid());
        }
    }
}
```
