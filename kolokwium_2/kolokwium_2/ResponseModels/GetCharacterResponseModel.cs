using kolokwium_2.Models;

namespace kolokwium_2.ResponseModels;

public class GetCharacterResponseModel
{
    public int CharacterId { get; set; }
    public string CharacterFirstName { get; set; }
    public string CharacterLastName { get; set; }
    public int CharacterCurrentWeight { get; set; }
    public int CharacterMaxWeihght { get; set; }
    public int CharacterMoney { get; set; }
    
    public IQueryable<GetBackpackSlotResponseModel> BackpackSlots { get; set; }
    public IQueryable<GetTitleResponseModel> Titles { get; set; }
    
    //itd
}