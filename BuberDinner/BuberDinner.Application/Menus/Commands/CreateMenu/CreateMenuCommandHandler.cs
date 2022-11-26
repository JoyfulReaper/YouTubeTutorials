using BuberDinner.Domain.HostAggregate.ValueObjects;
using BuberDinner.Domain.MenuAggregate;
using BuberDinner.Domain.MenuAggregate.Entities;

using ErrorOr;

using MediatR;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    public Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        // Ceate Menu
        var menu = Menu.Create(
            HostId.Create(request.HostId),
            request.Name,
            request.Description,
            request.Sections.Select(section => MenuSection.Create(
                section.Name, 
                section.Description, 
                section.Items.Select(Item => MenuItem.Create(
                    Item.Name, 
                    Item.Description)).ToList())).ToList()
        );
        // Persist Menu
        // Return Menu

        return default!;
    }
}
