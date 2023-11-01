# BelousLib.GuidExtension
This library helps convert **GUIDs** to **int/long/short** and vice versa

```csharp
using BelousLib.GuidExtension;

namespace Example
{
    public class Program
    {
        private static void Main()
        {
            //Output 36864
            Console.WriteLine(new Guid("00900000-0000-0000-0000-000000000000").ToInt32());

            //Output a7010000-0000-0000-0000-000000000000
            Console.WriteLine(423.ToGuid());

            //Output 6748db38b5fd40c18066c0a0f1733377
            Console.WriteLine(new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringWithoutDashes());
        }
    }
}
```
<h1 align="center">Where can I use it?</h1>

- For example, in a database, instead of using a **GUID** as the primary key, which occupies 16 bytes, you can use **int** or **long**, which occupy 4 and 8 bytes respectively. However, when displaying data to the user, you can convert **int/long** to a **GUID**. This means that you've implemented the logic with **GUIDs** and saved memory.
  
  ```csharp
  cfg.CreateMap<User, UserDto>()
    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToGuid()));
  ```
   ```csharp
  cfg.CreateMap<UserDto, User>()
    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToInt32()));
  ```
- If you don't want to display the identifiers of your entities, you can use this library as a form of **"encryption"** method.

  **Before**: `/user?userId=1&teamId=59`
  
  **After**: `/user?userId=01000000-0000-0000-0000-000000000000&teamId=3b000000-0000-0000-0000-000000000000`
