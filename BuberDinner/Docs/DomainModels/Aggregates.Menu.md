# Domain Models

## Menu

```csharp
class Menu 
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
    "id": "1",
    "name": "Yummy Menu",
    "description": "A menu with yummy foods",
    "averageRating: 4.5
    "sections": [
        {
            "id": "1",
            "name": "Appetizers",
            "description": "Starters",
            "items": [
                "id": "1",
                "name": "Fried Pickles",
                "description": "Deep fried pickles",
                "price": 5.99
            ]
        }
    ],
    "createdDateTime": "",
    "updatedDateTime: "",
    "hostId": "1",
    "dinnerIds": [
        "1"
    ],
    "menuReviewIds": [
        "1"
    ]
}
```