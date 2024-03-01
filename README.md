# BelousLib.GuidExtension
This library helps convert **GUIDs** to **int/long/short/double/float** and vice versa

```csharp
using BelousLib.GuidExtension;

namespace Example
{
    public class Program
    {
        private static void Main()
        {
            //Output 9437184
            Console.WriteLine(new Guid("00900000-0000-0000-0000-000000000000").ToInt32());

            //Output 000001a7-0000-0000-0000-000000000000
            Console.WriteLine(423.ToGuid());

            //Output 000001a7-0000-0000-7cfe-ccc22d685ef2
            Console.WriteLine(423.ToGuid(true));

            //Output 8f084620-b454-40dc-0000-000000000000
            Console.WriteLine(29393.32123.ToGuid());

            //Output 00001092-0000-0000-0000-000000000000, 00000251-0000-0000-0000-000000000000, 00000513-0000-0000-0000-000000000000
            Console.WriteLine(new[] { 4242, 593, 1299 }.ToGuid());

            //Output 6748db38b5fd40c18066c0a0f1733377
            Console.WriteLine(new Guid("6748db38-b5fd-40c1-8066-c0a0f1733377").ToStringFromGuidWithoutDashes());

            //Output 33303530-3832-3534-4bf3-3ab132b2840a
            //String -> ToGuid() only supports text up to 16 characters 
            Console.WriteLine("0503284548482932".ToGuid(true));
        }
    }
}
```
## Where can I use it?

- For example, in a database, instead of using a **GUID** as the primary key, which occupies 16 bytes, you can use **int** or **long**, which occupy 4 and 8 bytes respectively. However, when displaying data to the user, you can convert **int/long** to a **GUID**. This means that you've implemented the logic with **GUIDs** and saved memory.
  
  ```csharp
  cfg.CreateMap<User, UserDto>()
    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToGuid()));
  ```
   ```csharp
  cfg.CreateMap<UserDto, User>()
    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToInt32()));
  ```
- If you don't want to display the identifiers of your entities, you can use this library as a form of **"encryption"** method. Below you can see example with using a **enableZeroRemoving** flag

  **Before**: `/user?userId=1&teamId=59`
  
  **After**: `/user?userId=00000001-0000-0000-ed5c-1a8fcef14830&teamId=0000003b-0000-0000-6546-65a55278fe74`
  
  
## Important

Please note that when converting, only the first 16 characters of the GUID are filled with data, while the remaining values are left as zeros. Since it doesn't matter what will be in their place, the **enableZeroRemoving** flag was added to replace the zeros with any HEX values. Also when you want to convert **String -> ToGuid()** be careful that only supports text up to 16 characters. 

```csharp
  //Output 6748db38-b5fd-40c1-5a66-8f6a0e5c1c0b
  var withFlag = 4666210788896725816.ToGuid(true);

  //Output 6748db38-b5fd-40c1-0000-000000000000
  var withOutFlag = 4666210788896725816.ToGuid();
```

# Guidable

If you don't want to create new **DTO** models with **GUID** data type and use our `ToGuid()` method for multiple fields but still want to send **GUID** values to the front-end, we have created a new solution - `Guidable Attribute`.

To achieve this, you need to specify the `[GuidableResult]` attribute for the **action**, and the fields that you want to convert to **GUID** should have the `[Guidable]` attribute. Example you can see below:

```csharp
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PersonController : BaseController
{
    //Contructor
    
    [HttpGet]
    [GuidableResult]
    public IActionResult Get()
    {
        var persons = new List<PersonDTO>
        {
            new()
            {
                Id = 1,
                Age = 28,
                PersonalId = 598938423644,
                Name = "Denis",
                Pins = [4125, 7453],
                Cards =
                [
                    new CardDTO
                    {
                        Balance = 5923.42f,
                        Number = "5302292329406953"
                    }
                ]
            },
            new()
            {
                Id = 2,
                Age = 24,
                PersonalId = 598938423422,
                Name = "Viktorija",
                Pins = [4203, 5212],
                Cards =
                [
                    new CardDTO
                    {
                        Balance = 15262.42f,
                        Number = "5301192749406953"
                    }
                ]
            }
        };

        return Ok(persons);
    }
}

//Output
//[
//  {
//    "Id": "00000001-0000-0000-0000-000000000000",
//    "Name": "Denis",
//    "Age": 28,
//    "PersonalId": "622b8000-6e70-4261-62ae-70eafc3d7169",
//    "Pins": [
//      "0000101d-0000-0000-b197-884072decf66",
//      "00001d1d-0000-0000-4799-1dfb77a405df"
//    ],
//    "Cards": [
//      {
//        "Number": "32303335-3932-3332-6d53-ac43e6e3cd06",
//        "Balance": 5923.42
//      }
//    ]
//  },
//  {
//    "Id": "00000002-0000-0000-0000-000000000000",
//    "Name": "Viktorija",
//    "Age": 24,
//    "PersonalId": "620fc000-6e70-4261-b3c6-316d3e28a20b",
//    "Pins": [
//      "0000106b-0000-0000-3cc6-47761a264267",
//      "0000145c-0000-0000-4df0-0a3fa7bc5ddb"
//    ],
//    "Cards": [
//      {
//        "Number": "31303335-3931-3732-eafe-7ba344dc6141",
//        "Balance": 15262.42
//      }
//    ]
//  }
//]
```

Here's an example of a model with fields annotated with the **Guidable** attribute. By default **EnableZeroRemoving** is turn on, but you can disable it: `[Guidable(false)]`

```csharp
public class PersonDTO
{
    [Guidable(false)]
    public int Id { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    [Guidable]
    public double PersonalId { get; set; }

    [Guidable]
    public IEnumerable<int> Pins { get; set; } = [];

    public IEnumerable<CardDTO> Cards { get; set; } = [];
}

public class CardDTO
{
    [Guidable]
    public string Number { get; set; }

    public float Balance { get; set; }
}
```