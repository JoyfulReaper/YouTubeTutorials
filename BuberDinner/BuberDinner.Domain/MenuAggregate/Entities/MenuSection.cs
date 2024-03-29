using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.MenuAggregate.ValueObjects;

namespace BuberDinner.Domain.MenuAggregate.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> menuItems
    ) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }

    public string Name { get; }
    public string Description { get; set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(
        string name,
        string description,
        List<MenuItem> menuItems
    )
    {
        return new(
            MenuSectionId.CreateUnique(),
            name,
            description,
            menuItems);
    }
}