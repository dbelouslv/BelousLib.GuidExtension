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
        var persons = new List<PersonDTO>()
        {
            new()
            {
                Id = 534,
                Name = "Denis",
                Age = 28,
                Cards = new List<CardDTO>()
                {
                    new()
                    {
                        Balance = 599934.34,
                        CardNumber = "0503259828482932"
                    }
                },
                Kids = new List<PersonDTO>()
                {
                    new ()
                    {
                        Id = 642,
                        Name = "Max",
                        Age = 2,
                        Cards = new List<CardDTO>(),
                        Kids = null
                    }
                }
            },

            new ()
            {
                Id = 452,
                Age = null,
                Name = null,
                Cards = new List<CardDTO>()
                {
                    new()
                    {
                        Balance = 54363646.63,
                        CardNumber = "0503284548482932"
                    }
                },
                Kids = null
            }
        };

        return Ok(persons);
    }
}

//Output
//[
//  {
//    "Id": "00000216-0000-0000-aff7-639ef5881baa",
//    "Name": "Denis",
//    "Age": 28,
//    "Cards": [
//      {
//       "Balance": "ae147ae1-4efc-4122-0000-000000000000",
//        "CardNumber": "33303530-3532-3839-2a4f-c91dd458c31c"
//      }
//    ],
//    "Kids": [
//      {
//        "Id": "00000282-0000-0000-7e87-2669a65f893b",
//        "Name": "Max",
//        "Age": 2,
//        "Cards": [],
//        "Kids": null
//      }
//    ]
//  },
//  {
//    "Id": "000001c4-0000-0000-bde0-d69a2fff596b",
//    "Name": null,
//    "Age": null,
//    "Cards": [
//      {
//        "Balance": "f50a3d71-ec2f-4189-0000-000000000000",
//        "CardNumber": "33303530-3832-3534-4bf3-3ab132b2840a"
//      }
//    ],
//    "Kids": null
//  }
//]

```

Here's an example of a model with fields annotated with the **Guidable** attribute. By default **EnableZeroRemoving** is turn on, but you can disable it: `[Guidable(false)]`

```csharp
 public class PersonDTO
    {
        [Guidable]
        public int Id { get; set; }

        public string? Name { get; set; }

        public int? Age { get; set; }

        public IEnumerable<Card> Cards { get; set; }

        public IEnumerable<Person>? Kids { get; set; }
    }

    public class CardDTO
    {
        [Guidable(false)]
        public double Balance { get; set; }

        [Guidable]
        public string CardNumber { get; set; }
    }
```