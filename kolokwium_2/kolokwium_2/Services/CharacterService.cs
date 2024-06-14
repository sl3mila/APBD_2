using kolokwium_2.Context;
using kolokwium_2.Exceptions;
using kolokwium_2.Models;
using kolokwium_2.ResponseModels;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_2.Services;

interface ICharacterService
{
    Task<GetCharacterResponseModel> GetCharacterId(int id);
    Task<GetBackpackSlotResponseModel> AddItemsTobackpack(int characterId, List<int> list);
}

public class CharacterService : ICharacterService
{
    private DatabaseContext _context;

    public CharacterService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<GetCharacterResponseModel> GetCharacterId(int id)
    {

        var res = await _context.Characters
            .Where(a => a.CharacterId == id)
            .Select(a => new GetCharacterResponseModel()
            {
                CharacterId = a.CharacterId,
                CharacterFirstName = a.CharacterFirstName,
                CharacterLastName = a.CharacterLastName,
                CharacterCurrentWeight = a.CharacterCurrentWeight,
                CharacterMaxWeihght = a.CharacterMaxWeihght,
                CharacterMoney = a.CharacterMoney,

                BackpackSlots = _context.BackpackSlots.Where(a => a.BackpackSlotId == id)
                    .Select(a => new GetBackpackSlotResponseModel()
                    {
                        BackpackSlotId = a.BackpackSlotId,
                        BackpackSlotItem = a.BackpackSlotItem,
                        BackpackSlotCharaccter = a.BackpackSlotCharaccter,
                    }),

                Titles = _context.Titles
                    .Where(a => a.TitleId == id)
                    .Select(a => new GetTitleResponseModel()
                    {
                    TitleId = a.TitleId,
                    TitleNam = a.TitleNam,
                    })
                
            }).FirstOrDefaultAsync();
        
        if (res is null)
        {
            throw new NotFoundException("Charatcer with id:{id} doesn't exist");
        }

        return res;
    }

    public Task<GetBackpackSlotResponseModel> AddItemsTobackpack(int characterId, List<int> list)
    {

        var character = await _context.Characters
            .Where(a => a.CharacterId == characterId)
            .Select(a => new GetCharacterResponseModel()
            {
                CharacterId = a.CharacterId,
                CharacterFirstName = a.CharacterFirstName,
                CharacterLastName = a.CharacterLastName,
                CharacterCurrentWeight = a.CharacterCurrentWeight,
                CharacterMaxWeihght = a.CharacterMaxWeihght,
                CharacterMoney = a.CharacterMoney,
                
                BackpackSlots = _context.BackpackSlots.Where(a => a.BackpackSlotId == characterId)
                    .Select(a => new GetBackpackSlotResponseModel()
                    {
                        BackpackSlotId = a.BackpackSlotId,
                        BackpackSlotItem = a.BackpackSlotItem,
                        BackpackSlotCharaccter = a.BackpackSlotCharaccter,
                    }),
                
            }).FirstOrDefaultAsync();

        if (character is null)
        {
            throw new NotFoundException("character not found");
        }
        
        for (int i = 0; i < list.Capacity; i++)
        {
            var item = await _context.Items
                .Where(a => a.ItemId == i)
                .Select(a => new GetItemResponseModel()
                {
                    ItemId = a.ItemId,
                    ItemName = a.ItemName,
                    ItemWeight = a.ItemWeight
                }).FirstOrDefaultAsync();

            if (item is null)
            {
                throw new NotFoundException("character not found");
            }
            
            
        }
        
        
        
        throw new NotImplementedException();
    }
}